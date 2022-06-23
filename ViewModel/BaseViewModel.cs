using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Facility_Management_App.ViewModel
{
   public partial class BaseViewModel:ObservableObject
    {
        public BaseViewModel()
        {
          
        }
        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(IsNotBusy))]
        bool isBusy;
        [ObservableProperty]
        string title;

    public bool IsNotBusy => !IsBusy;
    }
}

