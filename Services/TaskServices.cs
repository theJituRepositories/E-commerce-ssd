using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManagerConsole.Entities;

namespace TaskManager.Services
{
    public class TaskServices : ITasks
    {
    
    async  Task<ResponseService> ITasks.CreateTaskAsync(Tasks task)
        {
            try{
                var tasks = new Tasks()
                {
                    TaskName = task.TaskName,
                    TaskCategory = task.TaskCategory,
                    Description = task.Description,
                    startDate = task.startDate,
                    endDate = task.endDate
                };
                var context = new EFCoreDbContext();
                context.Tasks.Add(tasks);
                await context.SaveChangesAsync();

            }catch{

            }
            return new ResponseService { Message = "Task Created Successfully" };
        }

      

        Task<Tasks> ITasks.GetTaskAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<ResponseService> ITasks.UpdateTaskAsync(Tasks task)
        {
            throw new NotImplementedException();
        }

        Task<ResponseService> ITasks.DeleteTaskAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<List<Tasks>> ITasks.ViewTasksAsync()
        {
            throw new NotImplementedException();
        }

     
    }
}