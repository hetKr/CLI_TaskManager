namespace Test_CLI_TaskManager;
using CLI_TaskManager.Services;
using CLI_TaskManager.Models;

[TestClass]
public sealed class TaskManagerTests
{
    [TestMethod]
    public void AddTask_ShouldAddNewTaskToList()
    {
        var taskManager = new TaskManager();
        taskManager.AddTask("test",false,TaskPriority.High,new List<string> { "test" , "test2"});
        Assert.IsTrue(taskManager.GetTasks().Any(t => t.Title == "test"));
        Assert.AreEqual(1,taskManager.GetTasks().Count);
        
    }

    [TestMethod]
    public void AddTask_WithDefaultValues_ShouldSetCorrectDefaults()
    {
        // Arrange
        var taskManager = new TaskManager();

        // Act
        taskManager.AddTask("Default Task");

        // Assert
        var task = taskManager.GetTasks().First();
        Assert.AreEqual("Default Task", task.Title);
        Assert.IsFalse(task.IsDone);
        Assert.AreEqual(TaskPriority.Low, task.Priority);
        Assert.IsNotNull(task.Tags);
        Assert.AreEqual(0, task.Tags.Count);
    }
}