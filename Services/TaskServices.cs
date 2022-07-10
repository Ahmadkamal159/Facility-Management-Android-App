using Task=Facility_Management_APP.Model.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facility_Management_APP.Model;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Text.Json.Serialization;
//using Newtonsoft.Json.Linq;

namespace Facility_Management_App.Services
{
    public class TaskServices
    {
        List<Task> Tasks;
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
                var TheTasks = await response.Content.ReadFromJsonAsync<List<Task>>();//reads the return from the servers and translates it to the punch of ur tasks
                 Tasks = TheTasks.Where(task => task.AssignedToId == UserId.LoginId).ToList();
                //////////////////var result = await response.Content.ReadAsStringAsync();
                ////////////////// var mylist = JsonConvert.DeserializeObject<List<Task>>(result);
                ////////////////// Tasks = mylist;
            }
            //use this punch of code when ur offline
            //using var stream = await FileSystem.OpenAppPackageFileAsync("taskdata.json");
            //using var reader = new StreamReader(stream);
            //var contents = await reader.ReadToEndAsync();
            //Tasks = JsonSerializer.Deserialize<List<Task>>(contents);
            return Tasks;
        }
    }
}