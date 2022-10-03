using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace типи_даних
{
    internal class leson
    {
        static void Main(string[] args)
        {
            //типи даних цілих чисел, без точки, чим більші числа тим більше ОЗУ треба:
            byte a = 255; //від 0 до 255, для конвертації: Byte
            sbyte b = -2; //від -128 до 127, для конвертації: SByte
            short c = -3421; //від -32768 до 32767, Int16
            ushort d = 42145; //від 0 до 65535, UInt16
            int e = -5321552; //від -2 міл. 147 тис. до 2 міл. 147 тис., Int32
            uint f = 6; //від 0 до 4 міл. 294 тис., UInt32
            long l = -7; //дуууже довгі числа, Int64
            ulong r = 8; //те саме тільки без від"ємних чисел, UInt64

            //далі типи даних з точкою, такі дані треба записувати через "," в коді через ".":
            float h = -9.2f; //від -3,402 у 38 степені до 3,402 у 38 степені, Single
            double g = 10.3215f; //від 1,797 у 308 степені по 1,797 у 308, Double
            decimal i = 11; //дууууже величезні числа, як і Лонг рідко де використовуються, Decimal

            //типи даних для символів:
            char coma = ','; //для всіх символів, пишеться обов"язково у '' - лапках, Char
            string s = "word"; //для слів, виразів тощо, String

            //логічні типи даних:
            bool word = true; //або правда або не правда(false), Boolean

            //далій йдуть особливі типи даних:
            object fool = "fool";
            //базовий тип даних, який є батьківським для всіх інших типів даних, може бути і цифрою або будь чим іншим, Object
            dynamic gore = "gore";
            //як і object але може змінюватися "находу"

            //ввід даних з консолі:
            Console.ReadLine(); // - строки; ReadKey() - любої клавіші, Read();
            int number = int.Parse(Console.ReadLine());
            //для вводу чисел, можна й Convert.ToInt32 замість int.Parse
            //метод Parse використовується тільки для строки

            /* Приклад вводу чисел з конвертацією у правильний тип даних
            і його виведення у консоль: */
            Console.WriteLine("enter your number");
            string number1 = Console.ReadLine();
            double num1 = Convert.ToDouble(number1);
            Console.WriteLine("your number is: " + num1);

            //ще один приклад:
            string str = "3.2dsaf"; //так не добре, далі варіант спроби конверації
            //string str = "3.2" - буде "конвертація успішна"
            try
            {
                int num2 = Convert.ToInt32(str);
                Console.WriteLine("конвертація успішна");
            }
            catch (Exception)
            {
                Console.WriteLine("конверація безуспішна");
            }

            //і ще один приклад:
            string str2 = "1.2";
            int number2;
            int.TryParse(str2, out number2);
            /*
            не викидає метод виключення помилки, тобто 1.2 прокатить,
            а якщо там будуть ще якісь символи то не прокатить,
            тільки це відбудеться без помилки 
            Метод Try.Parse повертає булевий(Bool) результат (виконано через цикл):
             */
            string str3 = "1.2 sag";
            int number3;
            bool result = int.TryParse(str3, out number3);
            if (result)
            {
                Console.WriteLine("Успіх, значення = " + number3);
            }
            else
            {
                Console.WriteLine("Безуспішно");
                //в даному випадку відповідь ця
            }

            char symbol = Console.ReadKey().KeyChar;
            //ввода чара з консолі

            //вивід даних в консоль:
            Console.WriteLine("Hello");
            //вивід строки після якої пробіл переноситься нижче рядка; Write() - не переноситься пробіл
            Console.WriteLine("the word is: " + s);
            //s написано вище, замість "s" може бути будь яка інша перемінна

            /*
             
             \t  - перенос на 1 пробіл (табуляція)
             \tt - 2 пробіла 
             \n  - перенос на 1 рядок (line feed)
             \nn - на 2 рядка
             \r  - заміняє данні що позаду тими що попереду (carriage return - повернення рядка)
             
             */

        }
    }
}