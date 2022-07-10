using Facility_Management_APP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task = Facility_Management_APP.Model.Task;

namespace Facility_Management_App.Services
{
    public class AppServices
    {
        List<AppUser> Users = new();
        HttpClient Client;
        
        public AppServices()
        {
            this.Client = new HttpClient();
            
        }
        public async Task<List<AppUser>> GetAppUsers()
        {
            if (Users?.Count > 0)
                return Users;
            var response = await Client.GetAsync("http://41.43.116.139:5050/Account/LoginTomobApp1");
            if (response.IsSuccessStatusCode)
            {
                Users = await response.Content.ReadFromJsonAsync<List<AppUser>>();
            }
            //lets me login and use app offline
            //using var stream = await FileSystem.OpenAppPackageFileAsync("UserData.json");
            //using var reader = new StreamReader(stream);
            //var contents = await reader.ReadToEndAsync();
            //Users = JsonSerializer.Deserialize<List<AppUser>>(contents);
            return Users;
        }
    }
}
