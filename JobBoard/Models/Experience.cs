namespace JobBoard.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string? TitrePoste { get; set; }
        public string? NameEntreprise { get; set; }
        public string? TitrePosteType { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string? Description { get; set; } 
    }
}
