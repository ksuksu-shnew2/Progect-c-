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
            Console.WriteLine($"{i+1}. {Tasks[i]}");
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

     public void AddTasks(string name)
    {
        if(!string.IsNullOrWhiteSpace(name))
        {
        bool isDone = false; 
        Tasks.Add(new TaskItem(isDone,name));
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
}
