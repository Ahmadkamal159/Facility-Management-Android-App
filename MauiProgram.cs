using Facility_Management_App.Services;
using Facility_Management_App.View;
using Facility_Management_App.ViewModel;
namespace Facility_Management_App;

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
		
		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);


		builder.Services.AddSingleton<AppServices>();//sevices
        builder.Services.AddSingleton<MainPageViewModel>();//viewmodel
        builder.Services.AddSingleton<MainPage>();//view

		builder.Services.AddSingleton<TaskServices>();
        builder.Services.AddSingleton<TaskListViewModel>();
        builder.Services.AddSingleton<TaskList>();

		builder.Services.AddTransient<TaskDetailsViewModel>();
        builder.Services.AddTransient<TaskDetails>();
        return builder.Build();
	}
}
