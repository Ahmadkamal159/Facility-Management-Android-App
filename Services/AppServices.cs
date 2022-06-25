using Facility_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task = Facility_Management_App.Models.Task;

namespace Facility_Management_App.Services
{
    public class AppServices
    {
        List<AppUser> Users = new();
        //List<Task> Tasks = new();
        HttpClient Client;
        AppServices()
        {
            Client = new HttpClient();

        }
        public async Task<List<AppUser>> GetAppUsers()
        {
            if (Users?.Count > 0)
                return Users;
            using var stream = await FileSystem.OpenAppPackageFileAsync("UserData.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            Users = JsonSerializer.Deserialize<List<AppUser>>(contents);
            return Users;
        }

      

    }
}
