namespace CLI_TaskManager.Models;

public class TaskItem(int id, string title, bool isDone, TaskPriority priority, List<string> tags, DateTime createdAt)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public bool IsDone { get; set; } = isDone;
    public TaskPriority Priority { get; set; } = priority;
    public List<string> Tags { get; set; } = tags;
    public DateTime CreatedAt { get; set; } = createdAt;
}