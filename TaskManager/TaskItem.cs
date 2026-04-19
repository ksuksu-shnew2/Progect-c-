using System;
namespace TaskManager;

public class TaskItem
{
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }

    public TypePriority TypePriority { get; set; }

    public TaskItem( bool isDone,string title,TypePriority typePriority)
    {
        Title = title;
        IsDone = isDone;
        CreatedAt = DateTime.Now;
        TypePriority = typePriority;
    }

    public override string ToString()
    {
        string mark = IsDone ? "Х" : " ";
        return $"[{mark}] {Title} ({CreatedAt}) ({TypePriority})";
    }
    
}
