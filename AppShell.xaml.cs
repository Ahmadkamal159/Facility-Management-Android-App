using Facility_Management_App.View;

namespace Facility_Management_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(TaskDetails), typeof(TaskDetails));


    }
}
