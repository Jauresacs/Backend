using Org.BouncyCastle.Asn1.Crmf;
using System.ComponentModel.DataAnnotations;
using System.Data;

public class Job
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }

    public string Category {get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string JobType { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public decimal Salary { get; set; }
    [Required]
    public DateTime PostedDate { get; set; } = DateTime.Now;
    public int? RecruteurId { get; set; }
    [Required]
    public string Status { get; set; } //"Active", "Expired"
}