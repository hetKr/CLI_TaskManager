// See https://aka.ms/new-console-template for more information

using CLI_TaskManager.Models;
using CLI_TaskManager.Services;

namespace CLI_TaskManager;

public class Program
{
    public static void Main(string[] args)
    {
        var taskManager = new TaskManager();
        var taskFileStorage = new TaskFileStorage("tasks.json");
        
        taskManager.LoadTasks(taskFileStorage.LoadTasks());

        if (args.Length == 0)
        {
            ShowHelp();
            return;
        }
        
        string command = args[0].ToLower();

        switch (command)
        {
            case "add":
                AddTask(args, taskManager, taskFileStorage);
                break;
            default:
                ShowHelp();
                break;
        }
        
        
    }
    
    private static void ShowHelp()
    {
        Console.WriteLine("Dostępne komendy:");
        Console.WriteLine("  task add \"tytuł zadania\"");
        Console.WriteLine("  task list");
        Console.WriteLine("  task done <id>");
        Console.WriteLine("  task remove <id>");
    }

    private static void AddTask(string[] args, TaskManager taskManager, TaskFileStorage taskFileStorage)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Podaj tytuł zadania.");
            return;
        }
        
        string title = args[1];
        taskManager.AddTask(title);
        taskFileStorage.SaveTasks(taskManager.GetTasks());
        Console.WriteLine($"Dodano zadanie: {title}");
    }
}

