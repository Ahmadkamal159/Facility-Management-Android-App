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
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;

namespace Facility_Management_App.ViewModel
{
    [QueryProperty(nameof(Facility_Management_APP.Model.Task),"Task")]
    public partial class TaskListViewModel:BaseViewModel
    {
        public ObservableCollection<Facility_Management_APP.Model.Task> Tasks { get; } = new();
        TaskServices TaskService;
        IConnectivity connectivity;
        
        public TaskListViewModel(TaskServices TaskService, IConnectivity connectivity)
        {
            Title = "Task List";
            this.TaskService = TaskService;
            this.connectivity = connectivity;
        }

        [ObservableProperty]
        bool isRefreshing;

        [ICommand]
        async Task GetTasksAsync()
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
                var tasks = await TaskService.GetUserTasks();

                if (Tasks.Count != 0)
                    Tasks.Clear();

                //foreach (var task in tasks)
                //    Tasks.Add(task);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get tasks: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }

        }

        [ICommand]
        async Task GoToTaskDetails(Facility_Management_APP.Model.Task task)
        {
            if (task is null)
                return;
            await Shell.Current.GoToAsync($"{nameof(TaskDetails)}", true, new Dictionary<string, object>
            {
                {"task",task }
            });
        }

    }
}
