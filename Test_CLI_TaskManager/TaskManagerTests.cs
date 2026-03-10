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
}