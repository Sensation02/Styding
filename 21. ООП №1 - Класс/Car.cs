using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._ООП__1___Класс
{
    internal class Car
    {
        private int speed = 0;

        public void PrintSpeed()
        {
            if (speed == 0)
            {
                Console.WriteLine("стоїмо на місці");
            }
            if (speed > 0)
            {
                Console.WriteLine($"Рухаємося зі швидкістю {speed} км\\г ");
            }
            if (speed < 0)
            {
                Console.WriteLine($"Рухаємося назад зі швидкістю {speed} км\\г ");
            }
        }
        public void DriveForward()
        {
            speed = 60;
        }
        public void Stop()
        {
            speed = 0;
        }
        public void DriveBackward()
        {
            speed = -5;
        }

        //поліморфізм:
        public virtual void Drive()
        {
            Console.WriteLine("Driving");
        }

        protected virtual void StartEngine() 
            //private доступно тільки в цьому класі і ми не можемо його зробити віртуальним тому краще це робити з Protected
        {
            Console.WriteLine("Engine started!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\t == Car 1 ==");
            var car = new Car();
            car.PrintSpeed();
            car.DriveBackward();
            car.Stop();
            car.DriveForward();
            car.PrintSpeed();

            Console.WriteLine("\t == Car 2 ==");
            var car2 = new Car();
            car2.PrintSpeed();
            car2.DriveForward();
            car2.PrintSpeed();
        }

    }
}
