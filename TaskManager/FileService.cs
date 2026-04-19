namespace TaskManager;
using System;
public class FileService
{
    static string filePath = "tasks.txt";

    public List<TaskItem> LoadTasks()
    {
    List<TaskItem> tasks = new();

    if(File.Exists(filePath))
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
        string[] parts = line.Split('|');

        if (parts.Length >= 4)
        {
        bool isDone = bool.Parse(parts[0]);
        string title = parts[1];
        DateTime created = DateTime.Parse(parts[2]);
        TypePriority typePriority = Enum.Parse<TypePriority>(parts[3]);

        tasks.Add(new TaskItem(isDone, title,typePriority)
        {
            CreatedAt = created
        });
    }
}
    }

    return tasks;
    }
    public void SaveTasks(List<TaskItem> tasks)
    {
    List<string> lines = new();

    foreach(TaskItem task in tasks)
    {
        lines.Add($"{task.IsDone}|{task.Title}|{task.CreatedAt}|{task.TypePriority}");
    }

    File.WriteAllLines(filePath, lines);
    }
    
}
