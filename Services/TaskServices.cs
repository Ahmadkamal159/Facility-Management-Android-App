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
    public class TaskServices
    {
        List<Task> Tasks = new();
        HttpClient Client;
        TaskServices()
        {
            Client = new HttpClient();

        }
        public async Task<List<Task>> GetUserTasks()
        {
            if (Tasks?.Count > 0)
                return Tasks;
            using var stream = await FileSystem.OpenAppPackageFileAsync("TaskData.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            Tasks = JsonSerializer.Deserialize<List<Task>>(contents);
            return Tasks;

        }
    }
}
