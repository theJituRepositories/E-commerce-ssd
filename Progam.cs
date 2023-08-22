using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.controllers;
using TaskManager.Models.Tasks;
using TaskManagerConsole.Entities;

namespace TaskManagerConsole
{
    public class Progam
    {
        public Progam()
        {
            EFCoreDbContext context = new EFCoreDbContext();
        }
        public async static Task Main(string[] args)
        {

            await ProductController.Init();
            // Create DBContext object
            //var context = new EFCoreDbContext();
            EFCoreDbContext context = new EFCoreDbContext();
            context.Database.EnsureCreated();
            //var newTask = Tasks.CreateTask(); // Create a new task using the method
            //context.Tasks.Add(newTask); // Add the task to the context
            //context.SaveChanges(); // Save changes to the database
            // view the tasks in the database
            Console.ReadKey();
            //var taskList = Tasks.ViewTasks();
            //foreach (var task in taskList)
            //{
            //    Console.WriteLine($"TaskName: {task.TaskName} --  Category: {task.TaskCategory}");
            //}
        }




    }
}
