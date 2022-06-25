using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Facility_Management_App.ViewModel;

namespace Facility_Management_App.ViewModel
{
    [QueryProperty("Task", "Task")]
    public partial class TaskDetailsViewModel : BaseViewModel
    {
        public TaskDetailsViewModel()
        {

        }
        [ObservableProperty]
        Facility_Management_App.Models.Task task;
    }
}