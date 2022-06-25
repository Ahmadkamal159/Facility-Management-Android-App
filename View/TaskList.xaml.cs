using Facility_Management_App.ViewModel;

namespace Facility_Management_App.View;

public partial class TaskList : ContentPage
{
	public TaskList(TaskListViewModel ViewModel)
	{
		InitializeComponent();
		BindingContext=ViewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}