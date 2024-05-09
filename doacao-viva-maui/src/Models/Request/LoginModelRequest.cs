namespace SalveVidaDoandoApp.Models;
public class LoginModelRequest {
    public LoginModelRequest() {
    }

    public LoginModelRequest(string? username, string? password) {
        Username = username;
        Password = password;
    }

    public string? Username { get; private set; }
    public string? Password { get; private set; }

}

