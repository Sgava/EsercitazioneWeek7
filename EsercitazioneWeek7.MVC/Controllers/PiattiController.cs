using EsercitazioneWeek7.CORE.BusinessLayer;
using EsercitazioneWeek7.CORE.Entities;
using EsercitazioneWeek7.MVC.Helper;
using EsercitazioneWeek7.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsercitazioneWeek7.MVC.Controllers
{

    public class PiattiController : Controller
    {
        private readonly IBusinessLayer BL;

        public PiattiController(IBusinessLayer bL)
        {
            BL = bL;
        }

        public IActionResult Index()
        {
            var listaPiatti = BL.GetAllPiatti();
            var listaPiattiViewModel = new List<PiattoViewModel>();
            foreach (var piatto in listaPiatti)
            {
                listaPiattiViewModel.Add(piatto.ToPiattoViewModel());
            }
            return View(listaPiattiViewModel);
        }

        [Authorize(Policy = "adm")]
        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }

        [Authorize(Policy = "adm")]
        [HttpPost]
        public IActionResult Create(PiattoViewModel piattoViewModel)
        {
           
            if (ModelState.IsValid)
            {
                
                Piatto piatto = piattoViewModel.ToPiatto();
                Esito esito = BL.AggiungiPiatto(piatto);
                if (esito.IsOk == true)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroridiBusiness");
                }
            }
            else
            {

                return View(piattoViewModel);

            }





        }
    }
}
