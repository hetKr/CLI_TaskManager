using CLI_TaskManager.Models;
using CLI_TaskManager.Services;

namespace Test_CLI_TaskManager;

[TestClass]
public class TaskFileStorageTests
{
    private string _tempFilePath;

    [TestInitialize]
    public void Setup()
    {
        _tempFilePath = Path.Combine(Path.GetTempPath(), $"tasks_test_{Guid.NewGuid()}.json");
    }

    [TestCleanup]
    public void Cleanup()
    {
        if (File.Exists(_tempFilePath))
        {
            File.Delete(_tempFilePath);
        }
    }

    [TestMethod]
    public void LoadTasks_ShouldReturnEmptyList_WhenFileDoesNotExist()
    {
        // Arrange
        var storage = new TaskFileStorage(_tempFilePath);

        // Act
        var result = storage.LoadTasks();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void SaveTasks_ShouldWriteToFile()
    {
        // Arrange
        var storage = new TaskFileStorage(_tempFilePath);
        var tasks = new List<TaskItem>
        {
            new TaskItem(1, "Test Task", false, TaskPriority.Medium, new List<string> { "tag1" }, DateTime.Now)
        };

        // Act
        storage.SaveTasks(tasks);

        // Assert
        Assert.IsTrue(File.Exists(_tempFilePath));
        string content = File.ReadAllText(_tempFilePath);
        Assert.IsFalse(string.IsNullOrWhiteSpace(content));
        Assert.IsTrue(content.Contains("Test Task"));
    }

    [TestMethod]
    public void LoadTasks_ShouldReturnSavedTasks_WhenFileExists()
    {
        // Arrange
        var storage = new TaskFileStorage(_tempFilePath);
        var originalTasks = new List<TaskItem>
        {
            new TaskItem(1, "Task 1", false, TaskPriority.High, new List<string> { "urgent" }, DateTime.UtcNow),
            new TaskItem(2, "Task 2", true, TaskPriority.Low, new List<string>(), DateTime.UtcNow)
        };
        storage.SaveTasks(originalTasks);

        // Act
        var loadedTasks = storage.LoadTasks();

        // Assert
        Assert.AreEqual(originalTasks.Count, loadedTasks.Count);
        Assert.AreEqual(originalTasks[0].Title, loadedTasks[0].Title);
        Assert.AreEqual(originalTasks[0].Priority, loadedTasks[0].Priority);
        Assert.AreEqual(originalTasks[1].Title, loadedTasks[1].Title);
        Assert.AreEqual(originalTasks[1].IsDone, loadedTasks[1].IsDone);
    }
}
