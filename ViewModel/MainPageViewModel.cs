using Facility_Management_App.Models;
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
        [ICommand]
        async Task GetAppUsersAsync()
        {
            if (IsBusy)
                return;
            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }
                IsBusy = true;
                var users=await appServices.GetAppUsers();
             if(users.Count != 0)
                    users.Clear();
             foreach(var user in users)
                    users.Add(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error",$"unable to reach users{ex.Message}","ok");
                 
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;


        [ICommand]
        async void Login()
        {
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

            await Shell.Current.GoToAsync($"//{nameof(TaskList)}");
        }
    }
}
