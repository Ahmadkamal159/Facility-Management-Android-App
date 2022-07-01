using Facility_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Task = Facility_Management_App.Models.Task;

namespace Facility_Management_App.Services
{
    public class TaskServices
    {
        List<Task> Tasks = new();
        HttpClient Client;
        public TaskServices()
        {
            this.Client = new HttpClient();
        }
        public async Task<List<Task>> GetUserTasks()
        {
            if (Tasks?.Count > 0)
                return Tasks;

            var response = await Client.GetAsync("http://41.43.116.139:5050/taskpages/senttaskstomobapp1"); //returns u the response of the server's verb
            
            if (response.IsSuccessStatusCode)
            {
                Tasks = JsonConvert.DeserializeObject<List<Task>>(await response.Content.ReadAsStringAsync());
            }
            //use this punch of code when ur offline
            //using var stream = await FileSystem.OpenAppPackageFileAsync("TaskData.json");
            //using var reader = new StreamReader(stream);
            //var contents = await reader.ReadToEndAsync();
            //Tasks = JsonSerializer.Deserialize<List<Task>>(contents);
            return Tasks;

        }
    }
}
