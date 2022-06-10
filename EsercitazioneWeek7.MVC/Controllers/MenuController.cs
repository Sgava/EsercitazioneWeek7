using Microsoft.AspNetCore.Mvc;

namespace EsercitazioneWeek7.MVC.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
