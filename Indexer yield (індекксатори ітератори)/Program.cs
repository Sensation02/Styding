using System;
using System.Collections.Generic;

/*
    Indexer (Індексатор) - для того щоб звератится до якогось елемента колекції по якомусь індексу
    наприклад: Список (парковка) в якій певна кількість машин і машину ми можемо шукати по якомусь признаку

    Yeild (Ітератор)

 */

namespace Indexer_yield__індекксатори_ітератори_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cars = new List<Car>() //створили наші машини
            {
                new Car() { Name = "Ford", Number = "AA 0001 AA" },
                new Car() { Name = "Lada", Number = "AA 0002 AA" }
            };

            var parking = new Parking(); //створили паркінг

            foreach (var car in cars) //додали машини в паркінг
            {
                parking.Add(car);
            }

            //переходимо до нашої теми:

            Console.WriteLine(parking["AA 0001 AA"]?.Name);
            Console.WriteLine(parking["AA 0003 AA"]?.Name);
            //звертаємося до парковки по індексу
            //тобто ми зробили метод доступа по індексу, або ще метод запроса
            //ніби обгортка для роботи з колекціями

            Console.WriteLine("Type any index, smthn like this: AA 2030 AA");
            var num = Console.ReadLine();

            parking[1] = new Car() { Name = "BMW", Number = num };
            Console.WriteLine(parking[1]);
            //даними маніпуляціями ми ввели з консолі те що має бути в якості номера машини
            //і вивели цю інформацію
            Console.WriteLine();

            //тепер використовуємо Енумератор
            foreach (var car in parking) //без наслідування від Енумерeбл, тут в parking була б помилка
            {
                Console.WriteLine("Car name & number:" + car);
            }
            Console.WriteLine();

            //але можна обійтися і без нього за допомоги Yeild
            //тобто ми будемо повертати всю колекцію
            foreach (var name in parking.GetNumbers())
            {
                Console.WriteLine("car name:" + name);
            }
            //але при кожному звертанні послідовність вибудовується наново і це дуже довго

            Console.ReadLine();
        }
    }
}