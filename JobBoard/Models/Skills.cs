namespace JobBoard.Models
{
    public class Skills
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Niveau { get; set; }
        public int UserId { get; set; }
    }
}
