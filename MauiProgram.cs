using Cafe.Data.Services;
using Microsoft.Extensions.Logging;
namespace Cafe;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddScoped<AuthenticationService>();
		builder.Services.AddScoped<OrderService>();
		builder.Services.AddScoped<CustomerService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif


		return builder.Build();
	}
}
