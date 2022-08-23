using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculatior
{
    internal class Calculatior
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                double firstValue, secondValue;
                string action;
                Console.WriteLine("Введіть перше число, потім дію і друге число: ('+', '-', '*', '/')");
                try
                {
                    firstValue = double.Parse(Console.ReadLine());
                    action = Console.ReadLine();
                    secondValue = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Неможливо конвертувати строку в число(-а). Натисніть будь яку клавішу");
                    Console.ReadKey();
                    continue;
                }
                switch (action)
                {
                    case "+":
                        Console.WriteLine("=");
                        Console.WriteLine(firstValue + secondValue);
                        Console.WriteLine("Натисніть будь яку клавішу");
                        break;
                    case "-":
                        Console.WriteLine("=");
                        Console.WriteLine(firstValue - secondValue);
                        Console.WriteLine("Натисніть будь яку клавішу");
                        break;
                    case "*":
                        Console.WriteLine("=");
                        Console.WriteLine(firstValue * secondValue);
                        Console.WriteLine("Натисніть будь яку клавішу");
                        break;
                    case "/":
                        if (secondValue == 0)
                        {
                            Console.WriteLine(0);
                            Console.WriteLine("Натисніть будь яку клавішу");
                        }
                        else
                        {
                            Console.WriteLine("=");
                            Console.WriteLine(firstValue / secondValue);
                            Console.WriteLine("Натисніть будь яку клавішу");
                        }
                        Console.WriteLine("=");
                        Console.WriteLine(firstValue / secondValue);
                        Console.WriteLine("Натисніть будь яку клавішу");
                        break;
                    default:
                        Console.WriteLine("Помилка! Невідома дія. Натисність будь яку клавішу");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}