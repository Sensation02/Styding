using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _14._OUT
{
    /*
     * 
     *      Ключове слово OUT, IN, params
     *      
     *      Різниця між REF та OUT
     *      
     *      а вони однакові за винятком одного моменту
     *      
     *      OUT - гарантує(обовязково) виведення даних, що передавалися модифікатором всередині метода
     *      
     *      IN - показує дані але забороняє з ними працювати
     *      
     *      params - дозволяє передавати будь яку кількість даних
     *      
     *      
     * 
     */
    internal class leson
    {
        static void TestMethod(ref int value)
        { //в перемінній, тут, не обовязково мають бути присвоєні дані
            value++;
            Console.WriteLine(value);
        }
        static void TestMethod2(out int value)
        { //з використанням OUT ми обовязково маємо присвоїти перемінній дані 
            value = 5 * 2;
            Console.WriteLine(value);
        }
        static void TestMethod3(in int value)
        {
            Console.WriteLine(value);
            value = 2--; //помилка
        }

        struct Point //це точка в 3Д просторі
        {
            public double x;
            public double y;
            public double z;
        }
        static void TestMethodPoint(Point value) //тут всі дані будуть копіюватися з Point, а це багато пам"яті (зараз це десь 12 байт)
        { //але чим більше даних тим більше пам"яті і це може зайняти дуже багато часу

        }
        static void TestMethodPoint2(in Point value) //тут використовується ссилка на дані, а це значно менше пам"яті
        { //але на ці дані можна тільки "подивитися, чіпати їх неможна"

        }

        static int TestMethod4(params int[] parameters) //можна передавати різну к-сть параметрів, записується обов"язково вкінці
                                                        //..тобто, наприклад: string word, params int [] parameters - буде помилкою
                                                        //2 params не може бути!!
        { //метод виконує дію додавання чисел, через додавання їх у масив
            int result = 0;
            for (int i = 0; i < parameters.Length; i++)
            {
                result += parameters[i]; //тут додавання
            }
            return result;
        }

        static void TestMethod5(params object[] parameters) //масив із різною кількістю даних
        {
            string message = "data type {0}, data {1}";
            foreach (var item in parameters)
            {
                Console.WriteLine(message, item.GetType(), item);
                //меседж - передає власне меседж; item.GetType - йде в {0}(це перший параметр), Item - в {1} (другий)
            }
        }
        static void Main(string[] args)
        {
            int a = 10;
            int b;
            TestMethod(ref a);
            TestMethod(ref b); //помилка - немає даних

            TestMethod2(out a);
            TestMethod2(out b); //тут вже помилки немає, дані по методу присвоєні

            TestMethod2(out int c); //можна і тут об"являти перемінну

            string word = Console.ReadLine();

            int.TryParse(word, out int result); //якщо зі строки не виведуться числа, буде присвоєно "0"

            Console.WriteLine(result);

            // IN - як й інші ключові слова, що передаються як модифікатор в метод
            //..дозволяє передати дані по ссилці але різниця в тому
            //..що всередині методу ми не можемо задати чи змінити перемінну
            //тобто використовуємо тоді коли нам треба щоб перемінна в методі не мінялася
            //.. що може бути без цього слова
            //це все робиться для швидкості роботи програми та для зменшення використання пам"яті
            //це добре для Структури

            TestMethod3(a); //тут не обовязково вказувати це ключове слово


            //Далі тест швидкості роботи метода з використанням IN, та без нього
            Point aa = new Point();

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < int.MaxValue; i++)
            {
                TestMethodPoint(aa);
            }
            sw.Stop();
            Console.WriteLine($"Test Method Point 1: {sw.ElapsedMilliseconds}");

            sw.Restart();

            for (int i = 0; i < int.MaxValue; i++)
            {
                TestMethodPoint2(aa);
            }
            sw.Stop();
            Console.WriteLine($"Test Method Point 2: {sw.ElapsedMilliseconds}");


            //params - передає будь яку кількість параметрів (даних)

            int result1 = TestMethod4(1, 23, 4);
            Console.WriteLine(result1);

            TestMethod5("test", 5, 'q', 5.89, true); //вивід масиву різних типів даних
            //на виході: data type System.String data "test"
        }
    }
}