/*
    Delegate - це особливий тип даних, як object чи int, який може зберігати ссилки на методи
    тобто він ВКАЗУЄ на метод

    Для чого це робиться? це робится для того щоб знаходити ссилку на певний метод
    і змушувати його виконувати певну роботу.

    Наприклад івенти(Events). Створюємо форму у віновс формі і кладемо кнопку ОК і при нажиманні на кнопку
    повинно висвітитися що ВСЕ ОК. У кнопки є стандарний Івент який генерується при нажиманні кнопки ОК,
    він генерує метод який показує "Що Все Ок". І для звязку івента з методом використовується делегат
    тобто Івенту потрібна ссилка(делегат) на метод

    Наприклад методи зворотнього виклику (Callbacks). Викликаємо ссилку на метод який буде викликаний
    наприкінці роботи основного метода.

    Наприклад в Design Patterns

    Види делегатів:
    - Singlecast - вони посилаються тільки на один метод (приклад з NoParameters2 та WithParameters3)
    - Multicast  - посилаються на декілька методів, але вони повинні мати однакову сігнатуру

 */

namespace Уроки
{
    internal class leson
    {
        /* приклад виклику делегата:
            [modifiers] delegate [return type] Name ([parametеrs])

            modifiers   - модифікатори доступа
            return type - int bool float string тощо
            parametеrs  - вхідні параметри, такі ж як і в нашому методі який ми делегуємо
            якщо у нашого метода немає параметрів значить і тут їх не має бути, якщо є то вказати
            з правильною кількістю і типом даних
            
            Причому наш делегат може бути об"явленим як всередині класа так і поза нього
        */

        public delegate void NoParametrs();

        //силка на метод який нічого не повертає, тому що void
        //і нічого не приймає тому що в () пусто

        private delegate float WithParametrs(int x, bool y);

        //приватний делегат який повертає float, та приймає int та bool
        //при чому назви перемінних в () і в методі, на який ми ссилаємося, можуть не співпадати

        protected delegate float WithParametrs2(ref int x, bool y);
        //тут перший параметр ми передаємо по ссилці

        //Далі живий приклад роботи делегата: (в даному випадку вид делегата Singlecast)

        public delegate void NoParameters2(); //делегат без параметрів який нічого не повертає

        private static void ShowMessage()
        //метод на який ссилається наш делегат, який нічого не приймає в параметри
        {
            Console.WriteLine("Have fun!"); //і виводить на консоль строку
        }

        //Далі делегат з параметрами і значенням що повернеться:

        public delegate string WithParameters3(string name1, string name2);

        //повертає строку та приймає два строкових параметра

        private static string ShowMessage2(string name1, string name2)
        //зауважуємо що сігнатура з делегатом співпадає
        {
            Console.WriteLine($"{name1}, {name2} Have fun!");
            return "with Dmytro";
        }

        //Приклад з делегатом який посилається на декілька методів (Multicast)

        public delegate void NoParameters3();

        private static void ShowMessageOne() => Console.WriteLine($"Have fun!");

        //до речі "=>" це скорочений варіант об"яви метода, якщо він має тільки одну строку
        private static void ShowMessageTwo() => Console.WriteLine($"See you!");

        //Делегати можуть мати ссилку на анонімні методи

        public delegate void NoParameters4(); //знову делегат без параметрів який нічого не повертає

        //делегат це тип об"єкту, тому його можна передавати в якості параметра в інший метод:
        private static void Test(NoParameters4 noPrm)
        //метод який в якості параметра приймає делегат без параметра
        {
            noPrm(); //викликаємо метод, але не знаємо на виході
        }

        public static int MethodValue(int i)
        {
            Console.WriteLine(i);
            return i;
        }

        private static void Main(string[] args)
        {
            NoParameters2 noPrm = new(ShowMessage);
            //об"явили тип даних, як int чи DateTime, який зберіг ссилку на метод ShowMessage
            noPrm(); //викликаємо метод через ссилку в делегаті, на виході:  Have fun!
            Console.Read();

            //приклад з параметрами:
            WithParameters3 withParameters = new(ShowMessage2); //створили об"єкт, із ссилкою на метод
            string value = withParameters("Vasyl", "Natali");
            //задали в об"єкт параметри і присвоїли в нову перемінну
            Console.WriteLine(value); //вивели повідомлення на консоль
            Console.ReadLine();

            //Приклад з делегатом який посилається на декілька методів (Multicast)
            NoParameters3 noParameters3 = new(ShowMessageOne); //створили об"єкт, тут він поки Singlecast
            noParameters3 += ShowMessageTwo; //додали до об"єкта ще метод, тут вже Multicast
            //до речі в "+=" можна і видаляти методи "-="
            noParameters3(); //вихід Have fun! See you!
            Console.ReadLine();

            //варіант об"яви та виклику:
            NoParameters3 noParameters31 = new NoParameters3(ShowMessageTwo);
            noParameters31 += ShowMessageTwo; //можна додавати один і той же методи декілька разів
            noParameters31.Invoke();
            Console.ReadLine();

            //можна об"єднувати делегати в новий:
            NoParameters3 noParameters32 = noParameters3 + noParameters31;
            noParameters32.Invoke();

            //Делегати можуть мати ссилку на анонімні методи:
            NoParameters4 noParameters4 = () => { Console.WriteLine("Have fun!"); };
            //перед () можна написати delegate, але це не обов"язково
            noParameters4();
            Console.ReadLine();

            //делегат це тип об"єкту, тому його можна передавати в якості параметра в інший метод:
            NoParameters4 noParameters5 = () => { Console.WriteLine("Have fun!"); };
            //перед () можна написати delegate, але це не обов"язково
            Test(noParameters5);
            //викликаємо метод з параметром делегата без параметрів, на виході: Have fun!
            Console.ReadLine();


            //Шаблонні делегати:
            //існують для того щоб не створювати новий делегат і не забивати код та пам"ять

            //пустий делегат (войд):
            Action action = ShowMessage;
            action();
            //це те саме що і:
            //public delegate void NoParametrs();
            //NoParameters2 noPrm = new(ShowMessage);
            //noPrm(); вихід - "Have fun!"

            //такий делегат вміє приймати від 0 до 16 <аргументів>, тобто:
            //Action<int> action; або Action<int, string> action; тощо

            Predicate<int> predicate;
            //обов"язково має бути 1 <аргумент> і він там тільки 1
            //тут він анонімний
            //це те саме що і:
            //public delegate bool Predicate<T>(T value);

            Func<string, int> func;
            //приймає від 1 обов"язкового <аргумента> до 16
            //це те саме що і:
            //public delegate int Func(string value);
            //останній тип який ми задаємо в якості аргумента це тип_даних що має повернутися

            Func<int> func1;
            //public delegate int Func();
            //Func в любому випадку має повертати значення, тут це int

            Func<string, char, int> func2;
            //public delegate int Func(string str, char ch);

            Func<int, char, string> func3;
            //public delegate string Func(int i, char ch);

            Func<int, int> func4 = MethodValue;
            //треба перевірити перед тим як визвати Func
            if (func4 != null)
                func4(7);
            //func4?.Invoke(7); - коротко, тобто якщо в делегаті є метод то буде вивод метода, якщо немає - ігнор, без помилок

            //якщо ми об"явили делегат але ніякого метода йому не присвоїли вискочить помилка.

            /*
              Далі більш складний приклад
              Наприклад створюємо бібліотеку(StockExchangeMonitor) яка буде, наприклад, підкючатися до банку америки
              і звідти буде брати поточну ціну акції. Отримавши ціну бібліотека буде показувати її всім бажаючим
              і одним із таких бажаючих буде наш додаток який буде виводити ціну на консоль у режимі реального часу
            */

            StockExchangeMonitor stockExchangeMonitor = new StockExchangeMonitor(); //об"єкт монітора

            stockExchangeMonitor.PriceChangeHandler = ShowPrice;
            //реєстрація методу ShowPrice через PriceChangeHandler

            stockExchangeMonitor.Start(); //запуск

            //на виході кожні дві секунди New price is: 20
            //і так далі...
        }

        /// <summary>
        /// Метод вивода поточної ціни акції (bankOfAmericaPrice) на консоль
        /// </summary>
        /// <param name="price"></param>
        public static void ShowPrice(int price) => Console.WriteLine($"New price is: {price}");
    }
}