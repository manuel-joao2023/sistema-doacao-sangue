using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoacaoViva.Domain.Entitys;
public class Address : BaseEntity
{
    public Guid? IdCountry { get; set; }
    [ForeignKey("IdCountry")]
    public Suport? Country { get; set; }
    public Guid? IdProvince { get; set; }
    [ForeignKey("IdProvince")]
    public Suport? Province { get; set; }
    public Guid? IdCity { get; set; }
    [ForeignKey("IdCity")]
    public Suport? City { get; set; }

    [Required]
    public string? Neighborhood { get; set; }
}

