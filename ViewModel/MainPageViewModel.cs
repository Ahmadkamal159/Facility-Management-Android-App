using API.Models;
using CommunityToolkit.Mvvm.Input;
using Facility_Management_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Facility_Management_App.ViewModel
{
    public partial class MainPageViewModel:BaseViewModel
    {
        AppUserServices appServices;
        public ObservableCollection<AppUser> appUsers { get; } = new();
public Command GetAppUsersCommand { get; }
        public MainPageViewModel(AppUserServices appServices, ObservableCollection<AppUser> appUsers)
        {
            this.appServices = appServices;
            this.appUsers = appUsers;


        }
        [ICommand]
        async Task GetAppUsersAsync()
        {
            if (IsBusy)
                return;
            try
            {
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
            }
        }
    }

}
