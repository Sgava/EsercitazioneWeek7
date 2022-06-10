using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek7.CORE.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nome { get; set; }    
        public ICollection<Piatto>? Piatti { get; set; }


        public float Somma()
        {
            float sum=0;
            foreach(var piatto in Piatti)
            {
                sum += (float)piatto.Prezzo;
            }
            return sum;
        }
    }
}
