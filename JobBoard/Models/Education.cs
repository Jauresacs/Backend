namespace JobBoard.Models
{
    public class Education
    {
        public int Id { get; set; }
        public int CandidatId { get; set; } // Clé étrangère pour lier à un candidat
        public string? Institution { get; set; }
        public string? Diplome { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string? Description { get; set; }

        // Propriété de navigation vers le candidat
        public Candidat? Candidat { get; set; }
    }
}
