using maui_to_do.Services;
using maui_to_do.ViewModels;

namespace maui_to_do;

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

		var dbPath = Path.Combine(FileSystem.AppDataDirectory, "ActionItems.db3");
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<ActionItemRepository>(s, dbPath));
        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

		return builder.Build();
	}
}
