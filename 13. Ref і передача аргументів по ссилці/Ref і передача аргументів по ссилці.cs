using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._Ref_і_передача_аргументів_по_ссилці
{
    /*
     *      ключове слово Ref
     * 
     * 
     * 
     * 
     *      передача аргументів по ссилці
     * 
     */
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
    struct MyStruct //не забуваємо що це значимий тип (менше пам"яті) - такі дані копіюються
    {
        public int a;
        public double b;
        public float c;
    }
    class MyClass //а це ссилочний тип (більше пам"яті) - а ці посилаються на одні і ті ж дані
    {
        public int d;
        public double e;
        public float f;
    }
    internal class leson
    {
        static Person GetPerson()
        {
            Person person = new Person() { Contacts = new Contacts() { PhoneNumber = "+38 012 251 53 32" } };
            return person;
        }
        static void TestMethod(int a)
        {
            a = -5;
        }
        static void TestMethod2(ref int b)
        {
            b = 5;
        }
        static void TestMethod3(ref MyStruct myStruct)
        {
            myStruct.a = 5;
        }
        static void TestMethod4(MyClass myClass)
        {
            myClass.d = 10;
        }
        static void Array1(int[] myArray)
        {
            myArray[0] = 12; //не забуваємо що це ссилочниий тип
        }
        static void Array2(ref int[] arr)
        {
            arr = null;
        }
        static void Array3(int[] arr2)
        {
            arr2 = new int[10];
        }
        static int TestNumber(int[] numbers)
        {
            return numbers[0];
        }
        static void Main(string[] args)
        {
            int a = 2;
            int b = 2;

            TestMethod(a);
            //перемінна йде в метод, там змінюються дані в перемінній з цього методу
            //і на консоль вже виводиться "2", а не "-5"

            TestMethod2(ref b);
            //при додаванні слова ref сюди і в метод дані в перемінну будуть йти від метода
            //ніяких змін даних не буде відбуватися

            MyStruct myStruct = new MyStruct();
            TestMethod3(ref myStruct);
            //з Ref тут ніби створюється "ярлик" даних який надалі і буде використовуватися
            //дана маніпуляція дозволяє коритуватися такими даними без використання значної
            //кількості пам"яті, тобто без Ref будуть копіюватися самі дані
            //це так працює тому що Значимий тип даних

            MyClass myClass = new MyClass();
            TestMethod4(myClass);
            //із ссилочними типами Ref використовувати непотрібно, такий тип даних
            //і так ссилається на дані (по типу ярлика)

            int[] array = { 1, 2, 3, 4 };//звідси копіюються дані в метод
            Array1(array);
            //відповідно Ref не треба бо ссилочний тип даних
            //але це все не стосується Null, тому що він буде працювати із ссилкою а не з даними
            //Null в методі вище це один масив, а тут зовсім інший масив
            //тому на виході буде 1 2 3 4
            //це як запускати одну програми з 2-х ярликів - в любому випадку програма запуститься
            //і дані виведуться

            Array2(ref array);
            //а якщо скористатися словом Ref, то буде ссилка саме на дані з методу
            //і вилізе помилка Null
            //..тобто пішла "ссилка по ссилці"

            Array3(array);
            //по методу масив з 10-ма елементами, а тут 4
            //на виході буде 4 елемента, тому що тут працює власне програма
            //використання слова Ref заміниться нам дані масиву
            //і на виході вже буде 10 елементів масиву

            //без Ref дані з цього масиву йдуть в метод !!!!!!!!
            //з Ref дані будуть йти з метода в масив    !!!!!!!!

            //Ссилочні локальні перемінні

            int[] array2 = { 3, 5, 8 };

            ref int t = ref array2[0];
            t = 10;
            //ссилка даних масиву присвоюємо перемінній "Т" тобто в перемінну пішло "3"
            //далі ми дані в перемінній замінюємо іншими даними, на "10"
            //і ця 10-ка вже йде в елемент масиву
            // - це і називається ссилочна локальна перемінна

            //Посилання що повертаються

            int[] array3 = { 3, 7, 10 };
            int y = TestNumber(array3);
            y = 10;
            //по попередньому прикладу в 1 елементів масиву вже 10
            //але тут вже використовується у зв"язці з методом
            //і в масиві збережеться "3"
            //а в перемінній вже буде "10"



            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}