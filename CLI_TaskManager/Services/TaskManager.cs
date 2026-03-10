namespace CLI_TaskManager.Services;
using Models;


public class TaskManager
{
    private readonly List<TaskItem> _tasks = new ();
    private int _nextId = 1;
    public void AddTask(string title, bool isDone, TaskPriority priority, List<string> tags)
    {
        var task = new TaskItem(_nextId++,title, isDone, priority, tags, DateTime.Now);
        _tasks.Add(task);
    }
    public List<TaskItem> GetTasks() => _tasks;
    public void RemoveTask(int id) => _tasks.Remove(_tasks.Find(t => t.Id == id) ?? throw new Exception("Task not found"));
    
    public IEnumerable<TaskItem> FindTasksByTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) return Enumerable.Empty<TaskItem>();
        return _tasks.Where(t => t.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
    }
    
}