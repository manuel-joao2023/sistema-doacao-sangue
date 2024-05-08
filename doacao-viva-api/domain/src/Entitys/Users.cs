using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoacaoViva.Domain.Entitys;
public class Users : BaseEntity {
    public Users()
    {
        
    }

    public Users(string? emailOrPhone, string? role, string? token, Guid idPerson) {
        EmailOrPhone = emailOrPhone;
        Role = role;
        Token = token;
        IdPerson = idPerson;
    }

    [Required]
    public string? EmailOrPhone { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? Role { get; set; }
    [NotMapped]
    public string? Token { get; set; }
    [ForeignKey("IdPerson")]
    public Person? Person { get; set; }
    public Guid IdPerson { get; set; }
}

