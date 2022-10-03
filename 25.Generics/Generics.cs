/*
    Узагальнення (Generics) - зазвичай пишеться "т"
узагальнення це конструкції які дозволяють писати код який буде однаково працювати з різноманітними типами даних зі збереження
строгої типізації мови коду. Це дуже дрбре підходить для того щоб уникнути процесів упаковки та розпаковки задля пришвидшення
роботи коду.
    Або, наприклад в процесі розробки застосунку нам треба міняти тип даних, то замість того щоб скрізь його змінювати
можна використовувати узагальнення (Generics), або замість того щоб робити по декілька однакових класів із різними
типами даних.

*/
using System.Collections;
using _25.Generics;

namespace Уроки
{
    public class Product
    {
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Energy { get; set; }

        public Product(string name, int volume, int energy)
        {
            // TODO: перевірити введені дані
            Name = name;
            Volume = volume;
            Energy = energy;
        }
        public Product()
        {

        }
    }
    public class Apple : Product
    {
        public Apple(string name, int volume, int energy) : base(name, volume, energy)
        {
        }

    }
    public class Banana : Product
    {
        public Banana(string name, int volume, int energy) : base(name, volume, energy)
        {
        }
    }
    public class Eating<T>
        where T: Product //це нам дає доступ до продуктів
        //замість Product може бути інтерфейс
        //може бути (має бути) struct, class, new() - це все обмеження
        //при чому new() - це клас яким має містити в собі конструктор без параметрів
        //також може бути ще додатково - where TТ: IEnumerable - або що вказано вище
    {
        public int Volume { get; private set; }
        public int Add(T product)
        {
            return Volume += product.Volume * product.Energy; 
            //можемо зветратися до проперті класа Product через доступ вище
        }
    }

    internal class leson
    {
        static void Swap<T>(ref T a, ref T b) //метод який нічого не повертав і приймав два параметра
        //<T> це дженерік, створюється він для того щоб не дублюватий метод коли сюди буде повертатися інший тип даних
        //<T> заміняє собою будь який тип даних який сюди попадає в ()
        //замість <T> можна написати наприклад <T1,Т2> щоб працювали різні типи даних, але це і так не буде працювати
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static T Foo<T>() //цей метод вже повертає узагальнений параметр і не приймав нічого
        {
            return default(T); //тут має бути default тому що може бути число 0 , або null,
                               //в залежності від типу даних який ми хочемо отримати на виході
        }
        public static void Main(string[] args)
        {
            int a = 1, b = 2; //тут мають бути однаковий тип даних інакше дженерік не буде працювати
            //double a = 1; int b = 2; - так не буде працювати

            Console.WriteLine($"a = {a}, b = {b}");
            Swap(ref a, ref b); //де "а" і "b" - це int, і в метод цей int йде замість дженеріка <T>
            Console.WriteLine($"a = {a}, b = {b}"); //ми поміняли значення між собою

            Console.WriteLine("\n");

            string str1 = "Hello";
            string str2 = "World";

            Console.WriteLine($"str1 = {str1}, str2 = {str2}");
            Swap(ref str1, ref str2); //тут у метод вже йде string замість дженеріка <T>
            Console.WriteLine($"str1 = {str1}, str2 = {str2}");

            int result = Foo<int>(); //тут нам треба явно вказати тип даних який має повернутися - це <int>
            //у Swap(ref str1, ref str2); це робити не треба тому що він і так нам повертає
            //те що ми задаємо в параметри
            //а з Foo<int>(); - треба, бо ми нічого не передаємо
            //в залежності від того який тип даних ми вкажемо у <> таке default ми і отримаємо - 0 або null
            //в даному випадку тут int - тому на виході "0"
            string word = Foo<string>();
            //тут вже null, бо прописано <string>

            List<int> list = new List<int>();
            list.Add(a);
            list.Add(b);
            Console.WriteLine(list[0]);
            //тут список з типом даних int, але це не зручно, тому що можуть бути різні типи даних
            //для використання різних типів даних ми використовуємо Generics
            //можна використовувати неузагальнений список - ArrayList
            ArrayList list2 = new ArrayList();
            list2.Add(a);
            list2.Add(str2);
            //але такий ліст джуе проблемний, витрачається дуже багато пам"яті для його роботи
            //для додавання туди елементів, їх сортуванні при витягненні і тд, кожний раз це велика затрата пам"яті
            //тому даний ArrayList зараз не використовується, замість нього використовують, знову ж, Generics

            MyList<int> myList = new MyList<int>(); //тепер вже можна створювати об"єкт класу MyList
            myList.Add(5); //... і додавати в нього числа
            myList.Add(6);
            myList.Add(7);

            for (int i = 0; i < myList.Count; i++) //перебираємо числа за допомоги індексатора
            {
                Console.WriteLine(myList[i]);
            }
            //...і ми без проблем можемо змінити тип даних з яким буде працювати на список за допомоги Generics


            var product = new Product<int>("Apple", 200, 1000);
            //там <Т> а тут <int>; якщо <Т, ТТ> то тут наприклад <int, decimal>; і тд.
            var map = new Dictionary<int, string>(); //колекція ключів і значень
            map.Add(5, "Five");
            //два таких елементи не можуть існувати - "помилка, елемент з таким ключем вже існує", тобто унікальність

            var eating = new Eating<Apple>(); //тут ми вживаємо Apple, тому що string ми не може з"їсти
        }

    }
}