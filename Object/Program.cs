using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*

Базовий тип OBJECT - це первоначальний тип, батько всіх типів даних

*/
namespace Object
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object obj = new object();

            // методи нашого універсального object:

            #region Equals
            Console.WriteLine("Equals: ");
            obj.Equals(null); // порівняння з тим що у дужках, із ссилочними та значимими типами взаємодіє по різному

            // із значимими - порівнюються значення:
            int i = 5;
            int j = 4;
            i.Equals(j); // порівнюються 5 і 4 - false; true якщо рівні

            // ссилочні типи - порівнюємо адреса на об"єкти в кучі
            // якщо два об"єкти знаходяться в різних ділянках пам"яті то це різні об"єкти
            // якщо в одній ділянці - однакові

            // для цього розглянемо Упаковку та розпаковку: (Boxing & Unboxing)
            // це коли є значимий тип який ми поміщамо в кучу - це Упаковка
            // це відбувається шляхом елементарного приведенням до object

            // виконуємо упаковку:
            var oi = (object)i;
            object oj = j;
            // порівнюємо вже як ссилочні типи:
            Console.WriteLine(oi.Equals(oj)); // true
            // але так просто це не виходить, тут порівнюються значення
            // створюємо окремий клас...

            var point = new Point() { X = 5};
            var point2 = new Point() { X = 5};

            Console.WriteLine(point.Equals(point2));
            // так як наші об"єкти знаходяться в різних ділянках пам"яті - false

            // також бажано переоприділити оператор рівності =
            // і навпаки при переоприділинні оператора = , переоприділити Equals
            #endregion

            #region GetHashCode
            Console.WriteLine("GetHashCode: ");
            Console.WriteLine(i.GetHashCode());
            Console.WriteLine(oi.GetHashCode());
            Console.WriteLine(new Class1().GetHashCode());
            Console.WriteLine(point.GetHashCode());
            // коротко - Equals на мінімалках
            // така операція має бути максимально швидкою і засновується вона на внутрішньо збережених даних
            // використовується вона в Dictionary HashTable 

            // якщо наші об"єкти по Хешкоду співпадають то не обов"язково вони рівні
            // і якщо вони різняться по хешкоду то вони точно різні
            #endregion

            #region ToString
            Console.WriteLine("ToString: ");

            Console.WriteLine(i.ToString());
            // але ToString тут і не треба, бо в WriteLine вже є приведення всіх значимих типів до строки

            Console.WriteLine(point.ToString());
            // приведення ссилочного типу,
            // на виході - Object.Point де Object це простір імен, а Point це назва класа

            // ToString рекомендується завжди переоприділяти
            // це завжди допомагає в отладці програми
            // і в перевизначенні завжди треба писати реальні значення тому що це потім допомагає визначити помилки

            #endregion

            #region GetType
            Console.WriteLine("GetType: ");

            Console.WriteLine(i.GetType()); // повернення типу до якого відноситься ця перемінна
            Console.WriteLine(oi.GetType());
            Console.WriteLine(point.GetType());
            // GetType - повертає тип до якого відноситься даний екземпляр класа

            // якщо ми хочемо отримати тип нашого класа, тобто отримати перемінну в які буде зберігатися
            // не екземпляр цього класу а тип цього класа

            Console.WriteLine(typeof(Point) == point.GetType());
            // typeof - тип з класа
            // GetType - тип з екземпляра класа

            // даний метод неможливо переоприділити через те що він не є віртуальним !!!

            // методи можна переоприділяти - це override
            // а можна перекривати - це new - тобто метод буде викликатися в класі замість базового 
            // але в такому випадку не буде працювати поліморфізм
            // без new буде виникати конфлікт, тому що існує, доприкладу два метода GetType, який має викликатися?

            // таким чином, за допомоги new можна переоприділити то=е що неможна переоприділити))

            #endregion

            #region ReferenceEquals
            // - порівнюємо ссилки на об"єкти ігноруючи значення в них
            Console.WriteLine("ReferenceEquals: ");

            Console.WriteLine(System.Object.ReferenceEquals(5, 5)); 
            // false ; тут ще відбувається упаковка, не забуваємо

            Console.WriteLine(System.Object.ReferenceEquals(5, 5));
            // true

            Console.WriteLine(System.Object.ReferenceEquals(point, point));
            // true - один і той же участом пам"яті

            #endregion

            #region MemberwiseClone
            // допомагає створювати клони об"єктів, для чого це?
            // клони це додатковий об"єкт який має всі ті ж поля які були у вихідному стані

            Console.WriteLine("MemberwiseClone: ");

            var pp = new Point() { X = 7 };
            var pp2 = pp; // два об"єкти із різними іменами які посилаються на одну і ту адресу в пам"яті
            pp2.X = 77;
            pp2.Y = new Point() { X = 99 };

            Console.WriteLine(pp); // 77
            Console.WriteLine(pp.Y); // 99

            // клонування буває двох типів:
            // 1 - глибоке
            // 2 - не глибоке (MemberwiseClone)

            // чим вони відрізняються? розбиражмося далі...
            // не глбиоке клонування:
            // якщо в нашому класі були полі тощо зі значимими типами вони буду продубльовані
            // якщо там є ссилочний тип, то ссилка на цей ссилочний тип буде одна і та ж

            // глибоке клонування: коли вже будуть різні ссилки на ссилочний тип
            // і реалізуємо ми таке клонування вручну, воно відбувається повільно

            //за вмовчанням клонування не глибоке

            var pp3 = pp.Clone();
            pp3.X = 88;
            pp3.Y.X = 222;
            Console.WriteLine(pp); // 77 - значення у клона не міняється
            Console.WriteLine(pp.Y); // 222 - дані із ссилочного типу вже інші бо ми їх змінили

            #endregion

            Console.ReadLine();
        }
    }
}
