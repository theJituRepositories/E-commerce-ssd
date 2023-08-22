using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManagerConsole.Entities;

namespace TaskManager.Services
{
    public interface ITasks
    {
        public Task<ResponseService> CreateTaskAsync(Tasks task);
        public Task<Tasks> GetTaskAsync(string id);
        public Task<ResponseService> UpdateTaskAsync(Tasks task);
        public Task<ResponseService> DeleteTaskAsync(string id);

        public Task<List<Tasks>> ViewTasksAsync();

    }
}