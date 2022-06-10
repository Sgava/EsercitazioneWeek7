using EsercitazioneWeek7.CORE.BusinessLayer;
using EsercitazioneWeek7.CORE.Entities;
using EsercitazioneWeek7.MVC.Helper;
using EsercitazioneWeek7.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EsercitazioneWeek7.MVC.Controllers
{
    [Authorize]
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
            LoadViewBag();
            return View();
        }

        [Authorize(Policy = "adm")]
        [HttpPost]
        public IActionResult Create(PiattoViewModel piattoViewModel)
        {
            LoadViewBag();
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

        [Authorize(Policy = "adm")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(s => s.Id == id);
            var piattoVm = piatto.ToPiattoViewModel();
            return View(piattoVm);
        }


        [Authorize(Policy = "adm")]
        [HttpPost]
        public IActionResult Delete(PiattoViewModel piattoVm)
        {
            if (ModelState.IsValid)
            {

                Esito esito = BL.EliminaPiatto(piattoVm.Id);
                if (esito.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroriDiBusiness");
                }
            }

            return View(piattoVm);
        }



        private void LoadViewBag()
        {
            ViewBag.Tipologia = new SelectList(new[] {
                                                         new{Value=0, Text="Primo"},
                                                         new{Value=1, Text="Secondo"},
                                                         new{Value=2, Text="Contorno"},
                                                         new{Value=3, Text="Dolce"}
                                                        }.OrderBy(x => x.Text), "Value", "Text");

        }

    }
}
