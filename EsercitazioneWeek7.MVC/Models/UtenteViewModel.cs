using EsercitazioneWeek7.CORE.Entities;
using System.ComponentModel.DataAnnotations;

namespace EsercitazioneWeek7.MVC.Models
{
    public class UtenteViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
        [Required]
        public Ruolo Ruolo { get; set; }
    }
}
