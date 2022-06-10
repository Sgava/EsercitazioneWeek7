using EsercitazioneWeek7.CORE.Entities;
using System.ComponentModel.DataAnnotations;

namespace EsercitazioneWeek7.MVC.Models
{
    public class PiattoViewModel
    {

        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Tipologia tipologia { get; set; }
        [Required]
        public decimal Prezzo { get; set; }

        public int? MenuId { get; set; }
        public Menu? Menu { get; set; }
    }
}
