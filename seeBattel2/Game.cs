using System;

namespace seeBattel2;

public class Game
{
    public void Start()
    {
        GameState userChoice;
       // while(true)
       do 
        {
    
    PrintMenu();
    userChoice = ValidateInput();
    switch(userChoice)
            {
                case GameState.Quit:
                Quit();
                break;
                case GameState.New:
                New();
                break;
                case GameState.Load:
                Load();
                break;
                case GameState.Save:
                Save();
                break;
                default:
                break;
            }
    
    }  while  (userChoice == GameState.Menu);
    }

    private void Quit()
    {
        Console.WriteLine("Exit");
    }

    private void New()
    {
        Console.WriteLine("Скоро будет");
    }

    private void Load()
    {
        Console.WriteLine("Будет потом");
    }

    private void Save()
    {
        Console.WriteLine("Будет потом");
    }

    private  GameState ValidateInput()
    {
        string? userInput = Console.ReadLine();

    if(string.IsNullOrWhiteSpace(userInput)
       || !int.TryParse(userInput, out int userChoice)
       || userChoice < (int)GameState.Quit
       || userChoice > (int)GameState.Save)
    {
        Console.WriteLine("Неправильный ввод! Введите число от 0 до 3");
        return GameState.Menu;
    }
    return (GameState)userChoice;
    }

    private void PrintMenu()
    {
        Console.WriteLine("\n1. Новая игра");
        Console.WriteLine("2. Загрузить игру");
        Console.WriteLine("3. Сохранить игру");
        Console.WriteLine("0. Выход\n");
        Console.WriteLine("Ваш выбор: ");
    }
}
