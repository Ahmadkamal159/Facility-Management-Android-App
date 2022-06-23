using Facility_Management_App.ViewModel;

namespace Facility_Management_App;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel mainPageViewModel)
	{
		InitializeComponent();
		BindingContext= mainPageViewModel;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		
	}
}