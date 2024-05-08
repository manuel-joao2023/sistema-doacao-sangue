namespace DoacaoViva.Application.DTOs;
public class LoginResponseDTO {
    public LoginResponseDTO()
    {
        
    }
    public LoginResponseDTO(string username, string token, Guid idPessoa, string? role) {
        Username = username;
        Token = token;
        IdPessoa = idPessoa;
        Role = role;
    }

    public string? Username { get; private set; }
    public string? Token { get; private set; }
    public string? Role { get; private set; }
    public Guid? IdPessoa { get; private set; }
}

