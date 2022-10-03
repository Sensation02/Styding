using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _18._Nullable
{
    /*
     *      Null-відповідні значимі типи (Nullable)
     * 
     *      Nullable - для того щоб значимі типи могли містити в собі Null
    */
    internal class leson
    {
        static void Main(string[] args)
        {
            string str = null;

            int a = null;

            DateTime dateTime = null;
            DateTime? dateTime1 = null; //Тепер це вже Nullable тип

            //як користуватися Nullable?
            int? i = null;

            Console.WriteLine(i == null); //true - тому що значення в перемінній дорівнює null
            Console.WriteLine(i.HasValue); //false - тому що в перемінній немає значення
            Console.WriteLine(i.GetValueOrDefault()); // 0 - якщо є значення, то виводить його, якщо немає - по дефолту 0
            Console.WriteLine(i.GetValueOrDefault(3)); // 3 - те саме тільки замість 0 - 3
            Console.WriteLine(i ?? 55); // 55 - якщо null то повертає 55
            Console.WriteLine(i.Value); // InvalidOperationException - помилка, тому що в перемінній немає значення
            //до поля Value можна звертатися коли i != null та i.HasValue - true
            Console.WriteLine(i);
            //але до Value можна не звертатися, а просто вивести дані з перемінної

            //що ще можна робити з Nullable
            int b = 4;
            int? c = 22;
            int? d = null;
            int? res = b + c; //26
            int? res2 = b + d; //Null
            Console.WriteLine(res); //26
            Console.WriteLine(res2); //null
            Console.WriteLine(b == c); //false
            Console.WriteLine(b == d); //false
            Console.WriteLine(b > c); //true
            Console.WriteLine(b > d); //false
            Console.WriteLine(b < c); //true
            Console.WriteLine(b < d); //false
        }
    }
}