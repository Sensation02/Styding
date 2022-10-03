using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _20._Enum
{
    /*
     *      ENUM - перечислення або список констант які зв"язані певною логікою 
     *      і мають певний номер (цілі числа - int)
     *      все це робиться для зручності
     *      ...при написанні програми коли треба нажимати визначену клавішу
     * 
     * 
     */
    internal class leson
    {
        enum DayOfWeek : byte//опис власного ENUM
        {
            Monday = 1, //якщо не вказувати цифру для кожного "слова" то лічення починається з 0
            Tuesday, //якщо вказати номер, то наступні визначення будуть приймати наступну цифру
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        enum Color
        {
            White,
            Red,
            Green,
            Blue,
            Orange
        }
        /// <summary>
        /// Отрмуємо наступний день
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        static DayOfWeek GetNextDay(DayOfWeek day)
        {
            if (day < DayOfWeek.Sunday) //заходить цифра дня, якщо ця цифра менша за 7 (неділя)..
                return day + 1; //до числа додається 1 (наприклад понеділок 1 ще + 1 = 2 це вівторок, вивід)
            return DayOfWeek.Monday;
        }
        static void Main(string[] args)
        {

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key; //ConsoleKey та .Key - це і є Enum
                int keyCode = (int)key; //тут отримуємо цифру яка відповідає нажатій клавіші і присвоюємо в перемінну
                Console.WriteLine($"\tEnum {key}\tKey Code {keyCode}"); //виводимо клавішу та її код
                if (key == ConsoleKey.Enter) //вивод при нажиманні Ентер
                {
                    Console.WriteLine("You entered key Enter");
                }
                //користь у цьому випадку полягає в тому, що кожна клавіша має свій номер,
                //і Enum дозволяє нам працювати з клавішою без запам"ятовування того номеру
            }

            DayOfWeek dayOfWeek = DayOfWeek.Monday;
            Console.WriteLine(Enum.GetUnderlyingType(typeof(DayOfWeek)));
            //typeof - отримуємо тип даних - це Enum, GetUnderlyingType - вивід того типу даних
            Console.WriteLine(dayOfWeek);
            Console.WriteLine((int)dayOfWeek); //переводимо DayOfWeek в int - 1
            Console.WriteLine((DayOfWeek)3); //переводимо int в DayOfWeek - Wednesday
            DayOfWeek nextDay = GetNextDay(dayOfWeek); //отримуємо настувний день
            Console.WriteLine(nextDay); //вівторок

            //після того як ми отримали інформацію про тип даних її можна змінити, її взагалі можна змінити
            //наприклад з int в byte, для економії пам"яті, це робиться в самому Enum
            //Enum DayOfWeek :byte

            DayOfWeek dayOfWeek1;
            int value = 55;
            dayOfWeek1 = (DayOfWeek)value; //DayOfWeek = 55
            if (Enum.IsDefined(typeof(DayOfWeek), value)) //IsDefined перевіряє чи є 55 в нашому ENUM і якщо true - вивід даних
            {
                dayOfWeek1 = (DayOfWeek)value; //переводимо int в DayOfWeek
            }
            else //якщо false
            {
                throw new Exception("Invalid DayOfWeek value.");
            }
            Console.WriteLine(dayOfWeek1);

            //ENUM можна парсити (Parse)
            string str = Console.ReadLine(); //наприклад ввели "Red"
            Color color = (Color)Enum.Parse(typeof(Color), str, ignoreCase: true);
            //Enum.Parse(тип_даних_який_передаємо(намагаємося парсити), Строка_яку_парсимо, ігнор_великих_та_малих_букв
            Console.WriteLine(color); //вивід того кольору який написали, якщо написали що не будь - помилка

            switch (color) //сюди передаємо параметр в залежності від якого будуть виконуватися певні дії (кейс)
                           //як тільки вставляємо color далі кейси формуються самі
            {
                case Color.White: //всередину пишемо код який ми хочемо щоб виконувався
                    //наприклад коли пишемо White виконується "написали такий то колір" тощо, що завгодно
                    break;
                case Color.Red:
                    break;
                case Color.Green:
                    break;
                case Color.Blue:
                    break;
                case Color.Orange:
                    break;
                default:
                    break;
            }
        }
    }
}