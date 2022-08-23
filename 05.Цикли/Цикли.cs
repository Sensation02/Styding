using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    internal class leson
    {
        static void Main(string[] args)
        {
            //While
            //виконує дію циклічно поки не виконається дія в дужках
            //в даному випадку зациклений "такий собі калькулятор"
            //тобто всі дії в ньому будуть повторюватися від першої строки до останньої
            //в дужках може бути й інша умова
            //наприклад: до 1 буде + 1 поки не дійде до 100 тощо,
            //тобто будь яка дія може бути зациклена

            while (true)
            {
                Console.Clear(); //очищуємо консоль
                Console.WriteLine("Enter your first number");
                double num1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter your second number");
                double num2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Chose what to do with it: +, -, *, / or %");
                string action = Console.ReadLine();
                switch (action) //через світч реалізуємо власне калькулятор, де кожен кейс - дія
                {
                    case "+":
                        Console.WriteLine("you result is: ");
                        Console.WriteLine(num1 + num2);
                        break;
                    case "-":
                        Console.WriteLine("you result is: ");
                        Console.WriteLine(num1 - num2);
                        break;
                    case "*":
                        Console.WriteLine("you result is: ");
                        Console.WriteLine(num1 * num2);
                        break;
                    case "/": //не забуваємо що на 0 ділити неможна)
                        if (num2 == 0)
                        {
                            Console.WriteLine("Unrecognized action!");
                        }
                        else
                        {
                            Console.WriteLine("you result is: ");
                            Console.WriteLine(num1 / num2);
                        }
                        break;
                    case "%":
                        Console.WriteLine("you result is: ");
                        Console.WriteLine(num1 % num2);
                        break;
                    default:
                        Console.WriteLine("unrecognized action");
                        break;
                }
                Console.ReadKey(); //після нажаття будь якої клавіші цикл While повторюється
            }

            //DO WHILE
            //такий самий як WHILE тільки трішки навпаки
            //спочатку виконується дія потім перевіряється умова і повтор

            do
            {
                Console.Clear(); //очищуємо консоль
                Console.WriteLine("Enter your first number");
                double num3 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter your second number");
                double num4 = double.Parse(Console.ReadLine());
                Console.WriteLine("Chose what to do with it: +, -, *, / or %");
                string action1 = Console.ReadLine();
                switch (action1) //через світч реалізуємо власне калькулятор, де кожен кейс - дія
                {
                    case "+":
                        Console.WriteLine("you result is: ");
                        Console.WriteLine(num3 + num4);
                        break;
                    case "-":
                        Console.WriteLine("you result is: ");
                        Console.WriteLine(num3 - num4);
                        break;
                    case "*":
                        Console.WriteLine("you result is: ");
                        Console.WriteLine(num3 * num4);
                        break;
                    case "/": //не забуваємо що на 0 ділити неможна))
                        if (num4 == 0)
                        {
                            Console.WriteLine("Unrecognized action!");
                        }
                        else
                        {
                            Console.WriteLine("you result is: ");
                            Console.WriteLine(num3 / num4);
                        }
                        break;
                    case "%":
                        Console.WriteLine("you result is: ");
                        Console.WriteLine(num3 % num4);
                        break;
                    default:
                        Console.WriteLine("unrecognized action");
                        break;
                }
                Console.WriteLine("Tap any key");
                Console.ReadKey();
            } while (true);

            //FOR
            //"прокачаний цикл WHILE"
            //таке ж завдання як і в попередніх циклах
            //зручно використовувати як лічильник або для використавння в масивах (далі буде)
            //Перша секція (і = 0) - тут ми задаємо значення перемінній, лічильник циклу
            //Другай секція (i < lenght) - це те що треба буде міняти (це умова виконання циклу)
            //Третя секція - це те що буде робитися для виконання умови
            //всі ці секції повторюються допоки не виконається умова

            Console.WriteLine("enter length number");
            int length = int.Parse(Console.ReadLine());
            for (int u = 0; u < length; u++) //початок тут, проходить 1 раз і це буде 1-й рядок(на 2 раз визначається має бути 2-й рядок)
            {
                for (int j = 0; j <= u; j++) //далі йде сюди і також виконується 1 раз (на 2 раз пишеться 2 символи)
                {
                    Console.WriteLine('@'); //при цьому виконується це ("малюється" 1 символ)
                }
                Console.WriteLine(); //і вже після циклу виконується це (перехід на новий рядок)
            }

            //в даному випадку намалюється трикутник
            for (int а = 0; а < length; а++) //довжина наприклад 5 рядків
            {
                for (int j = 0; j <= length; j++) //визначається кількість символів у рядку, все це робиться по перемінній що ми задаємо з консолі
                {
                    Console.Write('@'); //ну власне визначається що буде писатися
                }
                Console.WriteLine(); //без цього рядочка все написане буде в лінію, тобто 5 раз по 5 символів
            }

            //вже буде прямокутник
            for (int с = 0; с < length; с++)
            {
                for (int j = 0; j <= length; j++)
                {
                    Console.Write('@');
                }
                Console.WriteLine(); 
            }

            //далі різні варіації роботи з циклом

            int i = 0; //винесли перемінну поза цикл, тоді вона буде у всіх циклах де буде вказано
            for (; i < 5; i++) //даний цикл відпрацює 5 разів
            {
                Console.WriteLine("1 ");
            }
            for (; i < 6; i++) //... при чому цикли будуть виконуватися по більшому числу (6>5), цей тільки 1 развиконається
            {
                Console.WriteLine("2 ");
            }
            //на виході - 1 1 1 1 1 2

            for (int f = 0; f < 5;) //так цикл ніколи не виконається тому що 0 ніколи не дійде до 5
            {
                Console.WriteLine(f);
            }
            //на виході безкінечно висвічуватимуться 0 (нулі)

            for (int g = 0; g < 5;)
            {
                Console.WriteLine(g);
                g++; //інкремент можна внести всередину циклу
            }
            //на виході буде 0 1 2 3 4

            for (int j = 0; j < length; j++)
            {
                j++; //так само всередину
                Console.WriteLine(j);
            }
            //на виході вже буде 1 2 3 4 5
            //тобто в попередньому варіанті буде спочатку виніс значення в консоль і потім додавання 1
            //в другому варіанті спочатку до перемінної додається 1 і вже потім виводиться


            //варіант з двома перемінними
            for (int k = 0, l = 10; k < 5; k++, l--) //виконується по 5 раз
            {
                Console.WriteLine("k: " + k); //поки не дійде від 10 до 6
                Console.WriteLine("l: " + l); //поки не дійде від 0 до 4
            }

            //з використанням логічних операторів
            for (int k = 0, l = 10; k < 5 && l > 6; k++, l--) //виконується поки L не буде 7, далі цикл закінчується (виконається 8 раз)
            {
                Console.WriteLine("k: " + k); 
                Console.WriteLine("l: " + l); 
            }

            //цикл "назад"
            //в першій секції тоді виставляємо від скількох буде виконуватися (від 5)
            //в другій секції скільки треба (не більше 0)
            //в третій дія (назад - то треба --)
            for (int o = 5; o >= 0; o--)
            {
                Console.WriteLine(o);
            }
            //на виході 5 4 3 2 1 0

            //Вкладені цикли
            for (int q = 1; q <= 3; q++)
            { //спершу проходить цей цикл 1 раз; і знову повтореться коли наступні цикли "пройдуть"
                Console.WriteLine("цикл 1 ітерація №: "+q); 
                for (int w = 1; w <= 4; w++) //далі цей 
                {
                    Console.WriteLine("\tцикл 2 ітерація №: " + w);
                    for (int k = 1; k <= 2; k++)
                    { //далі цей 2 раз і потім повертається до попереднього
                        Console.WriteLine("\t\tцикл 3 ітерація №: " + k);
                    }
                }
            }

            //FOREACH
            //foreach (елемент in колекції) {все що нам треба зробити}
            //дуже зручний при роботі з колекціями, він простіший чим цикл for

            short[] nums = {5, 6, 7, 8, 4, 3, 2};
            foreach (short el in nums)
            {
                Console.WriteLine($"El: {el}"); //і виводяться елементи масиву
            }

            short[,] nums2 =
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 }
            };
            foreach (short el in nums)
            {
                Console.WriteLine($"El: {el}"); 
                //і виводяться елементи масиву (навіть якщо це двовимірний масив)
            }

            List<int> numbers = new List<int>() { 1, 2, 3 };
            foreach (int el in numbers)
            {
                Console.WriteLine($"El: {el}"); //знову перечислюємо елементи
            }

            char[] chars = "it's all ok".ToCharArray();
            foreach (char item in chars)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(item.ToString());
                Thread.Sleep(50);
                //кожні 50мс прописується в рядок одна буква(вона ж символ), зеленим кольором)
            }

            //сортування цифр в масиві на парні та непарні
            int[] myArrayNumbers = Enumerable.Range(0, 10).ToArray();
            foreach (int evenNumbersArray in myArrayNumbers.Where(i => i % 2 == 0))
                Console.WriteLine($"{evenNumbersArray} ");
            Console.WriteLine("\n");
            foreach (int oddNumbersArray in myArrayNumbers.Where(i => i % 2 != 0))
                Console.WriteLine($"{oddNumbersArray} ");
            Console.WriteLine("\n");
            //далі даний цикл буде ще розглядатися окремо (кожний foreach це for але простіше))

            

            Console.ReadLine();
        }
    }
}
