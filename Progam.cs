using Microsoft.EntityFrameworkCore;
using TaskManager.Models.Tasks;
using TaskManager.Services;
using TaskManagerConsole.Entities;

namespace TaskManagerConsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Create DBContext object
            var context = new EFCoreDbContext();
            context.Database.EnsureCreated();

            //CREATE A NEW TASK
            //var newTask = new Tasks()
            //{


            //    TaskName = "Server configuration",
            //    TaskCategory = "Servers",
            //    Description = "setting up a new server",
            //    startDate = DateTime.Now,
            //    endDate = DateTime.Parse("2023-01-01")
            //};
            //CREATE A TASK USING RAW SQL
            //var sql = @"INSERT INTO Tasks 
            //       (TaskName, TaskCategory, Description, startDate, endDate) 
            //       VALUES 
            //        ( 'Setting Up Bussiness Logic', 'Business', 'Setting up the business logic ', '2021-01-01', '2023-01-01')";
            //await context.Database.ExecuteSqlRawAsync(sql);

            var taskService = new TaskServices();
            //var response = await taskService.CreateTaskAsync(newTask);
            //Console.WriteLine(response.Message);
            // CREATING A TASK USING PARAMETERIZED QUERY 
            //var sql1 = @"INSERT INTO Tasks ( TaskName, TaskCategory, Description, startDate, endDate) 
            //                VALUES ({0}, {1}, {2}, {3}, {4})";
            //await context.Database.ExecuteSqlRawAsync(sql1,  "Setting Up Microservice", "Backend", "Setting up the microservice Architecture ", "2021-01-01", "2023-01-01");
            //var response = await taskService.CreateTaskAsync(newTask);
            //CREATE A TASK USING STORED PROCEDURE
            //var sql2 = "EXECUTE CreateTask {0} ,{1}, {2}, {3}, {4} ";
            //await context.Database.ExecuteSqlRawAsync(sql2, "Setting Up The Test Environment ", "Testing", "Setting up the Test environment", "2021-01-01", "2023-01-01");
            //get a task using fromsql method
            //var task = await context.Tasks.FromSqlRaw("SELECT * FROM Tasks WHERE Id = {0}", 1).FirstOrDefaultAsync();
            //Console.WriteLine($"{task.Id} {task.TaskName} {task.TaskCategory} {task.Description}");
            //get a task using fromsqlinterpolated method
            //var id = 1;
            //var task = await context.Tasks.FromSqlInterpolated($"SELECT * FROM Tasks WHERE Id = {id}").FirstOrDefaultAsync();
            //Console.WriteLine($"{task.Id} {task.TaskName} {task.TaskCategory} {task.Description}");
            //get a task using the sqlQuery method
            //var task =  context.Database.SqlQuery("SELECT * FROM Tasks");
            // GET A TASK
            Console.WriteLine("Would you like to get a task");
            var getTask = Console.ReadLine();
            if (getTask == "yes")
            {
                try
                {
                    Console.WriteLine("Enter the Id of the task you would like to get");
                    var id = Console.ReadLine();
                    // parse the id to int 
                    int taskId;
                    if (int.TryParse(id, out taskId))
                    {
                        var task = await taskService.GetTaskAsync(taskId);
                        Console.WriteLine($"{task.Id} {task.TaskName} {task.TaskCategory} {task.Description}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Would you like to update a task");
            var updateTask = Console.ReadLine();
            if (updateTask == "yes")
            {
                try
                {
                    Console.WriteLine("Enter the Id of the task you would like to update");
                    var id = Console.ReadLine();
                    // parse the id to int 
                    int taskId;
                    if (int.TryParse(id, out taskId))
                    {
                        var task = await taskService.GetTaskAsync(taskId);
                        Console.WriteLine($"{task.Id} {task.TaskName} {task.TaskCategory} {task.Description} {task.startDate} {task.endDate}");
                        Console.WriteLine("Enter the new end date for the task");
                        var newTaskEndDate = Console.ReadLine();
                        Console.WriteLine("Enter the new start date for the task");
                        var newTaskEndDateDate = Console.ReadLine();
                        if (DateTime.TryParse(newTaskEndDateDate, out DateTime newStartDate) && DateTime.TryParse(newTaskEndDate, out DateTime newEndDate))
                        {
                            task.endDate = newEndDate;
                            task.startDate = newStartDate;

                        }
                        else
                        {
                            Console.WriteLine("Invalid Date");
                        }
                        var response = await taskService.UpdateTaskAsync(task);
                        Console.WriteLine(response.Message);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // UPDATE TASKS USING RAW SQL 
            // var sql2 = "UPDATE Tasks SET TaskName = 'Setting Up The Development Environment' WHERE Id = 4";
            // await context.Database.ExecuteSqlRawAsync(sql2);

        }


    }
}
