using System;
namespace TaskManager;

public class TaskItem
{
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }

    public TaskItem( bool isDone,string title)
    {
        Title = title;
        IsDone = isDone;
        CreatedAt = DateTime.Now;
    }

    public override string ToString()
    {
        string mark = IsDone ? "Х" : " ";
        return $"[{mark}] {Title} ({CreatedAt})";
    }
    
}
