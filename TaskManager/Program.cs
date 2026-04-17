using System;
using System.Globalization;
using static System.Globalization.CultureInfo;
namespace TaskManager;

class TaskItem
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
class Program
{
    static string filePath = "tasks.txt";
    static void Main()
    {
        int numberMenu;
        string NameTask;
        int numTask;
        
        List<TaskItem> tasks = LoadTasks();
        Console.Clear();
        while(true)
        {
        PrintMenu();
        numberMenu = ReadInt();
        if (numberMenu == 1) 
        {
                ShowTasks(tasks);
        }
        else if (numberMenu == 2) 
        {
        Console.WriteLine($"\n\n\nВведите задачу.");
        NameTask = Console.ReadLine();
        AddTasks(tasks,NameTask);
        SaveTasks(tasks);
        }
        else if (numberMenu == 3) 
        {
        Console.WriteLine($"\n\n\nВведите номер задачи для удаления.");
        numTask = ReadInt();
        DelTasks(tasks,numTask);
        SaveTasks(tasks);
        }
        else if (numberMenu == 4) 
        {
        Console.WriteLine($"\n\n\nВведите номер задачи для отметки выполнения.");
        numTask = ReadInt();
        DoneTasks(tasks,numTask);
        SaveTasks(tasks);
        }
        else if (numberMenu == 5) 
        {
        Console.WriteLine($"\n\n\nВведите номер задачи для снятия отметки о выполнении.");
        numTask = ReadInt();
        DelDoneTasks(tasks,numTask);
        SaveTasks(tasks);
        }
        else if (numberMenu == 6) 
        {
        Console.WriteLine($"\n\n\nВведите номер задачи для редактирования.");
        numTask = ReadInt();
        Console.WriteLine($"\n\n\nВведите новое наименование задачи");
        NameTask = Console.ReadLine();
        EditTasks(tasks,numTask,NameTask);
        SaveTasks(tasks);
        }
        else break;
       
        }
    }
    internal static void PrintMenu()
    {
        Console.WriteLine("\n\n\n=== Менеджер задач ===");
        Console.WriteLine($"1. Показать все задачи");
        Console.WriteLine($"2. Добавить задачу");
        Console.WriteLine($"3. Удалить задачу");
        Console.WriteLine($"4. Отметить задачу выполненной");
        Console.WriteLine($"5. Снять отметку выполнения");
        Console.WriteLine($"6. Редактировать задачу");
        Console.WriteLine("0. Выход\n");
        Console.WriteLine("Ваш выбор: ");
    }

    internal static void ShowTasks(List<TaskItem> taskList)
    {
        if(taskList.Count > 0)
        {
        Console.WriteLine($"\n\n\nСписок задач:");
        for (int i = 0; i < taskList.Count; i++)
        {
            Console.WriteLine($"{i+1}. {taskList[i]}");
        }
        }
        else Console.WriteLine($"\n\nСписок задач пуст");
    }

    internal static void DoneTasks(List<TaskItem> taskList,int number)
    {
        if(taskList.Count > 0 && number<=taskList.Count && number >= 1)
            {
            taskList[number-1].IsDone = true;
            Console.WriteLine($"\n\nЗадача номер {number} выполнена");
            }
        else Console.WriteLine($"\n\nНет задач для корректировки");
        
        
    }

     internal static void DelDoneTasks(List<TaskItem> taskList,int number)
    {
        if(taskList.Count > 0 && number<=taskList.Count && number >= 1)
        {
            if(taskList[number-1].IsDone == true)
            {
            taskList[number-1].IsDone = false;
            Console.WriteLine($"\n\nОтметка о выполнении задачи номер {number} снята");
            }
            else Console.WriteLine($"\n\nЗадача номер {number} еще не выполнялась");
            
        }
        else Console.WriteLine($"\n\nНет задач для корректировки");
        
        
    }

    internal static void EditTasks(List<TaskItem> taskList,int number,string name)
    {
        if(taskList.Count > 0 && number<=taskList.Count && number >= 1 && !string.IsNullOrWhiteSpace(name))
            {
            taskList[number-1].Title = name;
            Console.WriteLine($"\n\nЗадача {number} изменена");
            } 
        else Console.WriteLine($"\n\nНет задач для корректировки");
        
        
    }
    internal static void AddTasks(List<TaskItem> task,string name)
    {
        if(!string.IsNullOrWhiteSpace(name))
        {
        bool isDone = false; 
        task.Add(new TaskItem(isDone,name));
        Console.WriteLine($"\n\nЗадача добавлена");
        }
        else Console.WriteLine($"\n\nВы ввели пустую задачу");
    }

    internal static void  DelTasks(List<TaskItem> task,int number)
    {
        if(task.Count > 0 && number<=task.Count && number >= 1)
        {
        task.RemoveAt(number-1);
        Console.WriteLine($"\n\nЗадача удалена");
        }
        else Console.WriteLine($"\n\nНет задач на удаление");
    }

    static int ReadInt()
    {
        int result = 0;
        while (!int.TryParse(Console.ReadLine()?.Replace(',', '.'),
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture,
                            out result))
        {
            Console.WriteLine("Вы ввели не число!");
        }
        return result;
    }

    static List<TaskItem> LoadTasks()
    {
    List<TaskItem> tasks = new();

    if(File.Exists(filePath))
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
        string[] parts = line.Split('|');

        if (parts.Length >= 3)
        {
        bool isDone = bool.Parse(parts[0]);
        string title = parts[1];
        DateTime created = DateTime.Parse(parts[2]);

        tasks.Add(new TaskItem(isDone, title)
        {
            CreatedAt = created
        });
    }
}
    }

    return tasks;
    }
    static void SaveTasks(List<TaskItem> tasks)
    {
    List<string> lines = new();

    foreach(TaskItem task in tasks)
    {
        lines.Add($"{task.IsDone}|{task.Title}|{task.CreatedAt}");
    }

    File.WriteAllLines(filePath, lines);
    }
}


