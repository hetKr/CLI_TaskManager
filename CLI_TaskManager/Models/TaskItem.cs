namespace CLI_TaskManager.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; } = false;
    public TaskPriority Priority { get; set; } = TaskPriority.Low;
    public List<string> Tags { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public TaskItem() { }

    public TaskItem(int id, string title, bool isDone = false, TaskPriority priority = TaskPriority.Low, List<string>? tags = null, DateTime? createdAt = null)
    {
        Id = id;
        Title = title;
        IsDone = isDone;
        Priority = priority;
        Tags = tags ?? new List<string>();
        CreatedAt = createdAt ?? DateTime.Now;
    }
}