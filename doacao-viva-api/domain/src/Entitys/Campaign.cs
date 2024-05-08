using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoacaoViva.Domain.Entitys;
public class Campaign : BaseEntity {
    [Required]
    public string? Name { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public Guid IdRequest { get; set; }
    public string? Organizer { get; set; }

    [ForeignKey("IdRequest")]
    public Request? Request { get; set; }
}

