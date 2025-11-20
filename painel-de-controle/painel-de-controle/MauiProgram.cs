using Microsoft.Extensions.Logging;

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
<<<<<<< HEAD
		//registra o viewmodel e a página principal para injeção de dependência
		builder.Services.AddSingleton<MeusConteudosViewModel>();
        builder.Services.AddSingleton<MainPage>();
=======
>>>>>>> parent of 1a8a0d4 (painel de controle)

		return builder.Build();
	}
}
