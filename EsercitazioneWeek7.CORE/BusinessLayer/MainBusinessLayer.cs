using EsercitazioneWeek7.CORE.Entities;
using EsercitazioneWeek7.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek7.CORE.BusinessLayer
{
    internal class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryPiatti piattiRepo;
        private readonly IRepositoryMenu menuRepo;
        private readonly IRepositoryUtenti utentiRepo;

        public MainBusinessLayer(IRepositoryPiatti piatti, IRepositoryMenu menu, IRepositoryUtenti utenti)
        {
            piattiRepo = piatti;
            menuRepo = menu;
            utentiRepo = utenti;
        }

        public Esito AggiungiMenu(Menu nuovoMenu)
        {
            menuRepo.Add(nuovoMenu);

            return new Esito { Messaggio = "Menú inserito correttamente", IsOk = true };
        }

        public Esito AggiungiPiatto(Piatto nuovoPiatto)
        {   
            piattiRepo.Add(nuovoPiatto);
            return new Esito() { IsOk = true, Messaggio = "Piatto aggiunto correttamente" };
        }

        public Esito AssegnaPiattoAlMenu(int idPiatto, int idMenu)
        {
            var piattoRecuperato = piattiRepo.GetById(idPiatto);
            var menuRecuperato = menuRepo.GetById(idMenu);
            if (piattoRecuperato == null || menuRecuperato == null )
            {
                return new Esito() { IsOk = false, Messaggio = " piatto o menú inesistente" };
            }
            if (piattoRecuperato.MenuId != null)
            {
                return new Esito() { IsOk = false, Messaggio = " il piatto fa giá parte di un menú" };
            }
            piattoRecuperato.MenuId = menuRecuperato.Id;
            piattiRepo.Update(piattoRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Piatto assegnato correttamente" };



        }

        public Esito EliminaPiatto(int id)
        {
            var piattoRecuperato = piattiRepo.GetById(id);
            if (piattoRecuperato == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessun piatto corrispondente al codice inserito" };
            }
            piattiRepo.Delete(piattoRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Piatto eliminato correttamente" };
        }

        public List<Menu> GetAllMenus()
        {
            return menuRepo.GetAll();
        }

        public List<Piatto> GetAllPiatti()
        {
            return piattiRepo.GetAll();
        }

        public Esito ModificaPiatto(int idPiatto,string nuovoNome, string nuovaDescrizione, decimal nuovoPrezzo, Tipologia nuovaTipologia)
        {
            var piattoRecuperato = piattiRepo.GetById(idPiatto);
            if (piattoRecuperato == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessun piatto corrispondente al codice inserito" };
            }
            piattoRecuperato.Nome = nuovoNome;
            piattoRecuperato.Descrizione = nuovaDescrizione;
            piattoRecuperato.Prezzo = nuovoPrezzo;
            piattoRecuperato.tipologia = nuovaTipologia;
            piattiRepo.Update(piattoRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Piatto aggiornato correttamente" };
        }

        public Esito TogliPiattoDalMenu(int idPiatto)
        {
            var piattoRecuperato = piattiRepo.GetById(idPiatto);
            if (piattoRecuperato == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessun piatto corrispondente al codice inserito" };
            }
            piattoRecuperato.MenuId = null;
            piattiRepo.Update(piattoRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Piatto eliminato dal menú" };
        }
    }
}
