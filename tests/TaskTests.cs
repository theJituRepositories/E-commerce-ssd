using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TaskManager.Models;
using TaskManager.Models.Tasks;
using TaskManager.Services;
using TaskManagerConsole.Entities;

namespace TaskManager
{
    [TestFixture]
    public class AddTaskTests_Should_Return_Message
    {
        private  Mock<ITasks> _mockTaskService;
        [SetUp]
        public void Setup()
        {
            _mockTaskService = new Mock<ITasks>();
        }

        [Test]
        public async Task AddTask_Should_Return_Message()
        {
            //Arrange
            var task = new Tasks()
            {
                TaskName = "Task1",
                TaskCategory = "TaskCategory1",
                Description = "Description1",
                startDate = DateTime.Now,
                endDate = DateTime.Now
            };
            _mockTaskService.Setup(x => x.CreateTaskAsync(task)).ReturnsAsync(new ResponseService { Message = "Task Created Successfully" });
            var taskService = new TaskServices();
            //Act
            var result = await _mockTaskService.Object.CreateTaskAsync(task);
            //Assert
            Assert.AreEqual("Task Created Successfully", result.Message);
        }

    }
}