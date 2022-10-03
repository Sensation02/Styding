namespace Навчання_ООП
{
    enum Type
    {
        Enemy,
        Hero,
        Traitor
    }

    class RobotKiller : RobotBase
    /* наслідування від класу RobotBase
     * наступник має доступ до всьго, що є у батьківського класу: поля, методи, конструктори, аксессери тощо
     * але доступ до всього, що має модифікатори public та protected 
     * base(назва перемінної в батьковського конструктора) - дозволяє нам успадковувати конструктори*/
    {
        public RobotKiller(string name, int weight) : base(name, weight) //додали доступ до конструктора
        {
            
        }

        //додаємо конструктори які б враховували новий функціонал:
        public RobotKiller(int health)
        {
            this.Health = health; 
        }
        public RobotKiller(int health, string name) : base(name)
        {
            this.Health = health;
        }
        public RobotKiller(string name, byte[] coordinates, int health) : base (name, coordinates, health)
        {
            this.Health = health;
        }
        public RobotKiller(string name, int weight, byte[] coordinates, int health) : base (name, weight, coordinates)
        {
            this.Health = health;
        }
        public RobotKiller(int haight, string name, int weight, byte[] coordinates, int health) : base(haight, name, weight, coordinates)
        {
            this.Health = health;
        }
        public RobotKiller(string name, int weight, byte[] coordinates) : base(name, weight, coordinates)
        {
        }
        public RobotKiller(int haight, string name, int weight, byte[] coordinates, int health, Type type) : base(haight, name, weight, coordinates)
        {
            this.Health = health;
            this.type = type;
        }

        public RobotKiller(string name, int weight, byte[] coordinates, int health, Type hero) : this(name, weight, coordinates, health)
        {
            this.Health = health;
            this.type = type;
        }

        public int Health { get; set; } //додали новий функціонал до наступника

        //
        public Type type { get; set; }

        public void PrintKillerValues()
        {
            //base.PrintValues(); //використовуємо метод батьківського класу
            Console.WriteLine($" Killer health: {Health}");
        }

        public override void PrintValues()
        {
            //base.PrintValues(); // - це дописується автоматично, ми можемо це не використовувати

            //з абстракцією ми прописуємо реалізацію так як строка написана вище не буде працювати
            Console.WriteLine($"Robot name: {Name}, Weight: {Weight} kg, Height: {Height} sm, Coordinates: ");
            foreach (var item in Coordinates)
            {
                Console.Write(item);
            }

            Console.WriteLine(" Health: " + Health); // і допомвнюємо його чимось новим

            if (this.type == Type.Hero) 
                //робимо перевірку на наше перечислення з виводом інфи про те якого "типу" цей робот
            {
                Console.WriteLine("This robaaat is HEEEEROOO");
            }
            else if (this.type == Type.Enemy)
            {
                Console.WriteLine("OMG it's an ENEMY!!!");
            }
            else
            {
                Console.WriteLine("IT'S TRAITOOOR");
            }
        }

        //реалізація protected поля з батьківського класа в класі наступнику:
        public void SetSurname(string surname)
        {
            this.surname = surname;
        }

        //новий функціонал у класі наступнику:
        public void LazerAttak()
        {
            Console.WriteLine("PEWPEEWWW!");
        }

    }
}