using Microsoft.AspNetCore.Mvc;

namespace EsercitazioneWeek7.MVC.Controllers
{
    public class PiattiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
