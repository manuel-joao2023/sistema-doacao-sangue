using System.ComponentModel.DataAnnotations.Schema;

namespace DoacaoViva.Domain.Entitys;
public class RequestBloodType : BaseEntity
{
    public Guid IdBloodType { get; set; }
    [ForeignKey("IdBloodType")]
    public Suport? BloodType { get; set; }
    public double? Gratification { get; set; }
    public Guid IdHospitalRequest { get; set; }
    [ForeignKey("IdHospitalRequest")]
    public HospitalRequest? HospitalRequest { get; set; }
}
