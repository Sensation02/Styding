using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer_yield__індекксатори_ітератори_
{
    internal class Parking : IEnumerable
    //будь яка колекція реалізує інтефейс IEnumerable (+ додається метод public IEnumerator GetEnumerator())
    {
        public string Name { get; set; }
        private const int MAX_CARS = 100;
        public int Count => cars.Count; //кількість машин на паркінгу

        //Індексатор:
        //public Тип_даних_який_повертаємо this [Тип_аргумента Ім"я_аргумента]
        public Car this[string number]
        {
            get
            {
                var car = cars.FirstOrDefault(c => c.Number == number); //шукаємо авто з відповідним номером
                return car;
            }
            //сеттера не буде, ми не будемо задавати індексатор ззовні
        }

        //перегрузка індексатора:
        public Car this[int position]
        {
            get
            {
                if (position < cars.Count)
                {
                    return cars[position];
                }
                
                return null;
            }
            set //по суті заміна автомобіля
            {
                if (position < cars.Count)
                {
                    cars[position] = value;
                }
            }
        }
        //наприклад є набір машин які замають певну позицію
        //і ми цим методом вибираємо ту машину і замінюємо на іншу

        private List<Car> cars = new List<Car>();

        //Додавання машини в паркінг
        public int Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car is null");
            }
            if (cars.Count < MAX_CARS) //перевіряємо ліміт
            {
                cars.Add(car);
                return cars.Count - 1; //-1 тому що індекс стартує з 0
            }
            return -1;

        }

        //видаляємо машини з паркінгу
        public void GoOut(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(nameof(number), "number is null");
            }

            var car = cars.FirstOrDefault(c => c.Number == number);
            if (car != null)
            {
                cars.Remove(car);
            }
        }

        //отримуємо метод перечислення
        public IEnumerator<Car> GetEnumerator()
        //<Car> - конкретний тип даних який ми перебираємо, інакше буде обджект і не буде доступно
        //проперті які є в Car
        {
            //але ми працюємо з готовою колекцією тому використовуємо те що є зі Списком(List)
            return cars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return cars.GetEnumerator();
        }

        //але можна обійтися і без нього за допомоги Yield 
        //простий приклад з числами (Число Фібоначі)
        //на виході вся колекція
        public IEnumerable GetNumbers()
        {
            foreach (var car in cars)
            {
                yield return car;
                //тут ми можемо щось в них змінити
                //наприклад повертаємо авто певної марки:
                //yield return car.Name == "BMW"
            }
        }
    }
    //власне клас Enumerator який дозволяє перебирати елементи колекції
    //він переходить почерзі від одного елемента до іншого
    //тут можна реалізовувати власний перебор колекції
    public class ParkingEnumerator : IEnumerator
    {
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

    }

}
