using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoacaoViva.Domain.Entitys;
public class Person : BaseEntity
{
    [Required]
    public string? Name { get; set; }
    public string? Sex { get; set; }
    [Phone]
    public string? MainContact { get; set; }
    [Phone]
    public string? SecondaryContact { get; set; }
    [EmailAddress]
    public string? MainEmail { get; set; }
    [EmailAddress]
    public string? SecondaryEmail { get; set; }
    public Guid? IdAddress { get; set; }
    [ForeignKey("IdAddress")]
    public Address? Address { get; set; }
}
