using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek7.CORE.Entities
{
    public enum Ruolo
    {
        Administrator = 0,
        User = 1
    }

    public class Utente
    {
       
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public Ruolo Ruolo { get; set; }
       
    }
}
