namespace SalveVidaDoandoApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ListDetailDetailPage), typeof(ListDetailDetailPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		Routing.RegisterRoute(nameof(RegisterLoginPage), typeof(RegisterLoginPage)); 
		Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage)); 
	}
}
