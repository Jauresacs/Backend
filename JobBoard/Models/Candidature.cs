namespace JobBoard.Models
{
    public class Candidature
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JobId { get; set; }
        public DateTime DateCandidature { get; set; }= DateTime.Now;
        public string? Statut { get; set; }
    }
}
