using System.ComponentModel.DataAnnotations;

namespace TestFinale.Entities
{
    public class Utente
    {
        [Key]
        public int UtenteId { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string NomeUtente { get; set; }

    }
}
