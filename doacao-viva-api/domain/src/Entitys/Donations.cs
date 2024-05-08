using System.ComponentModel.DataAnnotations.Schema;

namespace DoacaoViva.Domain.Entitys;
public class Donations : BaseEntity
{
    public Guid? IdDonator { get; set; }
    [ForeignKey("IdDonator")]
    public Donator? Donator { get; set; }

    public DateTime? DonationDate { get; set; }
    public int QtdMl { get; set; }
}

