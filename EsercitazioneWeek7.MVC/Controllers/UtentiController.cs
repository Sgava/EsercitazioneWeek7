using EsercitazioneWeek7.CORE.BusinessLayer;
using EsercitazioneWeek7.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EsercitazioneWeek7.MVC.Controllers
{
    public class UtentiController : Controller
    {
        private readonly IBusinessLayer BL;
        public UtentiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl="/")
        {
            return View(new UtenteViewModel { ReturnUrl = returnUrl});
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UtenteViewModel utenteViewModel)
        {
            if (utenteViewModel == null)
            {
                return View();
            }

            var utente = BL.GetAccount(utenteViewModel.Username);
            if (utente != null && ModelState.IsValid)
            {
                if (utente.Password == utenteViewModel.Password)
                {
                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, utenteViewModel.Username),
                        new Claim(ClaimTypes.Role, utente.Ruolo.ToString())
                    };

                    var properties = new AuthenticationProperties
                    {
                        RedirectUri = utenteViewModel.ReturnUrl,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1), 
                    };

                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties);

                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(utenteViewModel.Password), "password Errata");
                    return View(utenteViewModel);
                }

            }
            else
            {
                return View(utenteViewModel);
            }
        }

        public IActionResult Forbidden() => View();

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
