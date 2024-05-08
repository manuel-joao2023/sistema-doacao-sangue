using DoacaoViva.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoacaoViva.Domain.Entitys;
public class Request : BaseEntity
{
    public Guid? IdPersonRequest { get; set; }
    [ForeignKey("IdPersonRequest")]
    public Person? Person { get; set; }
    public DateTime? RequestDate { get; set; } = DateTime.Now;  
    public RequestStatus RequestStatus { get; set; }
    public IEnumerable<HospitalRequest>? Hospitals { get; set; }

}

