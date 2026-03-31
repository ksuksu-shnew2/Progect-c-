namespace VendingApp;

using System;


public enum PaymentType
{
    Card,
    Coins
}

public enum Command
{
    AddMoney,
    GetChange,
    BuyGood
}
class Program
{

        static int balance = 0;
        static int[] coinsQuantity = { 0, 0, 0, 0}; //1, 2, 5, 10
        static int[] coinsValues  = { 1, 2, 5, 10}; 
        //static int payment;
        //static int countF;
        //static List<int> countList = new List<int> ();
        static string[] names = { "Шоколадка", "Газировка" };
        static int[] prices = { 70, 60 };
        static int[] availableQuantity = { 5, 2 };
        //static int command;
    static void Main()
    {
        
    while (true)
    {

    StartConfig();
    
    Console.WriteLine("Введите команду(0 - AddMoney; 1 - GetChange; 2 - BuyGood):");
    int command = ReadInt();//int.Parse(Console.ReadLine());
    if (!Enum.IsDefined(typeof(Command), command))
{
    Console.WriteLine("Неверная команда.");
    Console.ReadLine();
    continue;
}
    Command cmd = (Command)command;


    

    if(cmd == Command.AddMoney)
    
    //switch (payType)
    {
        AddMoney();
    }
    
    else if(cmd == Command.GetChange)
    {
        balance = 0;
    }
    else if (cmd == Command.BuyGood)//(command.StartsWith("BuyGood"))
    {
        Buy();
    }
               
    else
    {
        Console.WriteLine("Команда не определена");
    }

    Console.ReadLine();
}

}

    static void StartConfig()
    {
        Console.Clear();
        Console.WriteLine($"Баланс {balance}");
        for (int i = 0; i < names.Length && i < availableQuantity.Length; i++)
        {
            Console.WriteLine($"Остатки по товару {names[i]} = {availableQuantity[i]}");
        }
    }

    static int ReadInt()
    {
        int result = 0;
        while (!int.TryParse(Console.ReadLine(),
                    out result))
        {
            Console.WriteLine("Вы ввели не число!");
        }
        return result;
    }

    static void AddMoney()
    {
        //if(cmd == Command.AddMoney)
        //{
        Console.WriteLine("Введите способ пополнения: 0 - Card; 1 - Coins");
      //  }
        int payment = ReadInt();
        PaymentType payType = (PaymentType)payment;
        switch (payType)
        {
            case PaymentType.Coins:
                for(int i = 0; i < coinsValues.Length; i++)
                {
                    Console.WriteLine($"Сколько монет номиналом {coinsValues[i]} вы хотите внести?");
                    int count = ReadInt();
                    coinsQuantity[i] += count;
                    balance += count * coinsValues[i];
                }
                Console.WriteLine($"Итого ваш баланс: {balance}");
                break;
            case PaymentType.Card:
                Console.WriteLine("Сколько снять с вашей карты?");
                int balanceDelta = ReadInt();
                balance += balanceDelta;
                Console.WriteLine($"Баланс успешно пополнен\nИтого ваш баланс: {balance}");
                //Console.WriteLine($"Итого ваш баланс: {balance}");
                break;
            default:
                Console.WriteLine("Неверный способ оплаты.");
                break;
        
    }
    }

    static void Buy()
    {
        List<int> countList = new List<int> ();
       foreach (var name in names)
        {
        Console.WriteLine($"Введите количество товара {name}: ");
        int countF = ReadInt();

        countList.Add(countF);
        }


        for (int i = 0; i < countList.Count && i < availableQuantity.Length; i++)
            {
                Console.WriteLine($"Информируем Вы хотите купить товар {names[i]} в количестве {countList[i]} при остатке {availableQuantity[i]}");
                
                if(countList[i] < 0 || countList[i] > availableQuantity[i])
                    {
                    Console.WriteLine($"Товара {names[i]}  нет в таком количестве. Доступно {availableQuantity[i]}"); 
                    continue;   //break;
                    }
                    //if(countList[i] <= availableQuantity[i])
                    //{
                    // //Выполнение
                        if(balance >= prices[i] * countList[i])
                        {
                            balance -= prices[i] * countList[i];
                            availableQuantity[i] -= countList[i];

                        Console.WriteLine($"Вы купили товар {names[i]} в количестве {countList[i]} штук. Ваш баланс составляет {balance}");
                        }
                        else
                        {
                            Console.WriteLine("Не достаточно средств на балансе");
                            break;
                        }
                    //}
            }
        countList.Clear();
    }

    
}