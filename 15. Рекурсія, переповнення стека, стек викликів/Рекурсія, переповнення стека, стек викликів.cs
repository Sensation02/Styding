using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _15._Рекурсія__переповнення_стека__стек_викликів
{
    /*
     *      Рекурсія - Вивід метода із самого себе
     * 
     *      Методи і стек
     * 
     *      Переповнення стека (stack overflow)
     * 
     */

    internal class leson
    {
        class Item
        {
            public int Value { get; set; }
            public Item Child { get; set; }
        } //цепочка вкладених об"єктів

        static Item InitItem()
        {
            return new Item()
            {
                Value = 5,
                Child = new Item()
                {
                    Value = 10,
                    Child = new Item()
                    {
                        Value = 2
                    }
                }
            };
        }
        static void Foo()
        {
            Console.WriteLine("Foo");
            Foo(); //виклик метода в цьому ж методі і є Рекурсія (рекурсивний виклик)
            //тобто це є деяким аналогом циклу, так як консоль буде постійно писати "Foo"

            //в дебаг режимі, в Стекі викликів, метод постійно сам себе викликає
            //від цього цей стек заповнюється, а він обмежений (все це забиває пам"ять)
            //і це може призвести до StackOverflowException (помилка переповнення стека)

            //такий цикл працює безкінечно
            //і його добре використовувати коли треба обійти якийсь список або елементів
            //які містять вкладені елементи

        }

        static void Foo2(int i)
        {
            Console.WriteLine(i); //вивід перемінної
            if (i >= 3) //умова виходу з рекурсії, без цього нею не можна користуватися
                return; //вихід 
            i++; //інкрементація
            Foo2(i); //повтор метода
        } //на виході: 0 1 2 3

        //в стекі викликів можна відслідкувати звідки що взялося
        //звідки дані, де викликався метод, де все почалося

        static void Print(Item item)
        {
            if (item != null) //не Null? йдемо далі; Null? - переривається
            {
                Console.WriteLine(item.Value); //вивід такий даних - 5, після наступного заходу - 10
                Print(item.Child); //знову заходимо в метод, після останнього - Null
            }
        }

        /// <summary>
        /// Вивід чисел масиву через рекурсію:
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        static void TestArray(int[] array, int index = 0)
        {
            if (index < array.Length) //як тільки індекс дійде до довжини масиву - вихід з рекурсії
            {
                Console.WriteLine(array[index]); //вивід числа під індексом
                TestArray(array, index + 1); //заходимо в метод і збільшуємо індекс на 1
            }
        }

        /// <summary>
        /// Вивід суми елементів масиву через рекурсію
        /// </summary>
        /// <param name="args"></param>
        static int SumArray(int[] array, int index = 0)
        {
            if (index >= array.Length)
                return 0; //на виході отримуємо 0, але цей 0 він ніби в останньому виклику метода
                          //(їх було 6, так як перший був з нашої основної програми)
                          //тобто 0 там де останній елемент масиву

            int result = SumArray(array, index + 1);
            //перераховуются всі елементи масиву, доходить до їх кількості і йде на вихід..
            //після отримання 0, в цю перемінну він був присвоєний

            return array[index] + result; //після отримання 0 ми попадаємо сюди і отримаємо 1 елемент масиву - це 90
            //чому 90? тому що вихід відбувається від останнього виклику метода,
            //тобто в даному випадку при виході все виходить навпаки
            //і з кожний спрацюванням даної строки коду буде додаватися наступний елемент масиву
            //90 + 12 + 6 + 52 + 1 = 161
        }

        static int SumArray2(int[] array, int index = 0)
        {
            if (index >= array.Length)
                return 0;
            return array[index] + SumArray2(array, index + 1); //трохи простіше
        }

        /// <summary>
        /// Метод знаходження суми цифр з числа за допомоги рекурсії: (561 = 12)
        /// </summary>
        /// <param name="args"></param>
        static int SumOfDigits(int value)
        {
            if (value < 10) //умова виходу, це число, яке зберігається у перемінній, менше за 10
                //..якщо число менше 10 то далі код не спрацьовує (після 5 не спрацьовує і виходить)
                return value; //повертає те значення
            int digit = value % 10; //зайшло 561,                         зайшло 56
                                    //на виході "1",                      потім "6"
            int nextValue = value / 10; //присвоєння перемінній числа 56, потім присвоєння 5
            return digit + SumOfDigits(nextValue); //сюди заходить 56 і повтор метода, (захід 5)
                                                   //вже після виконання умови (5<10) всі числа додаються
                                                   //до 5 до дається 6 і вже до 11 додається 1,
                                                   //вивід суми - 12
        }
        /// <summary>
        /// Метод виводу суми чисел зі строки: 
        /// </summary>
        /// <param name="value_1"></param>
        /// <returns></returns>
        static int SumOfNumbers(int value)
        {
            if (value == 0) //умова виходу коли число = 0, а воно не дорівнює і йде далі (56112)
                            //працює так як і (value < 10)
                return 0;
            return value % 10 + SumOfNumbers(value / 10); //відділення по тому ж приниципу тільки "коротше"
            //при чому тут відділення відбувається зі строки
        }


        /// <summary>
        /// Метод знаходження суми цифр з числа за допомоги рекурсії через цикл While:
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static int SumOfNumbers2(int value)
        {
            int result = 0;
            while (value != 0) // або (value > 0), число 56132
            {
                result += value % 10; //присвоюємо 2 (яку відділити від 56132), потім до 2 + 3 і присвоюємо 5,
                                      //до 5 + 1 = 6, до 6 + 6 = 12, до 12 + 5 = 17
                value /= 10; //присвоюємо 5613, потім 561, 56, 5,
                             //після того як до 12 + 5 залишається 0 і на вихід
            }
            return result; //виводимо 17
        }

        static void Main(string[] args)
        {
            Foo2(0);

            Item item = InitItem(); //присвоєння даних з класів та методів у перемінну Айтем

            //приклад рекурсії
            Print(item); //вивід даних в перемінній

            //та сама рекурсія тільки циклом
            for (Item i = item; i != null; i = i.Child)
            {
                Console.WriteLine(i.Value);
            }

            //робота з методом вивода чисел масиву через рекурсію
            int[] array = { 1, 52, 6, 12, 90 };
            TestArray(array);

            //робота з методом суми чисел масиву через рекурсію
            int result = SumArray(array);
            Console.WriteLine(result);

            //робота з методом виводу суми чисел зі строки та "взагалі суми чисел"
            string str = "561 = 12";
            string strNumbers = new String(str.Where(Char.IsDigit).ToArray());
            //..всю строку переводимо в символи, відділяємо від символів числа і присвоюємо їх назад в строку
            int result1 = SumOfNumbers(int.Parse(strNumbers));
            //..перетворюємо число в що в строці на власне числа і відправляємо їх у метод
            Console.WriteLine("Sum of numbers in {0} is : {1}", str, result); //output 15

            int number = 561;
            int result2 = SumOfDigits(number);
            Console.WriteLine("Sum of numbers {0} is {1}", number, result2); //output 12

            int number2 = 56132;
            int result3 = SumOfNumbers2(number2);
            Console.WriteLine("Sum of numbers {0} is {1}", number2, result3);
        }
    }
}