using JobBoard.Models;
using System.ComponentModel.DataAnnotations;

namespace JobBoard.Models
{
    public class User{
        public string? Role { get; set; }
        public int Id { get; set; }

        [Required]
        public string? Nom { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(8)]
        public string PasswordHash { get; set; }

        public DateTime DateInscription { get; set; } = DateTime.Now;

        // Navigation properties for Candidat and Recruteur
        public Candidat ?Candidat { get; set; }
        public Recruteur? Recruteur { get; set; }

    }
}