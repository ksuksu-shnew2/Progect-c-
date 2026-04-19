namespace TaskManager;
using System;
public class TaskService
{
    public List<TaskItem> Tasks { get; private set; }

    public TaskService(List<TaskItem> tasks)
    {
        Tasks = tasks;
    }

    public void ShowTasks()
    {
        if(Tasks.Count > 0)
        {
        Console.WriteLine($"\n\n\nСписок задач:");
      for (int i = 0; i < Tasks.Count; i++)
{
    if (Tasks[i].TypePriority == TypePriority.High)
        Console.ForegroundColor = ConsoleColor.Red;

    else if (Tasks[i].TypePriority == TypePriority.Medium)
        Console.ForegroundColor = ConsoleColor.Yellow;

    else
        Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine($"{i + 1}. {Tasks[i]}");

    Console.ResetColor();
}
        }
        else Console.WriteLine($"\n\nСписок задач пуст");
    }

    

     public void DoneTasks(int number)
    {
        if(Tasks.Count > 0 && number<=Tasks.Count && number >= 1)
            {
            Tasks[number-1].IsDone = true;
            Console.WriteLine($"\n\nЗадача номер {number} выполнена");
            }
        else Console.WriteLine($"\n\nНет задач для корректировки");
        
        
    }
    public void DelDoneTasks(int number)
    {
        if(Tasks.Count > 0 && number<=Tasks.Count && number >= 1)
        {
            if(Tasks[number-1].IsDone == true)
            {
            Tasks[number-1].IsDone = false;
            Console.WriteLine($"\n\nОтметка о выполнении задачи номер {number} снята");
            }
            else Console.WriteLine($"\n\nЗадача номер {number} еще не выполнялась");
            
        }
        else Console.WriteLine($"\n\nНет задач для корректировки");
        
        
    }
     public void EditTasks(int number,string name)
    {
        if(Tasks.Count > 0 && number<=Tasks.Count && number >= 1 && !string.IsNullOrWhiteSpace(name))
            {
            Tasks[number-1].Title = name;
            Console.WriteLine($"\n\nЗадача {number} изменена");
            } 
        else Console.WriteLine($"\n\nНет задач для корректировки");
        
        
    }

     public void AddTasks(string name,int num)
    {
        TypePriority priority = (TypePriority)(num - 1);
        if(!string.IsNullOrWhiteSpace(name))
        {
        bool isDone = false; 
        Tasks.Add(new TaskItem(isDone,name,priority));
        Console.WriteLine($"\n\nЗадача добавлена");
        }
        else Console.WriteLine($"\n\nВы ввели пустую задачу");
    }

    public void  DelTasks(int number)
    {
        if(Tasks.Count > 0 && number<=Tasks.Count && number >= 1)
        {
        Tasks.RemoveAt(number-1);
        Console.WriteLine($"\n\nЗадача удалена");
        }
        else Console.WriteLine($"\n\nНет задач на удаление");
    }

    public void  Search(string text)
    {
        if(string.IsNullOrWhiteSpace(text))
        {
        Console.WriteLine($"\n\nВвели пустую строку");
        }
        
        var found = Tasks
        .Where(t => t.Title.Contains(text, StringComparison.OrdinalIgnoreCase))
        .ToList();

        if (found.Count == 0)
            {
                Console.WriteLine("Ничего не найдено");
                return;
            }
        else
        {
            Console.WriteLine("\nНайденные задачи:");

            for (int i = 0; i < found.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {found[i]}");
            }
        }
    }
    public void  FilterTrueTask()
    {
        
        var found = Tasks
        .Where(t => t.IsDone).ToList();

        if (found.Count == 0)
            {
                Console.WriteLine("Ничего не найдено");
                return;
            }
        else
        {
            Console.WriteLine("\nНайденные задачи:");

            for (int i = 0; i < found.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {found[i]}");
            }
        }
    }
    public void  FilterFalseTask()
    {
        
        var found = Tasks
        .Where(t => !t.IsDone).ToList();

        if (found.Count == 0)
            {
                Console.WriteLine("Ничего не найдено");
                return;
            }
        else
        {
            Console.WriteLine("\nНайденные задачи:");

            for (int i = 0; i < found.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {found[i]}");
            }
        
        }
    }
    public void ShowStats()
    {
    int total = Tasks.Count;
    int done = Tasks.Count(t => t.IsDone);
    int undone = total - done;

    Console.WriteLine("\n=== Статистика ===");
    Console.WriteLine($"Всего задач: {total}");
    Console.WriteLine($"Выполнено: {done}");
    Console.WriteLine($"Осталось: {undone}");
    }

    public void  SortTask()
    {
        
         Tasks = Tasks
        .OrderBy(t => t.CreatedAt)
        .ToList();

        Console.WriteLine("Задачи отсортированы по дате");
        for (int i = 0; i < Tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Tasks[i]}");
            }
    }
    public void  SortTaskPriority()
    {
        
         Tasks = Tasks
        .OrderBy(t => t.TypePriority)
        .ToList();

        Console.WriteLine("Задачи отсортированы по приоритету");
        for (int i = 0; i < Tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Tasks[i]}");
            }
    }
}
