namespace SalveVidaDoandoApp.Views;

public partial class RegisterLoginPage : ContentPage
{
    RegisterLoginViewModel viewModel;
    public RegisterLoginPage( RegisterLoginViewModel registerLogin)
	{
		InitializeComponent();
        BindingContext = viewModel = registerLogin;
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e) {
        viewModel.IsDoador = e.Value;
    }
}