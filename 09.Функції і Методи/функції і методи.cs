using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Функції_і_Методи
{
    /*

    ФУНКЦІЇ І МЕТОДИ


    Модифікатор тип_значення_що_повертається назва_методу (параметри)
    {
        тіло методу
    }

    методи дозволяють позбутися дублювання коду, 
    щоб потрібний нам код ми виносили в окреме "місце" - тобто метод
    і коли нам потрібно ми звертали до того методу, а не копіювання коду
    
    тип_значення_що_повертається - результат роботи метода
    Назву методу обираємо самі або по дії що робиться
    (параметри) - сюди вкладаємо тип даних (Інт) і через пробіл назву цих даних
     тобто так: (int value_1, int value_2)

    Наприклад ці дії можна зберегти в метод:
                c = a + b;
    
    МЕТОД ОБОВ"ЯЗКВОГО МАЄ БУТИ В КЛАСІ (leson)
    ПОЗА КЛАСУ НЕ ПРАЦЮЄ


    */
    internal class leson
    {
        //простий приклад методу:
        static int Sum(int value_1, int value_2)
        {
            //int res = a + b; 
            //дані також мають повертатися у тому самому типі даних Інт в Інт ітд.
            //return res;

            return value_1 + value_2; // - коротше
        }

        static void PrintResult(int result)
        {
            Console.WriteLine("Результат: " + result);
        }
        /// <summary>
        /// Метод заповнення з консолі та іх виведення символами :
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="symbolsCount"></param>
        static void PrintLine(string symbol, uint symbolsCount)
        {
            for (int i = 0; i < symbolsCount; i++)
            {
                Console.Write(symbol);
            }
        }

        /// <summary>
        /// Метод пошуку індекса елемента в масиві і з його виводом на консоль
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static int IndexOf(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Метод з масивом який заповнюється випадковими числами:
        /// </summary>
        /// <param name="length"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        static int[] GetRandomArray(uint length, int minValue, int maxValue)
        {
            int[] myArray = new int[length];
            Random r = new Random();
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = r.Next(minValue, maxValue);
            }
            return myArray;
        }

        /// <summary>
        /// Метод зміни розміру масиву
        /// </summary>
        /// <param name="array"></param>
        /// <param name="newSize"></param>
        static void Resize<T>(ref T[] array, int newSize)
        //<T> скорочення для Дженереків що дозволяє працювати з любим типом даних (інт стрінг тощо)
        {
            T[] newArray = new T[newSize];
            for (int i = 0; i < array.Length && i < newArray.Length; i++)
                //&& i < newArray.Length - щоб уникнути помилки коли масив буде меншим того що був
                newArray[i] = array[i]; //копіювання даних старого масиву у новий 
            array = newArray; //замінюємо ссилки масивів зі старого на новий
        }

        /// <summary>
        /// Матод введення вказаних даних під вказаним індексом у масив:
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        static void ChangeElement<T>(ref T[] array, T value, int index)
        {
            T[] newArray = new T[array.Length + 1]; //масив з к-тю ел-тів на 1 більше старого
            //..тобто якщо в старому було 5 елементів, у новому буде 6
            newArray[index] = value;
            //..тут записується число якще хочемо вставити і по якому індексу
            for (int i = 0; i < index; i++)
                //цикл буде виконуватися поки не дійде до вказаного індексу
                newArray[i] = array[i];
            //присвоюється нове число
            for (int i = index; i < array.Length; i++)
                //починається від індекса який ввели і йдемо до кінця старого масиву
                newArray[i + 1] = array[i];
            //прибавляємо "1" елемент і присвоюємо дані зі старого індекса в наступний індекс
            //виходить ніби ми нове число вставили між інші числа
            //Наприклад вказуємо "10" під індексом 3, але під індексом 3 вже є "4"
            //тому замість "4" буде "10", а "4" піде на наступний індекс - 4
            //і так буде відбуватися з кожним наступний індексом і даними
            array = newArray;
            //фінальний перенос даних масиву в новий масив
        }

        /// <summary>
        /// Метод введення вказаних даних на початок масиву:
        /// </summary>
        /// <param name="args"></param>
        static void AddFirst<T>(ref T[] array, T value)
        {
            ChangeElement(ref array, value, 0);
        }

        /// <summary>
        /// Метод введення вказаних даних у кінець масиву:
        /// </summary>
        /// <param name="args"></param>
        static void AddLast<T>(ref T[] array, T value)
        {
            ChangeElement<T>(ref array, value, array.Length);
        }

        /// <summary>
        /// Метод видалення елемента з масива під вказаним індексом
        /// </summary>
        /// <param name="args"></param>
        static void RemoveElement<T>(ref T[] array, int index)
        {
            T[] newArray = new T[array.Length - 1];
            for (int i = 0; i < index; i++)
                newArray[i] = array[i];
            for (int i = index; i < array.Length; i++)
                newArray[i - 1] = array[i];
            array = newArray;
        }

        /// <summary>
        /// Метод видалення елементу на початку масиву:
        /// </summary>
        /// <param name="args"></param>
        static void RemoveFirst<T>(ref T[] array)
        {
            RemoveElement(ref array, 0);
        }

        /// <summary>
        /// Метод видалення останнього елементу масива:
        /// </summary>
        /// <param name="args"></param>
        static void RemoveLast<T>(ref T[] array)
        {
            RemoveElement<T>(ref array, array.Length - 1);
        }


        // необовязкові та обовязкові параметри метода

        static int Sum2(int value_1, int value_2, bool enableLogging = false /* int value_3 */)
        //enableLogging = false - false одразу робить цей параметр необовязковим, відповідно його можна не вказувати
        //якщо після Логіювання додати ще дані, то такий код не скомпілірується
        {
            int result = value_1 + value_2;
            if (enableLogging) //якщо тут false - то і наступний код не буде виконуватися
            {
                Console.WriteLine("value 1 = " + value_1);
                Console.WriteLine("value 2 = " + value_2);
                Console.WriteLine("result = " + result);
            }
            return result;
        }

        //названі параметри (аргументи)

        static int Sum3(int value_1, int value_2, bool enableLogging = false)

        {
            int result = value_1 + value_2;
            if (enableLogging)
            {
                Console.WriteLine("value 1 = " + value_1);
                Console.WriteLine("value 2 = " + value_2);
                Console.WriteLine("result = " + result);
            }
            return result;
        }

        static void Main(string[] args)
        //статік - модифікатор; метод - Мейн; void - пустота (нічого не приймає і нічого не повертає)
        {
            int a, b, c;
            a = int.Parse(Console.ReadLine()); //копіюється у value_1
            b = int.Parse(Console.ReadLine()); //value_2

            c = Sum(a, b);

            PrintResult(c);

            //далі ввод і вивод даних (символа) через метод (другий)
            Console.WriteLine("enter your symbol");
            string symbol = Console.ReadLine();
            Console.WriteLine("enter you symbols count");
            uint symbolsCount = uint.Parse(Console.ReadLine());
            PrintLine(symbol, symbolsCount);


            //далі метод для пошука індекса елемента месиву (тип елемента Інт) (3-й і 4-й методи)
            //..і потім повернути його в консоль

            int[] myArray = GetRandomArray(100, 10, 100);//100 - к-сть елементів; 10,100 - з числа 10 по 100
            Console.Write("enter a number you would like to find: ");
            int number = int.Parse(Console.ReadLine());
            int result = IndexOf(myArray, number);
            Console.WriteLine("we found it under index: " + result);

            //перегрузка методів - це коли один і той самий метод виконує різні дії при різних даних перемінних

            //далі робота з методом по зміні кількості елементів масиву

            int[] myArray2 = { 1, 2, 3 };

            //Array.Resize(ref myArray2, 10); 
            //команда зміни к-сті елементів масиву до 10
            //але на справді йде заміна старого масиву на новий з 10-ма елементами

            Resize(ref myArray2, 10); //звертаємося до нашого методу
            //даний метод по суті перебирає елементи старого масива і переносить їх у новий
            //збільшуючи його до 10, також можна зменшити з 3 до 2(1)

            string[] stingArray = { "Kotia", "i", "love", "you" };
            Resize(ref stingArray, 10);
            //в такому випадку стрінговий масив буде з 10 елементами
            //але тільки 4 елементи будуть мати якісь дані, решта Null


            //метод зі зміною даних в елементах масиву:

            int[] myArray3 = { 1, 2, 3, 4, 5 };

            Console.WriteLine("Цифри в масиві: "); //і перераховуються дані під індексами:
            for (int i = 0; i < myArray3.Length; i++)
                Console.WriteLine($"Число за індексом {i + 1}: " + myArray3[i] + " ");

            Console.Write("\nВведіть число яке хочете вставити: ");
            int number1 = int.Parse(Console.ReadLine() ?? "Incorrect data");
            Console.Write("\nВведіть під яким індексом має бути: ");
            int index = int.Parse(Console.ReadLine() ?? "Incorrect data");

            ChangeElement(ref myArray3, number1, index);
            //1: ссилка на наш масив; 2: данні які хочемо покласти; 3: індекс під яким ті дані будуть
            //тобто в масиві вказане число буде під таким то індексом 

            Console.Write("Резульат: ");
            for (int i = 0; i < myArray3.Length; i++)
                Console.Write(myArray3[i] + " ");

            //Метод із видаленням елемента в масиві

            Console.WriteLine("Цифри в масиві: ");
            for (int i = 0; i < myArray3.Length; i++)
            {
                Console.WriteLine($"Число за індексом {i + 1}: " + myArray3[i] + " ");
            }

            Console.Write("\nВведіть індекс який хочете видалити: ");
            int index1 = int.Parse(Console.ReadLine() ?? "Incorrect data");

            RemoveElement(ref myArray3, index1);

            Console.Write("Результат: ");
            for (int i = 0; i < myArray3.Length; i++)
            {
                Console.Write(myArray3[i] + " ");
            }

            //робота з необовязковими та обовязковими параметрами метода

            int result2 = Sum2(5, 2);
            //якщо ми не введемо 3-й необвязковий параметр, то він по стандарту буде false,
            //тобто ми Логіювання (enableLogging) не використовуємо

            int res = Sum2(5, 2, true);
            //тут ми вже ввели 3-й параметр, йде Логіювання і виводиться інформація з циклу в методі

            //робота з названими параметрами (аргументами)

            int result3 = Sum3(value_2: 10, value_1: 3); //таке написання і є "названими параметрами"

            int firstValue = 20;
            int secondValue = 30;

            int res2 = Sum3(firstValue, secondValue, enableLogging: true);
            //enableLogging:true - краще писати так, щоб бачити що відбувається в методі
            //і не бігати туди сюди по коду, виясняти що відбувається
            //int res2 = Sum3(enableLogging:true, value_2:secondValue, value_1:firstValue) - можна і так

            Console.ReadLine();
        }

    }
}
