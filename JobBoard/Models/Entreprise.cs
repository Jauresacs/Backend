namespace JobBoard.Models
{
    public class Entreprise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? SiteWeb {  get; set; }
        public string? Adresse { get; set; }
        public ICollection<Recruteur>? Recruteurs { get; set; }

    }
}
