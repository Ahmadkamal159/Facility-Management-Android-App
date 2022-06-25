using Facility_Management_App.ViewModel;

namespace Facility_Management_App.View;
public partial class TaskDetails : ContentPage
{
	public TaskDetails(TaskDetailsViewModel viewmodel)
	{

		InitializeComponent();
		BindingContext= viewmodel;
	}
}