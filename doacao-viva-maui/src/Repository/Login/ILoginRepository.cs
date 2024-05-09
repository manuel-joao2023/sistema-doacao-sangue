namespace SalveVidaDoandoApp.Repository.Login;

public interface ILoginRepository
{
    Task<LoginModelResponse> Login(LoginModelRequest request);
}
