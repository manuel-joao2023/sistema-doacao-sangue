using System.Windows.Input;

namespace SalveVidaDoandoApp.Views;

public partial class LoginPage : ContentPage
{
	
    public LoginPage( LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}