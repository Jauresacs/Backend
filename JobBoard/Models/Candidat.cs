namespace JobBoard.Models
{
    public class Candidat
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? CvUrl { get; set; }
        public string Role { get; set; } = "Candidat";

        // Propriété de navigation
        public User? User { get; set; }
        public ICollection<Education>? Educations { get; set; }
        public ICollection<Skills>? Competences { get; set; }
        public ICollection<Experience>? Experiences { get; set; }
        public ICollection<Candidature>? Candidatures { get; set; }
    }
}
