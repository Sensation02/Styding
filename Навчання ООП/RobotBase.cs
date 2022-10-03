using Навчання_ООП;

namespace Навчання_ООП
{
    abstract class RobotBase : IRun, IJump 
    //скелет робота (загальна концепція)
    //також будемо тут реалізовувати інтерфейси, яких тут може бути багато і які пишуться через кому
    {
        /* далі будемо вказувати нашому роботу, наприклад, вагу або зріст тощо
         * ці дані мають містити в собі модифікатор доступа: public, private або protected
         * це можна робити до будь якого поля класу чи метода, та і взагалі до метода і класа
         * так реалізується Інкапсуляція */

        /* protected - доступний в даному класі та в його наступниках по Наслідуванні
         * private   - тільки в даному класі або методі, або у {} тощо
         * public    - скрізь буде доступний */

        //поля:
        //public string name;
        //public int weight;
        //public byte[] coordinates; //тут, наприклад, координати знаходження нашого робота

        /* якби був модифікатор private, то в об"єкті класа ми вже не можемо напряму вказувати, наприклад, ім"я
         * щоб звертатися до private, треба зробити методи(функції)
         * через які ми можемо задавати параметри в дані поля */

        //поля з private:
        private int height;
        private string name;
        private int weight;
        private byte[] coordinates;

        /* Тепер будемо все робити через методи(функції)
         * Переведемо наші поля в private, попередні закоментили
         * цей метод має бути з модифікатором public
         * в (), через об"єкт класу, задаємо дані.
         * Ці методи можуть бути різноманітними */

        //public virtual void PrintValues() 
        //    //virtual - через це ми можемо в наступнику змінити цей метод без його змінит тут
        //{
        //    Console.WriteLine($"Robot name: {name}, Weight: {weight} kg, Height: {height} sm, Coordinates: ");
        //    foreach (var item in coordinates)
        //    {
        //        Console.Write(item);
        //    }

        //}

        public abstract void PrintValues(); 
        //зробили метод abstract, реалізацію ми тут вже не пишемо
        //відповідно реалізацію треба прописати в наступниках


        public  void SetCoordinates(byte[] coordinates)
        {
           this.coordinates = coordinates;
        }
        public  void SetHeight(int height) //void - нічого не повертаємо
        {
            this.height = height; //this. - це ключове слово через яке ми звиртаємося до height в нашому класі
        }
        public  void SetName(string name)
        {
            this.name = name;
        }
        public  void SetWeight(int weight)
        {
            this.weight = weight;
        }

        //перегрузка методів:
        public void SetValues(string name, int weight, byte[] coordinates)
        {
            this.name = name;
            this.weight = weight;
            this.coordinates = coordinates;
        }
        public void SetValues(string name) //такий як і SetName
        {
            this.name = name;
        }
        public void SetValues( int weight) //такий як і SetWeight
        {
            this.weight = weight;
        }
        public void SetValues(string name, int weight)
        {
            this.name = name;
            this.weight = weight;
        }


        //конструктори класа: (швидко викликається написанням ctor)
        /* на основі цих конструкторів створюються об"єкти класів, все що ми вказуємо в параметри конструктора
         * потім враховується, тому про це треба подумати і створити декілька конструкторів класа які будуть
         * приймати різноманітні варіанти створення тих тих об"єктів класа. В нашому випадку не кожен робот 
         * може мати дані про вагу або зріст, все це треба враховувати */
        public RobotBase() //конструктор за вмовчанням
        {
            count++;
        }
        public RobotBase(string name) //кон-р який приймає перемінну імені
        {
            this.Name = name;
            count++;
        }
        public RobotBase(int weight) //кон-р який приймає перемінну ваги
        {
            this.Weight = weight;
            count++;
        }
        public RobotBase(byte[] coordinates) //кон-р який приймає перемінну координат
        {
            this.Coordinates = coordinates;
            count++;
        }
        public RobotBase(string name, int weight) //ім"я та вага
        {
            this.Name = name;
            this.Weight = weight;
            count++;
        }
        public RobotBase(string name, byte[] coordinates)
        {
            this.Name = name;
            this.Coordinates = coordinates;
            count++;
        }
        public RobotBase(int weight, byte[] coordinates)
        {
            this.Weight = weight;
            this.Coordinates = coordinates;
            count++;
        }
        public RobotBase(string name, int weight, byte[] coordinates)
        {
            this.Name = name;
            this.Weight = weight;
            this.Coordinates = coordinates;
            count++;
        }
        public RobotBase(string name, byte[] coordinates, int weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.Coordinates = coordinates;
            count++;
        }

        public RobotBase(int height, string name, int weight, byte[] coordinates)
        {
            this.Height = height;
            this.Name = name;
            this.Weight = weight;
            this.Coordinates = coordinates;
        }

        //статичні поля:
        /* вони також мають модифікатор доступа, статичні поля завжди зберігаються в класі, неважливо скільки його 
         * об"єктів було створено. Наприклад ми створили статичне поле про кількість роботів і додали його в конструктори, 
         * і тепер при створення робота (об"єкта класу) ми будемо додавати до їх кількості через статичне поле */
        private static int count; 

        //створимо метод яким міг би нам вивести дані про кількість наших роботів:
        public static void PrintRobotCount()
        {
            Console.WriteLine($"Robots count: {count}");
        }



        //Аксессери:
        /* геттер (get) - повертаємо якісь дані
         * і сеттер (set) - отримуємо дані звідкись 
         * Викликається аксессер сніпетами: prop - якщо коротко; propfull - довше,
         * private get - значить що ми не зможемо отримати дані
         * private set - ми не зможемо їх встановити
         * внизу довший приклад, коли геттер і сеттер розписані (самі розписали) */
        public int Weight 
        {
            get 
            {
                Console.WriteLine("Weight: ");
                return this.weight; 
            }
            set
            {
                if (value < 1) this.weight = 1; //додали перевірку якщо ввели число менше 1
                else if (value > 5000) this.weight = 5000; //якщо вага більше 5000
                else this.weight = value; 
            }

        }

        public int Height { get; set; }
        //(prop) по суті аксессер але дуже схоже на поля, але не враховуються дані які можуть бути введенні
        //як це перевіряється вище

        //Аксессер це зручно тим, що можна в ньому розписати все що нам потрібно без використання методів

        //protected поля добре викоритовувати з наступниками
        protected string surname;

        //створимо новий аксессер для нашого списку:

        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public byte[] Coordinates 
        {
            get { return this.coordinates; }
            set { this.coordinates = value; }
        }

        //реалізація інтерфейсів
        public void Run()
        {
            Console.WriteLine("Robot is running"); //описуємо дію бігу
        }
        public float Speed { get; set; } //проперти інтерфейса

        public void Jump()
        {
            Console.WriteLine("Robot is jumping");
        }
        public int JumpHeight { get; set; }

        //ці інтерфейси в даному випадку описують базові дії наших роботів, ці базові дії в майбутньому можна 
        //буде реалізувати не тільки в роботах, а й наприклад в класах Людини тощо
    }
}