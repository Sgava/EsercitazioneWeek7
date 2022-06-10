using EsercitazioneWeek7.CORE.BusinessLayer;
using EsercitazioneWeek7.MVC.Helper;
using EsercitazioneWeek7.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsercitazioneWeek7.MVC.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IBusinessLayer BL;

        public MenuController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Index()
        {
            var listaMenu = BL.GetAllMenus(); 

            var listaViewModel = new List<MenuViewModel>();

            foreach (var menu in listaMenu)
            {
                listaViewModel.Add(menu.ToMenuViewModel());
            }

            return View(listaViewModel);
        }

        [HttpGet("Menu/Details/{id}")] 
        public IActionResult Details(int id) 
        {
            var menu = BL.GetAllMenus().FirstOrDefault(c => c.Id == id);
            var menuVm = menu.ToMenuViewModel();
            return View(menuVm);
        }
    }
}
