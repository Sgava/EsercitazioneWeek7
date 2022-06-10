using Microsoft.AspNetCore.Mvc;

namespace EsercitazioneWeek7.MVC.Controllers
{
    public class UtentiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
