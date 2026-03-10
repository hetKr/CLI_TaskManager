// See https://aka.ms/new-console-template for more information

using CLI_TaskManager.Models;
using CLI_TaskManager.Services;

TaskFileStorage taskFileStorage = new TaskFileStorage("tasks.json");
Console.WriteLine("Hello, World!");
TaskManager taskManager = new ();
taskManager.AddTask("New task", false, TaskPriority.Medium, new List<string> { "work", "urgent" });
taskManager.AddTask("Another task", true, TaskPriority.Low, new List<string> { "personal", "important" });
taskManager.RemoveTask(1);
Console.WriteLine(taskManager.GetTasks().Count);
taskManager.AddTask("Clean kitchen", false, TaskPriority.Medium, new List<string> { "home", "daily" });
foreach (var task in taskManager.GetTasks())
{
    Console.WriteLine(task.Title);
}

var foundTasks = taskManager.FindTasksByTitle("kitchen");

foreach (var task in foundTasks)
{
    Console.WriteLine(task.Id);
}

taskFileStorage.SaveTasks(taskManager.GetTasks());
Console.WriteLine("Tasks saved to file.");
