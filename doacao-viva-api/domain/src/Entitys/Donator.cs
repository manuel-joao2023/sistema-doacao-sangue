using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoacaoViva.Domain.Entitys;
public class Donator : BaseEntity
{
    public Guid IdPerson { get; set; }
    [ForeignKey("IdPerson")]
    public Person? Person { get; set; }
    public Guid IdBloodType { get; set; }
    [ForeignKey("IdBloodType")]
    public Suport? BloodType { get; set; }
    public string?  RhFactor { get; set; }
    [Required]
    [Range(18, 70)]
    public int Age { get; set; }
    public IEnumerable<DonatorHospital>? DonatorHospital { get; set; }
}

