using System.Globalization;
class Program
{

     static   double number;
     //static  double number2;
     static   double resultCalc = 0;
     //static  
    static void Main()
    {
        string? operation;
        double markCalc;
       
         Console.Clear();
         Console.Write("Калькулятор\n\n\n");
    

            Console.WriteLine("Введите число:");
            number = ReadDouble();
            Console.WriteLine("Введите операцию:");
            operation = Console.ReadLine()?? "";

            Calc(number,operation);
            
            
            while(true)
            {
                Console.WriteLine("Результат: " + resultCalc);
                number=resultCalc;
                Console.WriteLine("Считаем дальше? (1 - Да, 0 - Нет, хватит уже)");
                markCalc = ReadDouble();
                if(markCalc == 1)
                {
                Console.WriteLine("Введите операцию:");
                operation = Console.ReadLine()?? "";
                Calc(number,operation);
                }
                else break;
            }

            Console.ReadLine();
            Console.WriteLine("Итого: " + resultCalc);
    }

       static double ReadDouble()
    {
        double result = 0;
        while (!double.TryParse(Console.ReadLine()?.Replace(',', '.'),
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture,
                            out result))
        {
            Console.WriteLine("Вы ввели не число!");
        }
        return result;
    }

     static double Calc(double number,string operation)
    {
        double number2;
        switch (operation)
                {
                    case "+":
                        Console.WriteLine("Введите число:");
                        number2 = ReadDouble();
                        resultCalc = number + number2;
                        break;
                    case "-":
                        Console.WriteLine("Введите число:");
                        number2 = ReadDouble();
                        resultCalc = number - number2;
                        break;
                    case "*":
                        Console.WriteLine("Введите число:");
                        number2 = ReadDouble();
                        resultCalc = number * number2;
                        break;
                    case "/":
                        Console.WriteLine("Введите число:");
                        number2 = ReadDouble();
                        if (number2 == 0) { Console.WriteLine("На ноль делить нельзя!"); break; }
                        resultCalc = number / number2;
                        break;
                    default:
                        resultCalc = 0.0;
                        break;
                }
        return resultCalc;
    }
}
