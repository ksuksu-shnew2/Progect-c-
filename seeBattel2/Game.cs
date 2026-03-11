using System;

namespace seeBattel2;

internal enum Move
{
    Human,
    Machine
}


public class QuitToSaveException : Exception
{
}

public sealed class Game
{
    internal  Board PlayerBoard { get; set; }

    internal  Board MachineBoard { get; set; }

    internal Move CurrentMove { get; set; } = Move.Human;

    private bool _gameIsOn = true;
    
    // private  Board _playerBoard;
    // private  Board _machineBoard;

    // public Game()
    // {
    //     PlayerBoard = new Board(false); // или передать параметром в конструктор
    //     MachineBoard = new Board(true); 
    // }

    internal class QuitToSaveException : Exception { }

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

     private void New(bool isNew = true)
    {
        _gameIsOn = true;
        if (isNew)
        {
            MachineBoard = new Board(autoGenerate: true, isMachineBoard: true);
            PlayerBoard = new Board(Dialog.AutoGenerateUserBoard(), false);
        }

        while (_gameIsOn)
        {
            DoNextMove();
        }

        Start();
    }
    private void DoNextMove()
    {
        PrintBoard();
        switch (CurrentMove)
        {
            case Move.Human:
                if (!MachineBoard.HasUnbrokenCell())
                {
                    Console.WriteLine("ПОЗДРАВЛЯЕМ! ВЫ ПОБЕДИЛИ!");
                    _gameIsOn = false;
                    return;
                }
                try
                {
                    DoHumanMove();
                }
                catch (QuitToSaveException)
                {
                    _gameIsOn = false;
                }
                break;
            case Move.Machine:
                if (!PlayerBoard.HasUnbrokenCell())
                {
                    Console.WriteLine("ВЫ ПРОИГРАЛИ! Печально...");
                    _gameIsOn = false;
                    return;
                }
                DoMachineMove();
                break;
        }
    }

    private void DoMachineMove()
    {
        int coordX;
        int coordY;
        do
        {
            Random rnd = new();
            coordX = rnd.Next(0, 10);
            coordY = rnd.Next(0, 10);
        } while (!PlayerBoard.GetUnshottedCell(coordY, coordX));

        bool success = Dialog.GetHumanConfirmation(coordY, coordX);

        PlayerBoard.ChangeCellStatus(coordY, coordX, success);

        if (success)
        {
            Console.WriteLine("Компьютер попал! Снова его ход!");
            return;
        }

        CurrentMove = Move.Human;
    }

    private void DoHumanMove()
    {
        int coordY;
        int coordX;
        while (!Dialog.TryGetSingleCoord(CoordType.Single, Line.Horizontal, out coordX)
        || !Dialog.TryGetSingleCoord(CoordType.Single, Line.Vertical, out coordY))
        {
            Console.WriteLine("Введены неправильные координаты!");
        }

        if (MachineBoard.CheckHumanMove(coordY, coordX))
        {
            Console.WriteLine("Вы попали! Снова ваш ход!");
            return;
        }

        CurrentMove = Move.Machine;
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

        if (PlayerBoard == null || MachineBoard == null)
    {
        Console.WriteLine("Нет активной игры для сохранения. Сначала начните новую игру или загрузите сохранение.");
        Start();
        return;
    }
          string filePath = string.Empty;
        try
        {
            filePath = GameKeeper.Save(this);
            Console.WriteLine($"Игра успешно сохранена в файл {filePath}");
            Console.WriteLine($"Для возврата в игру загрузите этот файл в пункте 'Загрузить'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка сохранения игры в файл {filePath}.");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Start();
        }
    }

}