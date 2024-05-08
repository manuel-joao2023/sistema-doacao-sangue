using System.ComponentModel.DataAnnotations.Schema;

namespace DoacaoViva.Domain.Entitys;
public class HospitalRequest : BaseEntity {
    public Guid IdHospital { get; set; }

    [ForeignKey("IdHospital")]
    public Suport? Hospital { get; set; }
    public Guid? IdRequest { get; set; }
    [ForeignKey("IdRequest")]
    public Request? Request { get; set; }
    public IEnumerable<RequestBloodType>? RequestBloodTypes { get; set; }
}

