namespace _26.Interface__new_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cars = new List<ICar>();
            cars.Add(new Audi());
            cars.Add(new BMW());

            foreach (var car in cars)
            {
                Console.WriteLine(car.Move(200));
                
            }
            Console.ReadLine();

            //реалізували інтерфейс часу руху машини
            //таких інтерфейсів може бути безліч, наприклад "сфотографувати"
            //і вже класами ми реалізовуємо роботу, або "зателефонувати" 
            //і реалізовуємо дзвінок, і тд і тп.

            Cyborg cyborg = new Cyborg();
            //cyborg.Move(200); 
            //відповідно просто так доступ ми не отримуємо, треба вже вказувати інтерфейс:
            Console.WriteLine( ((ICar)cyborg).Move(200) );
            Console.WriteLine( ((IPerson)cyborg).Move(200) );
            //це була явна реалізація інтерфейса, ми його вказали, наверху напочатку - це неявна.

            //Почергове успадкування інтерфейсів
            //якщо наш інтерфейс ICar успадковується ще від одного інтерфейса, тоді в класах ми маємо
            //прописати реалізація і цього інтрефейса (IStartEngine)

            Audi audi = new Audi();
            Console.WriteLine(audi.Move(100) + " " + audi.StartEngine("Start"));
            
            
        }
    }
}