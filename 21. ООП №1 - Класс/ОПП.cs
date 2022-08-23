using _21._ООП;
using System.Reflection;

namespace _21._ООП__1___Класс
{
    /*
     *      ООП
     *        якщо файл класу знаходиться в іншому місці, вище, в Using треба вказати де воно
     *        наприклад using Lessons або using _21._ООП
     *
     *      №1: Клас - по суті власний тип даних або креслення який використовується для створення певного об"єкта
     *          клас це ссилочний тип даних
     *
     *          Об"єкт класа - це ніби готовий будинок
     *
     *      №2: Методи об"єкта класа - це ті ж функції (об"єкта класа)
     *          тобто функція є методом класу, функція без класу не може бути
     *
     *      №3: Модифікатори доступа. Різниця між Public i Private.
     *          ..для інкапсуляції і задінемо тему рефлексії
     *
     *          Private - можна користуватися тільки в межах класа
     *          Public - користуються хто хоче і як хоче
     *
     *      №4: Інкапсуляція
     *           - це робиться для того щоб було менше помилок і менше багів, так краще підтримувати програму, і
     *          щоб ним користуватися так як задумали.
     *
     *          Поведінка класа визначається матодами.
     *
     *          Ще раз! Тобто приватними методами закриваємо частину кода від зовнішнього доступу тим самим захищаючи його від
     *          зовнішнього користування. Інкапсульований код має виконувати щось важливе і він не має містити
     *          в собі багів. Даний принцип дозволяє нам коритуватися таким кодом тільки так як задумано.
     *
     *      №5: Конструктор класа
     *
     *          Конструктор за вмовчанням дозволяє нам змінювати дані класу без втручання в його роботу (не порушуємо інкапсуляцію)
     *
     *      №6: Перегрузка конструктора класа
     *          - це коли їх більше 1
     *
     *      №7 - ключове слово This
     *          його використання в конструкторах класу
     *          за його допомоги ми отримуємо доступ до поточного екземпляру класа
     *          (по прикладу класа Student)
     *
     *          в основній програмі, з модифікатором static, This. не працює,
     *          тому що в static немає необхідності створювати екзмепляр класу
     *
     *      №8: Властивості get set (гетер і сетер - аксесери(допступ)) ; Ключове слово value ; Автоматичні властивості
     *          Set - присвоїти
     *          Get - отримати доступ до приватного поля нашого класу
     *
     *          за допомоги get set можна безпечно змінювати дані в перемінній всередині класу
     *
     *      №9: Static; Статичні поля класу
     *          - може бути у використанні з полями, властивостями, методами, конструкторами класу
     *
     *      №10: Статичні методи класу, статичні властивості класу
     *          ..їх вплив на клас
     *
     *      №11: Статичний конструктор класу
     *          - за його допомоги можна змінити дані статичних полів, методів
     *          і всьо що є статичним у класі
     *
     *      №12: Статичний клас та ключове слово Static
     *
     *      №13: Методи розширення (extension)
     *          - з їх допомоги можна розширити функціонал вже існуючих методів, класів або структур
     *          не міняючи їх. Це добре використовувати, коли користуєшся не своїм кодом.
     *          Після такого розширення, клас може не наслідуватися але це ще можливо. Також новий клас
     *          який наслідує не завжди зрозумілий тому треба користуватися цими методами.
     *
     *          Вони мають знаходитися в статичному класі і самі по собі мають бути статичними
     *      №14: Часткові Типи, часткові методи, часткові класи (Partial)
     *          це можливість рознести класи в різні файли, або коли код(поля) формується в класах скриптами, він не пишеться
     *          руками і формуються вони на основі структур даних які повертаються, що зберігаються в процедурах бази даних
     *          в яких працює проект і в цей код самому краще не лізти, а методи такого класу знаходяться в іншому файлі який
     *          можна редагувати
     *
     *          далі в роботі з класом Person та PersonMethods
     *
     *      №15: const vs readonly, різниця між const та readonly, const і static
     *
     *      №16: Синтаксис ініціалізації об"єктів класу
     *          - по суті це процес створення об"єкта класу
     *
     *      №17: Насплідування в ООП
     *          - це інструмент який дозволяє уникнути дублювання кода і в подальшому за його допомоги реалізується
     *          поліморфізм. Також це дозволяє уникнути непотрібних помилок шляхом використання раніше протестованого коду.
     *          на основі класів Person та NewStudent
     *
     *      №18: Наслідування, конструктор класу та ключове слово Base
     *
     *      №19: Оператори as is. Наслідування та приведення типів.
     *
     *      №20: Модифікатор доступа protected при наслідуванні.
     *          все те що використовується в класі може бути використано по відношенню до класа
     *          за допомоги рublic, рrivate та protected ми реалізовуємо інкапсуляцію в класах та їх наступниках
     *
     *      №21: Поліморфізм. Віртуальні методи. Virtual override (в роботі з класами Person i Car)
     *          Virtual дозволяє обраний метод бути перевизначеним в наступниках із використанням override
     *
     *      №22: Поліморфізмю Абстрактні методи, класи та властивості
     *
     *      №23: Поліморфізм. Інтерфейси.
     *          інтерфейс це ніби абстрактний клас в якого є абстрактні методи та поля які маскуються під методи.
     *          Тобто інтерфейсом ми визначаємо поведінку яка потім буде реалізована в конкретному класі
     *
     *      №24: Наслідування Інтерфейсів. Множинне наслідування інтерфейсів.
     *
     *      №25: Явна реалізація інтерфейса.
     *
     *      №26: Реалізація інтерфейса за вмовчанням
     *
     */

    internal enum Color
    {
        Red,
        Green,
        Blue,
        Yellow,
        Orange,
        White,
        Black
    }

    internal class Point //креслення класу (в даному випадку ми створюємо точку в двовимірному просторі)
    {
        public int x; //координата
        public int y;
        public Color color; //можливість задати колір
    }

    //до речі, тут дані відкриті (public), не інкапсульовані, так не робиться але для навчання годиться

    internal class Point2
    {
        public int x;
        private int y = 4;
        private int z; //якщо не вказано поле доступа - заумовчанням він буде приватним
        //

        private void PrintX()
        {
            Console.WriteLine($"X: {x}");
        }

        public void PrintY()
        {
            Console.WriteLine($"Y: {y}");
        }

        public void PrintPoint()
        {
            PrintX();
            PrintY();
        }
    }

    internal class Pistol
    {
        public Pistol(bool isLoaded)
        {
            _IsLoaded = isLoaded;
        }

        private bool _IsLoaded;

        private void Reload()
        {
            Console.WriteLine("Заряджаю...");
            _IsLoaded = true;
            Console.WriteLine("Заряджено!");
        }

        public void Shoot()
        {
            if (!_IsLoaded)
            {
                Console.WriteLine("Зброя не зарадженя!");
                Reload();
            }
            Console.WriteLine("Постріл!\n");
            _IsLoaded = false;
        }
    }

    //CONSTRUCTOR:
    internal class Point3
    {
        //чи завжди конструктор присутній в класі?
        //буває так що, якщо ми його не задаємо він там присутній "за вмовчанням"

        public Point3()
        {
        }

        public Point3(int x, int y)
        {
            _x = x;
            _y = y;
        }

        //якщо конструкторів більше 1 - це називається перегрузка конструкторів

        private int _x;
        private int _y;

        public void PrintPoint2()
        {
            Console.WriteLine($"X: {_x}, Y: {_y}");
        }
    }

    //GET SET:
    internal class Point4
    {
        private int x;

        public void SetX(int x)
        {
            if (x < 1)
            {
                this.x = 1;
                return;
            }
            if (x > 5)
            {
                this.x = 5;
                return;
            }

            this.x = x;
        }

        public int GetX()
        {
            return x;
        }

        //propfull - сніпет для генерації властивостей
        //далі те все те саме, що було з "х", тільки для "у"

        private int y; //присвоєння тут даних може нам замінити set

        public int Y
        {
            get { return y; } //виведення даних, без цієї строки дані ми не виведемо
            set  //отримання даних, value - ключове слово, воно приймає будь який тип даних який ми задамо
            {
                if (value < 1)
                {
                    y = 1;
                    return;
                }
                if (value > 5)
                {
                    y = 5;
                    return;
                }
                y = value;  //те саме що і this.x = x;
            }
        }

        //prop - ще коротший сніпет для генерації властивостей

        public int Z { get; set; }
    }

    //STATIC:
    internal class MyClass
    {
        public int a;
        public static int b;
        //в такому випадку ця перемінна буде ділитися на весь клас і буде мати тільки одне місце в пам"яті
        //і якщо ми замінимо дані в цій перемінній, то вони заміняться скрізь де є посилання на цю перемінну

        private static int c;

        public void SetC(int c)
        {
            MyClass.c = c; //this.c - не працює зі static, тому що треба звертатися до статичного екземпляру класа
            // this.a = а; - наприклад так би працювало, якби перемінна "а" була приватною
        }

        public void PrintC()
        {
            Console.WriteLine(c);
        }
    }

    internal class MyClass2
    {
        private static int a;
        private int b;

        public static void Method1()
        {
            a = 1; //так
            b = 2; //ні
            //у статичних методах ми не можемо працювати із НЕ статичними полями (даними)
        }

        //зі статичними методами ми втрачаємо можливість поліморфізму ООП, але це пізніше...

        public void Method2()
        {
        }
    }

    internal class MyClass3
    {
        public MyClass3()
        {
            counter++;
        }

        private static int counter;

        public static int Counter
        {
            get { return counter; }
            private set { counter = value; }
        }

        public int Counter2
        {
            get { return counter; }
        }

        public static int GetCounter()
        {
            return counter;
        }

        public int GetCounter2()
        {
            return counter;
        }
    }

    internal class MyClass4
    {
        public MyClass4()
        {
            Console.WriteLine("Constructor");
        }

        static MyClass4()
        //зі статичними конструкторами модифікатори доступа взагалі не використовуються
        //..в цьому взагалі немає ніякого змісту
        //такий конструктор не може приймати параметри (ті що пишуться в ()) - CS0132
        //він не може звертатися до НЕстатичний методів класу, щоб це було можливо треба мати екземпляр класу
        //також тут не працює ключове слово this. (тому що це ссилка на конкретний екзмепляр класу)
        {
            Console.WriteLine("Static constructor");
        }

        public static void Foo()
        {
            Console.WriteLine("Foo");
        }
    }

    internal static class MyClass5
    {
        //статичний клас може містити в собі тільки все статичне
        //статичними методами не варто зловживати тому що це може порушити принципи СОЛІД
        //також статичні класи не вміють "наслідувати" та не працюють з інтерфейсами
        //статичні класи добре використовувати коли всеодно що виконувати

        public static void Foo()
        {
            Console.WriteLine("Foo");
        }
    }

    //CONST READONLY
    internal class MyClass6
    {
        public const int a = 1; //const - забороняє будь коли редагувати цю перемінну і в ній завжди мають бути дані
        //це робиться для того коли ми вже знаємо які дані в ній мають бути і вони ніколи не мають мінятися
        //щоб не поламати логіку виконання програми

        public const double PI = 3.14;
        //такі поля неявно статичні, тобто при написанні static виникає помилка, але таке поле і так статичне

        public const string MY_ERROR = "some error";
        //збереження в константних полях повідомлення про помилку у випадку логіювання,
        //виникнення якихось помилок у виконанні програми
        //при чому такі поля пишуться Великими буквами з нижнім підкресленням або в залежності
        //від домовленості в компанії де будемо писати по іншому

        public static readonly int _b;
        //в readonly не обов"язково присвоювати дані але це можна і тоді воно буде себе поводити так само
        //і такі поля не являються неявно статичними, але їх можна зробити статичними за допомоги static

        public MyClass6(int b)
        {
            //навіть тут не можна присвоювати const перемінній дані
            _b = b;
            //а readonly поля вже можна міняти на етапі виконання програми..
        }

        public void Foo()
        {
            _b = 1; //..але тільки в конструкторі, алееее тільки тоді коли воно не статичне
        }

        static MyClass6()
        {
            _b = 3; //в статичному конструкторі вже можна міняти дані поля зі static readonly
        }
    }

    //№16
    internal class Cat
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Cat()
        {
        }

        public Cat(string name)
        {
            Name = name;
        }
    }

    //№18
    internal class Point1D
    {
        public Point1D()
        {
            Console.WriteLine("Викликаний конструктор класу Point1D");
        }
    }

    internal class Point2D
    {
        public Point2D(int x, int y)
        //при додаванні в () дані які необхідно передати, в класі Point3D виника помилка
        {
            X = x;
            Y = y;
            Console.WriteLine("Викликаний конструктор класу Point2D");
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void Print2D()
        {
            Console.WriteLine($"X: {X}");
            Console.WriteLine($"Y: {Y}");
        }
    }

    internal class Point3D : Point2D
    {
        public Point3D(int x, int y, int z) : base(x, y)
        //а для правильності роботи (без помилок) треба дописати base і вказати дані в ()
        //тобто за допомоги base() ми звертаємося до батьківського класу і відповідно
        //присвоюємо дані які там необхідно вказати
        //можна написати (int x, int y, int z):base(x, y)
        //тоді з base(x, y) дані перейдуть в батьківський клас
        //ну а дані в (int x, int y, int z) задаються в основній програмі
        {
            Z = z;
            Console.WriteLine("Викликаний конструктор класу Point3D");
        }

        public int Z { get; set; }

        public void Print3D()
        {
            Print2D();
            //за допомоги base. ми можемо дізнатися що ми успадковуємо від попередника
            //і взагалі його тут можна не писати, а просто написати Print2D();
            //досить хороша аналогія із this. який стосується меж одного класу
            //а base. стосується всіх батьківських класів
            //виключенням є якщо писати просто Print, тоді треба точно писати base.Print(); далі опис в осн. прог.
            Console.WriteLine($"Z: {Z}");
        }
    }

    //висновок такий, що за допомоги слова base хочемо використати щось із базового класа
    //взагалом воно використовується не тільки в конструкторі класа:
    //наприклад Print2D та Print3D

    //№19
    internal class Point5
    {
        public int x { get; set; }
        public int y { get; set; }

        public void Print()
        {
            Console.WriteLine($"X: {x}");
            Console.WriteLine($"Y: {y}");
        }
    }

    //№20
    internal class A
    {
        public int publicField;

        private int privateField;

        protected int protectedField; //сюди також можна додати private
        //protected працює з усіма компонентами класу де можна додати модифікатор доступа
        //але в нього є певні особливості при роботі з наслідуванням

        //тобто до public є доступ скрізь
        //private - тільки всередині конкретного класа
        //protected - всередині класа та у всіх наступниках

        public A()
        {
            Console.WriteLine(publicField);
            Console.WriteLine(privateField);
            Console.WriteLine(protectedField); //всі поля доступні
        }

        public void Foo()
        {
            Console.WriteLine(publicField);
            Console.WriteLine(privateField);
            Console.WriteLine(protectedField); //всі поля доступні
        }
    }

    internal class B : A
    {
        public B()
        {
            Console.WriteLine(publicField);
            Console.WriteLine(privateField); // - тільки всередині конкретного класа
            //взагалі клас наступник має до нього доступ але не напряму
            Console.WriteLine(protectedField); // - всередині класа та у всіх наступниках
        }
    }

    //№21
    internal class SportCar : Car
    {
        public override void Drive() //тут все має бути ідентичним з методом із використанням virtual
                                     //і таким чином ми перевизначаємо метод з попередника в наступнику по новому
                                     //так можна працювати із кожним наступником після цього
        {
            StartEngine(); //це також можна перевизначити
            Console.WriteLine("Driving fast!");
        }
    }

    //№22
    //абстрактний клас це є ніби якась ідея, якогось контракту з частковою реалізацією
    //цим можна користуватися тільки в наслідниках абстрактного класу
    //i ми не можемо створити екземпляр такого класу
    internal interface IWeapon //модифікація до 22 уроку з 23
    {
        void ShowInfo(); //сюди можна передавати все що завгодно, головне щоб виконувався контракт

        void Fire(); //це тут також є для того щоб працювало наслідування інтерфейсів
    }

    internal abstract class Weapon : IWeapon
    //ми ніби описуємо ідею що це "щось" має стріляти
    {
        public abstract void Fire(); //абстрактному методу не потрібна реалізація і міститься він тільки в абстрактному класі

        public void ShowInfo()
        {
            Console.WriteLine($"{GetType().Name} Damage: {Damage}");
            //метод вивода типу даних з іменем та виведенням інформації про урон зброї
        }

        //абстрактна властивість може бути передана наступникам та може бути перевизначена
        public abstract int Damage { get; }
    }

    internal class Player
    {
        public void Fire(Weapon weapon)
        {
            weapon.Fire(); //наш гравець може стріляти з усього де реалізовано інтерфейс IWeapon
        }

        public void CheckInfo(IWeapon iWeapon) // або (Weapon weapon) якщо дивитися зі сторони 22 уроку
        {
            iWeapon.ShowInfo();
        }

        public void Throw(IThrowingWeapon throwingWeapon)
        {
            throwingWeapon.Throw(); //або кидати якусь зброю, типу ножа
        }

        internal void Fire(IWeapon weapon)
        {
            weapon.Fire();
        }
    }

    internal class Gunn : Weapon //наступники мають реалізовувати методи з абстрактного класу - це називається контракт,
                                 //ми зобов"язуємо наступників до реалізації методів, без цього код не скомпілюється
                                 //також наступники мають реалізовуватися абстрактні властивості
    {
        public override int Damage
        { get { return 5; } }

        public override void Fire() //тепер ми розуміємо що override працює також із abstract
        {
            Console.WriteLine("FIREEE!!!!");
        }
    }

    internal class LaserGun : Weapon
    {
        public override int Damage => 30; //те саме що і  { get { return 30; } }

        public override void Fire() //кожний наступник реалізовує метод Fire по своєму
        {
            Console.WriteLine("WZZZZZ!!!");
        }
    }

    internal class Bow : Weapon
    {
        public override int Damage => 1;

        public override void Fire()
        {
            Console.WriteLine("FFFFFFEEEWWW!!!!");
        }
    }

    //№23
    internal interface IDataProvider //заведено що всі інтерфейси починають писатися з І
                                     //в інтерфейсі це не клас і в ньому не може бути конструкторів, винятком є абстрактний клас
                                     //також він не може містити поля класу, це пов"язано з тим що інтефейс має визначати контракт (щось до чогось зобов"язувати)
                                     //та поведінку і немає містити в собі якусь конкретну реалізацію. Тобто інтефейс визначає поведінку.
    {
        //далі просто пишемо сігнатуру метода який буде реалізовано в класі, який буде реалізовувати дані інтерфейсу
        //і взагалі все що тут описано це має доступ Паблік
        string GetData();

        //щось схоже на абстрактний клас да?
    }

    internal interface IDataProcessor
    {
        void ProcessData(IDataProvider dataProvider);
    }

    internal class ConsoleDataProcessor : IDataProcessor //так ми реалізовуємо інтерфейс, тобто через клас
                                                         // при чому ми маємо реалізувати всі його компоненти (методи і все все все)
    {
        public void ProcessData(IDataProvider dataProvider)
        // dataProvider - тут може бути все що завгодно, головне щоб воно виконувало контракт IDataProvider
        {
            Console.WriteLine(dataProvider.GetData());
        }
    }

    internal class DbDataProvider : IDataProvider
    {
        public string GetData() //реалізація методу в через даний клас відбувається коли сюди заходять дані які зараз написані
                                // в основній програмі
        {
            return "Data from DB"; //вихід
        }
    }

    internal class FileDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Data from File";
        }
    }

    internal class APIDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Data from API";
        }
    }

    //№24 (в доповнення до 22 уроку)
    internal interface IThrowingWeapon : IWeapon //наслідування інтерфейсів
    {
        void Throw();

        public abstract int Damage { get; }
    }

    internal class Knife : IThrowingWeapon
    {
        public int Damage => 5;

        public void Fire()
        {
            Console.WriteLine($"{GetType().Name}: SWIIIN!");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{GetType().Name} Damage: {Damage}");
        }

        public void Throw()
        {
            Console.WriteLine($"{GetType().Name}: FEEEW!");
        }
    }

    //№25
    internal interface IFirstInterface
    {
        void Action();
    }

    internal interface ISecondInterface
    {
        void Action();
    }

    internal class MyClass7 : IFirstInterface, ISecondInterface //множинне наслідування інтерфейсів
    {
        public void Action()
        {
            Console.WriteLine("MyClass Action...");
        }
    }

    internal class MyOtherClass : IFirstInterface, ISecondInterface
    {
        void IFirstInterface.Action() //синтаксис явної реалізації, паблік тут не можна зробити
        {
            Console.WriteLine("MyOtherClass IFirstInterface Action...");
        }

        void ISecondInterface.Action()
        {
            Console.WriteLine("MyOtherClass ISecondInterface Action...");
        }
    }

    //№26
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error,
        Fatal
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(LogLevel logLevel, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case LogLevel.Error:
                case LogLevel.Fatal:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine($"{DateTime.Now}: {message}");
            Console.ResetColor();
        }
    }

    public interface ILogger
    {
        void Log(LogLevel logLevel, string message);

        void LogError(string message) //реалізація інтерфейса завмовчанням
        {
            Log(LogLevel.Error, message);
        }
    }

    public static class Extensions //розширення яке дозволяє нам добавити реалізацію в інтерфейс
    {
        public static void Foo(this ILogger logger)
        {
            Console.WriteLine("Foo");
        }
    }

    internal class leson
    {
        //всі методи і класи вище винесені у файл класу "ООП", робота продовжується там

        private static void Main(string[] args) //Main - точка входу виконання програми
        {
            Point p = new Point(); //об"єкт класу і він є наслідником класу Object
            p.x = 3;
            p.y = 2;
            p.color = Color.Red;
            Point p2 = new Point();
            p2.x = 6;
            p2.y = 4;
            p.color = Color.Green;

            Console.WriteLine($"X: {p.x} | Y: {p.y} | Color: {p.color}"); //опис об"єкта точки

            Student firstStudent = new();
            var fullName = firstStudent.GetFullName();

            Console.WriteLine("\t == Car 1 ==");
            var car = new Car();

            // №3 - Модифікатори доступа. Різниця між Public i Private.
            Point2 point2 = new Point2();
            point2.x = 3;
            //все що після point2. доступно це: public, що недоступно - private

            point2.PrintY();
            //але можна звертатися через доступний метод вивода
            //ці ситуації протилежні один до одного
            //таким чином реалізується інкапсуляція

            point2.PrintPoint();
            //тут користуэмося методом який публічний в класі
            //доступні методи в класі можуть користуватися приватними даними того ж класу

            //Рефлексія - для перевірки доступності того чи іншого кода
            var typeInfo = typeof(Point2).
                GetFields(BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public);
            //typeof для отримання типу даних Point2
            //GetFields - масив об"єктів FieldInfo де кожний елемент масиву буде містити в собі інформацію
            //про поля які описані в нашому класі
            foreach (var item in typeInfo)
            {
                Console.WriteLine($"{item.Name}: Is Private: {item.IsPrivate}\t" +
                    $"Is Public: {item.IsPrivate}");
                //перебираємо кожний елемент масиву і ділимо їх на приватні та публічні
            }

            // №4 - інкапсуляція
            Gun gun = new Gun();
            //gun.isLoaded = true; - якби був доступ до isLoaded, то порушилась би вся робота класу Gun
            //тому що не відбувається перезаряджання
            gun.Shoot(); //постріл!

            //№5 - конструктор класа

            Gun pistol = new Gun(); //де - new Gun - це власне конструктор класа, тобто створюється екземпляр класу
            //тобто конструктором за вмовчанням використовуєм для створення класу

            //так як з використанням нашого конструктора, ми задали, що пістолет заряджений
            pistol.Shoot(); //..відбуваєтьс постріл
            pistol.Shoot(); //при наступному використанні вже відбувається перезарядка і знову пострілц

            //далі аналогічний клас тільки з іншою умовою конструктора
            //при Pistol (bool isLoaded)

            Pistol pistol2 = new(true);

            //№6 - перегрузка конструктора класа
            Point3 point3 = new Point3(); //працює з конструктором за вмовчанням
            Point3 point31 = new Point3(3, 6); //працює з нашим конструктором
            point31.PrintPoint2();

            //ще один приклад перегрузки конструктора по прикладу класа Student
            Student student = new Student("Kaminskyi", "Vasyl", new DateTime(1995, 01, 14));
            Student student1 = new Student(student);
            //використовуємо конструктор public FullStudent(FullStudent student)
            //це робиться для того щоб копіювати дані з першого студента в другого без змін даних в першому
            //тобто створиться новий об"єкт і під нього виділиться пам"ять

            student1.SetFirstName("Natali");
            //додаємо(або замінюємо) ще один параметр в нашого "студента"

            student1.SetBirthday(new DateTime(1994, 03, 24));
            //додаємо(або замінюємо) дату народження

            student.Print();
            //output: Vasyl Kaminskyi 14.01.1995
            Console.WriteLine();
            //backspace
            student1.Print();
            //output: Natali Kaminskyi 24.03.1998

            //№7 - ключове слово This
            //по прикладу класу Student

            //№8 - get set
            //по прикладу класа Point4

            Point4 point4 = new Point4();
            point4.SetX(10);
            int x = point4.GetX();
            Console.WriteLine($"X: {x}");
            //output 5

            Point4 point41 = new Point4();
            point41.Y = 10; //те саме що і point4.SetX(10);
            int y = point4.Y;
            Console.WriteLine($"Y: {y}");
            //output 5

            //№9 - Static

            MyClass myClass1 = new MyClass();
            myClass1.a = 1; //не забуваємо що в кучі є своя область в памяті де зберігаються дані з перемінної
            MyClass myClass2 = new MyClass();
            myClass2.a = 2;

            MyClass.b = 3; //до такої перемінної треба звертатися напряму через клас

            //тобто кожний екземпляр класу - це більше витрати пам"яті, а статична перемінна вона одна спільна для всіх
            //екземплярів класу і змінюється скрізь, де ми її змінюємо

            myClass1.SetC(10);
            //поміщаємо 10 в статичну перемінну в одному екземплярі класу
            myClass2.PrintC();
            //достаємо ту 10-ку в іншому екзмеплярі класу

            //висновок такий, що ми поширили дані статичної переміної на всі екземпляри класу
            //якщо ми хочемо помістити якісь дані, які нам потрібні у всіх екзмеплярах класу, ми користуємося Статік

            //№10: Статичні методи класу, статичні властивості класу

            MyClass2 myClass3 = new MyClass2();
            myClass3.Method1(); //статичні методі недоступні на рівні екземпляра класу (помилка)

            MyClass2.Method1(); //якщо звертатися напряму через клас - так, вточності як із статичними перемінними
                                //тобто напряму із ними працювати і через такий метод ми не може працювати з
                                //полями класу які НЕ є статичними

            //дані зі статичних полів можна виводити зі статичних методів
            //Але нестатичні методи можуть містити в собі дані статичних полів

            //НЕ статичні методи можуть викликати Статичні методи

            myClass3.Method2(); //НЕ статичний метод можна викликати через екземпляр

            //простий приклад з консоллю
            Console.WriteLine();
            //напряму через клас Console звертаємося до статичного метода WriteLine

            //робота з класом який перелічує скільки об"єктів класу було створено:
            MyClass3 myClass31 = new MyClass3();//1
            MyClass3 myClass32 = new MyClass3();//2
            MyClass3 myClass33 = new MyClass3();//3

            MyClass3.Counter = 1000; //так не можна бо зламаємо логіку класа
            //а щоб це перестало працювати треба з методу видалити  set { counter = value; }
            //але можна зробити і так: private set { counter = value; }
            //тоді можна ці дані міняти в класі, а поза нього ні

            Console.WriteLine(MyClass3.Counter); //output 3

            Console.WriteLine(MyClass3.GetCounter());
            //це працює так само як і строка вище, але там з використанням властивості, а тут статичний метод

            myClass31.GetCounter2(); //output 3 - це вже робиться з використанням звичайного, не статичного,
                                     //методу який може звертатися до статичних даних

            Console.WriteLine(myClass31.Counter2);//те саме виведення кількості тільки в іншому варіанті

            //№11: Статичний конструктор

            MyClass4 myClass4 = new MyClass4(); //output "Static constructor"

            new MyClass4(); //output "Constructor"
            new MyClass4();
            new MyClass4();
            //статичний констркутор виконується тільки 1 раз неважливо скільки об"єктів класу було створено
            //і він буде викликатися перед звичайним конструктором

            MyClass4.Foo();
            //тут знову спрацює статичник конструктор і потім спрацює метод "Фуу"

            MyClass4 myClass41 = new MyClass4(); //output "Static constructor"

            new MyClass4(); //output "Constructor"
            new MyClass4();
            new MyClass4();

            //тут спочатку буде статичний конструктор, потім Фуу, потім звичайні конструктори

            //також є приклад по класу Class1 в Solution'і ООП

            //№12: статичник клас (опис вище в класі)

            Math.Pow(1, 2);//Math. використовується для складних математичних розрахунків

            //№13: Методи розширення (extension)

            DateTime currentDateTime = DateTime.Now;
            currentDateTime.Print();
            DateTime.Now.Print();
            //наприклад ми хочемо створити розширення яке буде нам виводити теперішній час
            //(далі робота в класі MyExtensions)
            //при наведенні на Print нам буде виводитися що це (extension)

            //тобто Print ми можемо викликати у будь якого об"єкту DateTime
            //також в дужки може передати якіь дані і вони будуть прийняті методом якщо це в ньому передбачено

            Console.WriteLine(currentDateTime.IsDayOfWeek(DayOfWeek.Friday));
            //при чому ми бачимо тільки один тип даних який ми можемо передати в дужках
            //true - якщо п"ятниця
            //false - якщо якийсь інший день

            //Ізоляція методів розширення
            //це робиться для того щоб не засоряти простір імен при роботі у великому проекті
            //і щоб він був доступним тільки в певному місці програми

            //це має бути зроблено в якомусть іному просторі імен
            //namespace _21._ООП_MyExtensions

            //а щоб користуватися цими мтеодами треба вказати
            //using _21._ООП_MyExtensions;

            //№14: Часткові Типи, часткові методи, часткові класи(Partial)
            //в роботі з класом Person та PersonMethods (окремим фалом)
            //- вони мають знаходитися в одному просторі імен - _21._ООП та
            //їх клас має одну і ту ж назву - Person, при чому присутнє слово Partial
            //так середовище розробки буде розуміти що це один клас

            Person person = new Person("Bazzil", "Kaminskyi");
            person.PrintFullName();

            //№16: Синтаксис ініціалізації об"єктів класу

            Cat cat1 = new Cat(); //тут спершу створюється об"єкт
            cat1.Age = 3;         //..а вже потім додаються дані в поля
            cat1.Name = "Мурчик";

            Cat cat2 = new Cat //А тут вже створюється об"єкт із заданими значеннями
            {
                //тут можна присвоювати значення для паблік полів та властивостей
                Age = 4,
                Name = "Тузік"
            };

            //далі складніший приклад (за використання класу Person та його методів):

            Person person1 = new Person();
            person1.FirstName = "Rand";
            person1.LastName = "al'Tor";
            Address address = new Address();
            address.Country = "Andor";
            address.Region = "River";
            address.City = "Emond";
            person1.Address = address; //без цієї строки ми можемо втратити інформацію про адрес

            Person person2 = new Person
            {
                FirstName = "Bazzil",
                LastName = "Kaminskyi",
                Address = new Address
                {
                    Country = "Ukraine",
                    Region = "Chernivetska oblast",
                    City = "Chernivtsi"
                }
            };

            //що легше читати?)

            //№17 Наслідування в ООП

            NewStudent newStudent = new NewStudent { FirstName = "Bazzil", LastName = "Kaminskyi" };
            newStudent.PrintName();
            newStudent.Learn();

            Person newStudent2 = new NewStudent { FirstName = "Natali", LastName = "Kaminska" };
            newStudent2.PrintName();
            newStudent2.Learn(); //class Person не містить в собі Learn

            //відповідно наступник має все від попередника, а попередник - відповідно немає того що є в наступника
            //але..

            static void PrintFullName(Person person1)
            {
                Console.WriteLine($"Last Name: {person1.LastName}\t First Name: {person1.FirstName}");
            }

            newStudent.Learn();
            PrintFullName(newStudent);
            //output: I'm Learning!
            //        Last Name: Kaminskyi   First Name: Bazzil

            Person[] people = { newStudent, newStudent2 };

            PrintPeople(people);

            static void PrintPeople(Person[] people)
            {
                foreach (var person in people)
                {
                    person.PrintFullName();
                }
            }

            //на виході перелік студентів

            //№: 18 Наслідування, конструктор класу та ключове слово Base

            Point3D point3D = new Point3D(3, 6, 9);
            //на виході будуть викликатися всі конструктори: і того що наслідується, і в наступника
            //тобто при роботі класа який наслідує щось, повинні згенеруватися всі його попередники

            point3D.Print3D();

            point3D.Print();
            //відповідно тут висвічується тільки один Print, то до якого ж ми звертаємося?
            //тоді до нового метода в наступнику треба написати new
            //public new void Print3D() (тільки не Print3D а просто Print))

            //№19: Оператори as is.Наслідування та приведення типів.

            object obj = new Point5 { x = 3, y = 5 };
            //obj. нічого не знає про Point, в нього немає його методів тощо
            //для того щоб було видно треби зробити явне приведення типів:
            Point5 point = (Point5)obj;
            //Point point = obj; - а так не можна робити бо можна втратити дані (про це описувалося раніше)
            //а чому небезпено так робити? - бо у базового типу може бути багато різних нащадків
            point.Print();
            //але буде виникати помилка в приведенні, якщо в obj можуть бути дані не Point,
            //і тут в гру вступають as is

            //перший варіант:
            static void Foo(object obj)
            {
                Point5 point = obj as Point5; //використання as не викликає помилок
                //тобто якщо в (object obj) зайдуть дані типу Point то виконається приведення типу
                //і далі перевіряємо чи не null в типі obj
                if (point != null)
                {
                    point.Print();
                }
            }
            Foo(obj);

            //другий варіант (з перевіркою):
            static void Bar(object obj)
            {
                if (obj is Point5 point) //перевірка чи тип obj є типом Point і одразу присвоює в point
                {
                    point.Print();
                }
            }
            Bar(obj);

            //№20: Модифікатор доступа protected при наслідуванні.

            A a = new A();
            a.publicField = 1; //решту полів недоступно через рівень захисту
            B b = new B();
            b.publicField = 2; //решту полів недоступно через рівень захисту
            b.Foo(); //через метод в базовому класі ми отримуємо доступ до private та protected

            //тобто за допомоги такої схеми ми можемо інкапсулювати дані в базовому класі, яку ми можемо використовувати
            //в класах наступниках але без ризику зламати логіку виконання програми

            //№21: Поліморфізм. Віртуальні методи. Virtual override

            Person person3 = new Person();
            person3.Drive(new Car()); //Driving
            person3.Drive(new SportCar()); //Driving fast!
                                           //і нам не треба щось міняти в класі Person

            //№22: Поліморфізмю Абстрактні методи, класи та властивості (+ №24)
            Player player = new Player();
            //інвентар зі зброєю:
            IWeapon[] invetory = { new Gunn(), new LaserGun(), new Bow(), new Knife() };
            //перебираємо зброю:
            foreach (var weapon in invetory)
            {
                player.CheckInfo(weapon);
                player.Fire(weapon);
                Console.WriteLine();
            }
            player.Throw(new Knife());
            //це все поліморфізм в чистому виді

            //№23: Поліморфіз та інтерфейси
            IDataProcessor dataProcessor = new ConsoleDataProcessor();
            dataProcessor.ProcessData(new DbDataProvider()); //вихід Data from DB
            dataProcessor.ProcessData(new FileDataProvider()); //вихід Data from File
            dataProcessor.ProcessData(new APIDataProvider()); //Data from API

            //№25 Явна реалізація інтерфейса.
            MyClass7 myClass7 = new MyClass7();
            Foo2(myClass7);
            Bar2(myClass7); //одна реалізація - MyClass Action... на обидва інтерфейса
            //але треба щоб в одному і тому ж класі викликався різний код (варіант інтерфейса)
            //щоб не викликався один і той самий код треба використовувати явну реалізацію інтерфейса

            MyOtherClass myOtherClass = new MyOtherClass();
            //myOtherClass.Action тут немає, бо він не паблік і ним бути не може, це 1
            //а друге це те що - яку конкретно реалізацію інтрефейса ми хочемо викликати?

            Foo2(myOtherClass);
            Bar2(myOtherClass);
            //а з використанням методів які реалізують ці інтерфейси це можна вивсети так як на потрібно

            //можна ot створити ссилку інтерфейса і присвоїти в екзмепляр класу
            IFirstInterface firstInterface = myOtherClass;
            firstInterface.Action();
            //і вже реалізувати цей інтерфейс

            //або приведення типів
            ((IFirstInterface)myOtherClass).Action();
            ((ISecondInterface)myOtherClass).Action();
            //але тут треба бути обережним.. бо може виникнути помилка в процесі роботи програми

            //тоді краще використати as is (найкращий варіант)
            object obj2 = new object(); //створили об"єкт класу
            if (myOtherClass is IFirstInterface firstInterface2)
            //якщо obj2 є інтерфейсом то виконається код в тілі if а він ним не являється
            //а myOtherClass являється інтерфейсом - код далі виконується
            {
                firstInterface2.Action();
            }
            //так ми реалізовуємо клас який успадковується від інтерфейсів з однаковим кодом всередині

            static void Foo2(IFirstInterface firstInterface)
            {
                firstInterface.Action();
            }
            static void Bar2(ISecondInterface secondInterface)
            {
                secondInterface.Action();
            }

            //№26 Реалізація інтерфейса завмовчанням
            ILogger consoleLogger = new ConsoleLogger();
            consoleLogger.Log(LogLevel.Debug, "some event");
            consoleLogger.Log(LogLevel.Warning, "some warning");
            consoleLogger.Log(LogLevel.Fatal, "some fatal error");

            //реалізація інтерфейса за вмовчанням
            //суть заключається в тому що ми в самому інтерфейсі можемо писати якийсь код
            //що раніше не могли (раніше могли писати тільки сігнатуру методів)
            //але ця фіча спорна і неоднозначна, тому що ми додаємо реалізацію на рівень абстракції
            //тобто змішуємо їх, що порушує первоначальні цілі інтерфейсів - контракти на реалізацію
            //яку виконують конкретні класи
            //зробити це можна за допомоги розширення

            consoleLogger.LogError("some error");
        }
    }
}