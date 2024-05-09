namespace SalveVidaDoandoApp.Models;
public class LoginModelResponse {
    public LoginModelResponse() {
    }

    public LoginModelResponse(string? token, string? username, Guid idPessoa) {
        Token = token;
        Username = username;
        IdPessoa = idPessoa;
    }

    public string? Token { get;   set; }
    public string? Username { get; set; }
    public Guid? IdPessoa { get; set; }

}

