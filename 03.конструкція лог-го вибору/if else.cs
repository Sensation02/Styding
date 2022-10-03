using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace конструкція_лог_го_вибору
{
    internal class leson
    {
        static void Main(string[] args)
        {
            //конструкція if else - умовний оператор
            /*
            if (підтвердження або вираження чогось) ..якщо щось..
                {
                дія_1 ..ми робимо щось..
                }
            else ..інакше..
                {
                дія_2 ..щось інше..
                }
            (підтвердження у форматі бул, вираження також має мати булевий результат)
            */

            //далі приклад
            Console.WriteLine("Say something");
            string word = Console.ReadLine();
            if (word == "Hello") //тобто якщо введене слово буде "Hello".. ,
                                 //в () працюють оператори відношення, порівння та логічні оператори
            {
                Console.WriteLine("Hello dear user"); //.. буде цей результат
            }
            //{} можна не писати якщо після if тільки одна строка коду, але так зазвичай не роблять тому що це не гарно
            //далі може працювати програма або:
            else //якщо якесь інакше слово..
            {
                Console.WriteLine("Who are you?"); //..буде цей результат
            }

        }
    }
}