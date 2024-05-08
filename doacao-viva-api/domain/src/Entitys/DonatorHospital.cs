using System.ComponentModel.DataAnnotations.Schema;

namespace DoacaoViva.Domain.Entitys;
public class DonatorHospital : BaseEntity
{
    public Guid IdHospital { get; set; }
    [ForeignKey("IdHospital")]
    public Suport? Hospital { get; set; }
    public Donator? Donator { get; set; }
}