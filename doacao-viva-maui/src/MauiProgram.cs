using SalveVidaDoandoApp.Configurations;
using SalveVidaDoandoApp.Repository.Login;

namespace SalveVidaDoandoApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		//FormHandler.RemoveBorders();

        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Roboto-Black", "Roboto-Black");
				fonts.AddFont("Roboto-BlackItalic", "Roboto-BlackItalic");
				fonts.AddFont("Roboto-Light", "Roboto-Light");
				fonts.AddFont("Roboto-Regular", "Roboto-Regular");
				fonts.AddFont("Roboto-Medium", "Roboto-Medium");
			});

		builder.Services.AddTransient<MainViewModel>();

		builder.Services.AddTransient<MainPage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<ListDetailDetailViewModel>();
		builder.Services.AddTransient<ListDetailDetailPage>();

		builder.Services.AddTransient<ListDetailViewModel>();

		builder.Services.AddTransient<ListDetailPage>();
		builder.Services.AddTransient<RegisterLoginPage>();
		builder.Services.AddTransient<RegisterLoginViewModel>();

		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<LoginPage>();


		builder.Services.AddScoped<ILoginRepository,LoginRepository>();

		return builder.Build();
	}
}
