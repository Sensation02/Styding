using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extension_Method;

/*
    Extension Method
    Методи розширення
        (на ньому побудований LINQ), тобто це можливість додавати функціональні можливості в класи, до яких
        ми немаємо доступу, від яких ми не можемо успадковуватися, або які запаковані (sealed)
    
    такі методи повинні бути статичними
    також під розширення створюють окремий простір імен, щоб було окреме "підключення" до нього

    коли такі методи потрібні? 
    1. Коли працюємо з якимось вбудованими стандартними даними, треба що додати до стандартних типів
    2. 

 */

namespace Extension_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter your number: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                // var isEven = IsEven(result); - треба позбутися такого варіанту запису
                // коли це метод самого класу
                // виносимо таку дію окремо в клас Extension і робимо простіше:
                
                if (result.IsEven())
                {
                    Console.WriteLine($"{result} - Even number");
                }
                else
                {
                    Console.WriteLine($"{result} - Odd number");
                }
            }
            else
            {
                Console.WriteLine("you wrote smthn dif");
            }
            Console.ReadLine();

            int num1 = 128;
            num1.isDevided(7); // чи наприклад число ділиться на 7?

            //створюємо список доріг і заповлюємо їх рандомними дорогами за допомоги нашого метода розширення
            var roads = new List<Road>();
            for (var i = 0; i < 10; i++) //10 доріг
            {
                var road = new Road(); //створюємо об"єкт дороги
                road.CreateRandomRoad(1000, 10000); //рандомна дорога
                roads.Add(road); //додаємо у список
            }1

            var roadsName = roads.ConvertToString(); //конвертуємо щоб можна було вивести на консоль
            Console.WriteLine(roadsName);
            Console.ReadLine();
            // створили розширення для нашого класу Road, з використанням якого ми можемо
            // створювати рандомну дорогу
        }
    }
}
