namespace DoacaoViva.Application.Auth;
public interface IAuth {
      string GenerateJwtToken(string emailOrPhone, string role);
      string GeneretaHashPassword(string password);
}

