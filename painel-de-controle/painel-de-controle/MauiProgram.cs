using Microsoft.Extensions.Logging;
using painel_de_controle.ViewModels;

namespace painel_de_controle;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		//registra o viewmodel e a página principal para injeção de dependência
		builder.Services
			.AddSingleton<MeusConteudosViewModel>()
			.AddSingleton<MainPage>();
		return builder.Build();
	}
}
