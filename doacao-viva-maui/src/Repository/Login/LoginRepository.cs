namespace SalveVidaDoandoApp.Repository.Login;

public class LoginRepository : ILoginRepository {
    public async Task<LoginModelResponse?> Login(LoginModelRequest request)
        => await SendRequestService.PostRequestAsync<LoginModelRequest, LoginModelResponse>(request, "/Users/login");
       
}
