
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using TaskManager.Models.Tasks;
using TaskManagerConsole.Entities;

namespace TaskManager.Services
{
    public class TaskServices : ITasks
    {

        public async Task<ResponseService> CreateTaskAsync(Tasks task)
        {
            try
            {
                var newTask = new Tasks()
                {
                    Id = task.Id,
                    TaskName = task.TaskName,
                    TaskCategory = task.TaskCategory,
                    Description = task.Description,
                    startDate = task.startDate,
                    endDate = task.endDate
                };

                var context = new EFCoreDbContext();
                context.Tasks.Add(newTask);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception
                return new ResponseService { Message = ex.Message };
            }

            return new ResponseService { Message = "Task Created Successfully" };
        }




        public async Task<Tasks> GetTaskAsync(int id)
        {
            try
            {
                var context = new EFCoreDbContext();
                var results = await context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
                return results;
            }
            catch
            {
                throw new Exception("No entry in the database.");
            }
        }


        public async Task<ResponseService> UpdateTaskAsync(Tasks task)
        {
            try
            {
                var context = new EFCoreDbContext();
                var taskToUpdate = context.Tasks.FirstOrDefault(x => x.Id == task.Id);
                if (taskToUpdate != null)
                {
                    taskToUpdate.startDate = task.startDate;
                    taskToUpdate.endDate = task.endDate;
                    await context.SaveChangesAsync(); // Save changes to the database
                }
                else
                {
                    throw new Exception("Task not found in the database.");
                }

                // Return a response indicating success
                return new ResponseService {Message = "Task updated successfully." };
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating task: " + ex.Message);
            }
        }


        public Task<ResponseService> DeleteTaskAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tasks>> ViewTasksAsync()
        {
            throw new NotImplementedException();
        }

    }
}