﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek7.CORE.Entities
{
    public enum Tipologia 
    {
        primo=0,
        secondo=1,
        contorno=2,
        Dolce=3
    }

    public class Piatto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Tipologia tipologia { get; set; }
        public decimal Prezzo { get; set; }
 
        public int? MenuId { get; set; }
        public Menu? Menu { get; set; }
    }
}
