using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoacaoViva.Domain.Entitys;
public class Suport : BaseEntity
{
    public string? Description { get; set; }
    [MaxLength(10)]
    public string? Abbreviation { get; set; }
    public Guid? ParentId { get; set; }
    [ForeignKey("ParentId")]
    public Suport? Parent { get; set; }
}

