using System.Text.Json;
using CLI_TaskManager.Models;

namespace CLI_TaskManager.Services;

public class TaskFileStorage
{
    private readonly string _filePath;
    public TaskFileStorage(string filePath)
    {
        _filePath = filePath;
    }

    public List<TaskItem> LoadTasks()
    {
        if (!File.Exists(_filePath))
        {
            return new List<TaskItem>();
        }
        
        string json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }
    
    public void SaveTasks(List<TaskItem> tasks)
    {
        string json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(_filePath, json);
    }
}