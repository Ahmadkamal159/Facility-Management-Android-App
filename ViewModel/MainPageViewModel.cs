using Facility_Management_APP.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Facility_Management_App.Services;
using Facility_Management_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using Newtonsoft.Json;

namespace Facility_Management_App.ViewModel
{
    public partial class MainPageViewModel:BaseViewModel
    {
        public ObservableCollection<AppUser> appUsers { get; } = new();
        AppServices appServices;
        IConnectivity connectivity;
        public MainPageViewModel(AppServices appServices, IConnectivity connectivity)
        {
            this.appServices = appServices;
            this.connectivity = connectivity;

        }
        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private int userid;


        [ICommand]
        async void Login()
        {
            if (IsBusy)
                return;

            //try
            //{
            //    if (connectivity.NetworkAccess != NetworkAccess.Internet)
            //    {
            //        await Shell.Current.DisplayAlert("No connectivity!",
            //            $"Please check internet and try again.", "OK");
            //        return;
            //    }

            //    IsBusy = true;
            //    var AppUserss = await appServices.GetAppUsers();
            //    //foreach (var appUser in AppUserss)
            //    //    appUsers.Add(appUser);
            //    var loggedUser = AppUserss.FirstOrDefault(user=>user.Id== userid);
            //    UserId.LoginId=loggedUser.Id;
            //    appUsers.Add(loggedUser);

            //    if (appUsers.Count != 0)
            //        appUsers.Clear();
            //    if (userid == loggedUser.Id)
            //    {

            await Shell.Current.GoToAsync($"//{nameof(TaskList)}");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine($"Unable to LOGIN: {ex.Message}");
            //    await Shell.Current.DisplayAlert("Error Username or Password are wrong!", ex.Message, "OK");
            //}
            //finally
            //{
            //    IsBusy = false;
            //    IsRefreshing = false;
            //}
            //if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
            //{
            //    var userDetails = new AppUser();
            //    userDetails.UserName = username;
            //    userDetails.UserName = "Test User Name";

            //    // SystemAdmin Role, Owner Role, Manager Role,Supervisor Role,Inspector Role,Agent Role
            //    if (Username.ToLower().Contains("admin"))
            //    {
            //        userDetails.Type = Enums.UserType.SystemAdmin;
            //    }
            //    else if (Username.ToLower().Contains("owner"))
            //    {
            //        userDetails.Type = Enums.UserType.Owner;
            //    }
            //    else if (Username.ToLower().Contains("manager"))
            //    {
            //        userDetails.Type = Enums.UserType.Manager;
            //    }
            //    else if (Username.ToLower().Contains("supervisor"))
            //    {
            //        userDetails.Type = Enums.UserType.Supervisor;
            //    }
            //    else if (Username.ToLower().Contains("inspector"))
            //    {
            //        userDetails.Type = Enums.UserType.Inspector;
            //    }
            //    else
            //    {
            //        userDetails.Type = Enums.UserType.Agent;
            //    }
            //    string userDetailStr = JsonConvert.SerializeObject(userDetails);
            //}

        }
    }
}
