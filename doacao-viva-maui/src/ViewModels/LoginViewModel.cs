using SalveVidaDoandoApp.Repository.Login;

namespace SalveVidaDoandoApp.ViewModels;
public partial class LoginViewModel : BaseViewModel {

    [ObservableProperty] string? username;

    [ObservableProperty] string? password;

    private readonly ILoginRepository _loginRepositor;

    public LoginViewModel(ILoginRepository loginRepository)
    {
        _loginRepositor = loginRepository;
    }

    [RelayCommand]
    public async Task Routes(string route) {
        await Shell.Current.GoToAsync($"//{route}");
    }

    [RelayCommand]
    public async Task Login() {
        if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Username)) {
            await Shell.Current.DisplayAlert("Waring","Username ou password incorreta","Ok");
        }else {
            var loginRequest = new LoginModelRequest(username, password);
            var result = await _loginRepositor.Login(loginRequest);
            if (result != null && !string.IsNullOrEmpty(result.Token)) {
                await Shell.Current.GoToAsync($"//MainPage");
            } else {
                await Shell.Current.DisplayAlert("Waring", "Username ou password incorreta", "Ok");
            }
            
        }
    }
}
