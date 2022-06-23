using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facility_Management_App.Services
{
    public class AppUserServices
    {
        List<AppUser> Users = new();
        HttpClient Client;
        AppUserServices()
        {
            Client = new HttpClient();
        }
        public async Task<List<AppUser>> GetAppUsers()
        {
            return Users;
        }
    }
}
