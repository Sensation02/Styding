using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Індекси_і_діапазони
{
    internal class leson
    {
        static void Main(string[] args)
        {
            //Індекси і Діапазони (с# 8 версії - початково працює тільки на .NET Core)

            int[] myArray = { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine(myArray[myArray.Length - 1]); //останній елемент
            Console.WriteLine(myArray[^1]); //перший елемент з кінця
            //.. такий варіант краще працює з діапазонами

            int[] myArray2 = myArray[1..5]; //перший номер це початорк діапазону, другий - кінець
            //.. якщо не вказати якийсь номер то буде або починатися з самого початку
            //.. або буде йти до самого кінця

            //Далі розглянемо Індекс більше детально (індекс це також свого роду типу даних)
            Index myIndex = ^3;
            Console.WriteLine(myArray[myIndex]);
            Console.WriteLine();
            Console.WriteLine($"value {myIndex.Value} is from end {myIndex.IsFromEnd}");
            //на виході: цифра 5 (тобто 5 елемент з кінця), значення з індексу 3 (цифра за тим індексом з кінця)
            //але якщо дивитися з початку то цифра 3 за індексом "2"

            Index myIndex1 = new Index(3, true); //^3
            Console.WriteLine(myArray[myIndex]);
            Console.WriteLine();
            Console.WriteLine($"value {myIndex.Value} is from end {myIndex.IsFromEnd}");
            //тут вже розбитий індекс,тобто те саме що вище

            Range myRange = new Range(1, 4); //1..4
            int[] myArray3 = myArray[myRange];
            //те саме що і в другому прикладі
            //на виході 2 3 4 5

            //можна записати ще так:
            Range myRange1 = ^4..^1;
            int[] myArray4 = myArray[myRange1]; //[^4..^1]
            //на виході 6 5 4 3
            //тобто діапазон в якому початок з елементу під індексом 1 але з кінця по 4 індекс з кінця

            string str = "Hello World!!"; //з точки зору масива, стрінг це масив чарів (char)
            Console.WriteLine(str[0]); //отримаємо букву "Н"
            Console.WriteLine(str[^1]); //"!"
            Console.WriteLine(str[0..12]);//"Hello World!!"
        }
    }
}