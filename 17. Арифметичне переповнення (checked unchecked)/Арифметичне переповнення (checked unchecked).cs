using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _17._Арифметичне_переповнення__checked_unchecked_
{
    /*
     * 
     *      "Ядерний Ганді" або арифметичне переповнення
     * 
     *      Переповнення бувають 
     *      через - вернхю межу
     *            - нижню межу
     * 
     *      Checked - дозволяє перевірити перетворення і видати помилку якщо йде переповнення, якщо її не ввімкнено у файлі
     *      Unchecked - не перевіряє, якщо перевірку задано у файлі
     * 
    */
    internal class leson
    {
        static void Main(string[] args)
        {
            byte aggression = 1; //агресивність Ганді
            byte democracyModifier = 2; //модифікатор на який ця агресивність має знижуватися
            aggression = (byte)(aggression - democracyModifier); //звужуюче перетворення
            //на виході 255, тобто замість того щоб знизити "агресивність" ми піднялии її до максимума
            //тобто відбулося арифметичне переповнення, а відбулося воно тому що число модифікатора
            //вище за базове значння
            Console.WriteLine(aggression);
            //в налаштуваннях можна включити опцію щоб вибивало помилку коли виникає така проблема
            //але іноді її не треба включати, для цього можна використовувати:
            //checked або unchecked в залежності що потрібно
            //в такому випадку перевірятися і вибиватися помилка буде тільки при виконанні даної строки кода
            aggression = checked((byte)(aggression - democracyModifier));

            checked //або так, якщо треба більше ніж 1 строку
            {
                aggression = (byte)(aggression - democracyModifier);
            }

            //unchecked - виключає можливіть виникнення арифметичної помилки коли це включено глобально

            int a = int.MaxValue;
            a = a + 1; //переповерння через верхню межу і в перемінній виявиться мінімальне значення яке може тут бути
            Console.WriteLine(a);

            int b = int.MinValue;
            b = b - 1; //переповнення через нижню межу - виявиться максимальне
            Console.WriteLine(b);

            try //варіант виконання програми
            {
                aggression = (byte)(aggression - democracyModifier);
                Console.WriteLine(aggression); //якщо все ок - вивід
            }
            catch (OverflowException) //якщо помилка - вивід цього:
            {
                Console.WriteLine("Stack Overflow!");
            }

            double c = 1.0 / 0.0; //це ж працює і з float
            Console.WriteLine(double.IsInfinity(c)); //якщо "безкінечність", на виході - True

            double d = 0.0 / 0.0;
            Console.WriteLine(double.IsNaN(d)); //Not a Noun - "не число", якщо не число - true

            double e = double.MaxValue + double.MaxValue;
            Console.WriteLine(double.IsInfinity); //також безкінечність

            //у випадку Decimal з ми завжди отримуємо помилку
            decimal f = decimal.MaxValue;
            decimal g = decimal.MaxValue;
            decimal h = unchecked(f + g); //навіть якщо ввели unchecked
            //такий тип даних використовується для визначення точності даних при фінансових операціях
            //або інших операціях де треба знати "точно"
        }
    }
}