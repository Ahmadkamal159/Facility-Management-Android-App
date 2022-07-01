<<<<<<< HEAD
﻿using Facility_Management_App.Models;
using Newtonsoft.Json;
=======
﻿using Facility_Management_APP.Model;
>>>>>>> 2d393b7f8297d548c24599827089e5a9f8170f3f
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
        //List<Task> Tasks = new();
        HttpClient Client;
        
        public AppServices()
        {
            this.Client = new HttpClient();
        }
        public async Task<List<AppUser>> GetAppUsers()
        {
            //if (Users?.Count > 0)
            //
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue ("application/json"));
            var ResponseMessage = await Client.GetAsync("http://41.43.116.139:5050/Account/MobileUsers");
            if (ResponseMessage.IsSuccessStatusCode) return null;
            var jasonResult=await ResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var Users = JsonConvert.DeserializeObject<IEnumerable<AppUser>>(jasonResult);
            return Users.ToList();
            //if (response.IsSuccessStatusCode)
            //{
            //    Users = await response.Content.ReadFromJsonAsync<List<AppUser>>();
            //    return Users;
            //}
            //lets me login and use app offline
            //using var stream = await FileSystem.OpenAppPackageFileAsync("UserData.json");
            //using var reader = new StreamReader(stream);
            //var contents = await reader.ReadToEndAsync();
            //Users = JsonSerializer.Deserialize<List<AppUser>>(contents);
            //return Users;
        }
    }
}
