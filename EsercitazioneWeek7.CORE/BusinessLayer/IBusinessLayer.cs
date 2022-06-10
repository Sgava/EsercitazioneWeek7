using EsercitazioneWeek7.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek7.CORE.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<Piatto> GetAllPiatti();

        Esito AggiungiPiatto(Piatto nuovoPiatto);
        Esito ModificaPiatto(int idPiatto,
                             string nuovoNome,
                             string nuovaDescrizione,
                             decimal nuovoPrezzo,
                             Tipologia nuovaTipologia
                             );
        Esito EliminaPiatto(int id);


        List<Menu> GetAllMenus();
        Esito AggiungiMenu(Menu menu);
        Esito AssegnaPiattoAlMenu(int idPiatto, int idMenu);
        Esito TogliPiattoDalMenu(int idPiatto);
        Utente GetAccount(string username);


    }
}
