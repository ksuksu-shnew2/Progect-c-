using System;

namespace seeBattel2;

public sealed class Game
{
    internal Board PlayerBoard { get; set; }

    internal Board MachineBoard { get; set; }
    // private  Board _playerBoard;
    // private  Board _machineBoard;

    public Game()
    {
        PlayerBoard = new Board(false); // или передать параметром в конструктор
        MachineBoard = new Board(true); 
    }

    public void Start()
    {
        GameState userChoice;
       // while(true)
       do 
        {
    
    Dialog.PrintMenu();
    userChoice = Dialog.ValidateInput();
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
        // _playerBoard = new Board(false);
        // _machineBoard = new Board(true);

        PlayerBoard = new Board(false);
        MachineBoard = new Board(true);
        PrintBoard();
    }

    private void PrintBoard()
    {
        Console.WriteLine("Ваша доска\n");
        PlayerBoard.Print();
        Console.WriteLine("\nДоска компьютера\n");
        MachineBoard.Print();
    }

    private void Load()
    {
        Console.WriteLine("Будет потом");
    }

    private void Save()
    {
        Console.WriteLine("Будет потом");
    }

}
