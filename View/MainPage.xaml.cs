using Facility_Management_App.ViewModel;

namespace Facility_Management_App;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel ViewModel)
	{
		InitializeComponent();
		BindingContext= ViewModel;
	}
}