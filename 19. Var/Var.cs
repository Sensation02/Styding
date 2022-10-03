using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _19._Var
{
    /*
     *      var - з"ясовує який тип даних знаходиться праворуч від оператора присвоєння
     *      та неявно типізовані локальні перемінні
     *      
     *      тип даних var не існує, а тільки дозволяє писати більш зручно
     * 
     * 
     * 
     * 
     */
    internal class leson
    {
        //неявно типізовані локальні перемінні
        static void TestMethod1(var value_1, int value_2)
        {
            //даний код не буде працювати тому, що незрозуміло який тип даних заходить в метод
            //всередині самого метода можна використовувати
            var result = value_1 + value_2;
            return result;
        }
        static var TestMethod2()
        {
            //в якості типу даних що повертаються також не можемо вказати,
            //обов"язково має бути або void якщо ми нічого не повертаємо,
            //або конкретний тип даних,
            //на рахунок повернення "різний типів даних" (Generic) буде пізніше
        }
        class TestClass
        {
            public var a = 0;
            //в якості полів класу також не можемо використовувати var
        }

        //можемо використовувати тільки в локальному контексті:
        static void Main(string[] args)
        {
            var t = 5; //int - System.Int32
            var y = "hello world"; //string - System.String
            var arr = new float[10]; //float - System.Single
            Console.WriteLine(t.GetType()); //int
            t = 10; //а тут вже можна працювати з перемінною тому, що ми вже знаємо що це тип int
            y = 20; //string y = 20; - це помилка, тому що по var ми визначили що це String

            var u = null; //помилка тому що null не тип даних
            y = null; //так вже можна тому, що String це вже ссилочний тип даних
            var o = (string)null; //а так вже можна, але немає потреби

            //але весь такий запис в коді безкорисний, навіть затрудняє його розуміння

            //як насправді користуватися var?

            //ним ми користуємося коли ми хочемо створити об"єкти якихось класів, для яких треба довгі записи

            var word = new Dictionary<int, string>();
            //це колекція яка містить ключ значення (int), а значення якесь слово (string)

            var numbers = new List<int>(); //лист - перелік

            var names = new { name = "Vasyl", age = 27 };
            // це AnonimousType - анонімний тип який містить у собі System.String, System.Int32

            int[] numbers2 = { 2, 10, 120, 12, 5, 67, 23, 865, 1235, 87, 90 };
            var result = from i in numbers2 where i > 100 select i;
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Data type of result is: {result.GetType()}");
            //на виході - System.Linq.Enumerable+WhereArrayIterator'1[System.Int32]
            //завдання коду було виведення чисел з массиву які більші за 100 і написання який тип даних в них був


        }
    }
}