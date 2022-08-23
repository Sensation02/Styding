using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Null
{
    /*
     * 
     *         NULL
     *      це пуста ссилка (немає закріплених даних)
     *      можна використовувати тільки із ссилочними типами
     *      
     *          ??
     *      це оператор Null-з"єднання
     */
    class MyClass
    {

    }
    class MyStruct
    {

    }
    internal class leson
    {
        static void Test()
        {
            int a; //як тільки ми вийдемо з методу, вона видалиться зі стеку
            int[] arr /* - далі ця ссилка буде видалена*/ = { 1, 2, 3, 4, 5, 6, 7 };
        }
        //все що існує в цьому методі - існує тільки в ньому, далі після закінчення його роботи
        //пам"ять очищується

        static int[] MyArray1()
        {
            int[] arr = null;
            return arr;
        }
        static int[] MyArray2()
        {
            int[] arr = Enumerable.Range(0, 5).ToArray();
            return arr;
        }

        static void Main(string[] args)
        {
            //тільки ссилка без даних:
            bool a; //Null
            int b; //тут буде "0"
            double d; //також 0
            Random r; //тут вже Null
            int[] arr; //Null - тобто відсутність ссилки на реальні дані; тут ссилочний тип
            int[] arr2 = new int[2]; //тут вже є ссилка на дані
            arr2 = null; //а так зв"язок з даними обриваються і вони стають знову Null
            //..далі спрацьовує "збірник сміття" і пам"ять звільняється
            MyClass myClass; //Null
            MyStruct myStruct;//Null

            Test(); //тут у нас є дані, але без ссилки вже (дані зі стеку вже видалені)
            //потім дані будуть видалені за допомоги "збірника сміття";
            //це дуже зручно тому, що не треба "паритися" за звільнення пам"яті

            int[] array = new int[10];
            array = null;
            Console.WriteLine(array[0]); //після array = null; наш об"єкт нікуди не ссилається
                                         //тобто array[0] - хоче знайти якісь дані, а їх немає взагалі (Null)
                                         //NullReferenceException - помилка виконання програми
                                         //ссилка на об"єкт не вказує на екземпляр об"єкта



            // "??"
            string word = "test";
            Console.WriteLine(word); //test

            string str = null;
            Console.WriteLine(str); //error

            if (str == null)
            {
                Console.WriteLine("no data");
            }
            else
            {
                Console.WriteLine(str);
            }
            //або: (працює так само)
            string result;
            if (word == null)
            {
                result = "no data";
            }
            else
            {
                result = word;
            }
            Console.WriteLine(result);
            //або: (значно простіше)
            Console.WriteLine(str ?? "no data");

            //оператор присвоєння об"єднання зі значенням NULL   ??=

            //якщо в попередньому разі str залишилося без значення
            Console.WriteLine(str ??= "test");
            //..то тепер до str замість null присвоєно "test"

            int[] array2 = MyArray1();
            //в методі Null, якщо не null, тоді наступна строка не буде працювати і підуть дані з матода

            array2 ??= new int[5];//присвоюємо замість null 5 елементів

            Console.WriteLine("count of elements in array: " + array2.Length);
            //5, або те що буде в матоді з масивом

            //оператор умовного NULL   ?.

            int[] array3 = MyArray1();

            Console.WriteLine("summ of elemets in array: " + array3?.Sum());
            //якщо при перевірці буде NULL, тоді подальша дія після "?." не буде виконуватися

            Console.WriteLine("summ of elemets in array: " + (array3?.Sum() ?? 0));
            //в такому випадку буде 0

            //далі на основі нище створених класів та методів:
            Person person = GetPerson();
            string phoneNumber = person?.Contacts?.PhoneNumber ?? "no data";
            //на кожному ?. перевіряється null, якщо є дані - вивод, якщо немає - "no data"
            Console.WriteLine(phoneNumber);

            Console.ReadLine();
        }
        static Person GetPerson()
        {
            Person person = new Person() { Contacts = new Contacts() { PhoneNumber = "+38 012 251 53 32" } };
            return person;
        }
    }

    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Contacts Contacts { get; set; }
        public string GetFullName()
        {
            return $"Прiзвище: {LastName ?? "no data"} | Iм'я: {FirstName ?? "no data"} | По-батьковi {MiddleName ?? "no data"}";
        }
        public string GetFullContacts()
        {
            return $"Номер телефону: {Contacts?.PhoneNumber ?? "no data"} | Email: {Contacts?.Email ?? "no data"}";
        }
    }
    internal class Contacts
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}