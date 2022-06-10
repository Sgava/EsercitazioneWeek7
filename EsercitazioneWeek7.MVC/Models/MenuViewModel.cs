using EsercitazioneWeek7.CORE.Entities;
using System.ComponentModel.DataAnnotations;

namespace EsercitazioneWeek7.MVC.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public ICollection<PiattoViewModel>? Piatti { get; set; } = new List<PiattoViewModel>();  
    }
}
