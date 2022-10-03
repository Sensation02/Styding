using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCalculator
{
    internal class Apple : Product
    {
        public Apple(string name)
        {
        }

        public Apple(string name, int calorie, int volume) : base(name, calorie, volume)
        {

        }


        //дві онакові дії:
        public static Apple Add(Apple apple1, Apple apple2)
        {
            var calories = (int)Math.Round(((apple1.Calorie + apple2.Calorie) / 2.0));
            var volume = apple1.Volume + apple2.Volume;
            var apple = new Apple("Apple", calories, volume);

            return apple;
        }

        //метод оператор + (1 доданок, 2 доданок)
        public static Apple operator + (Apple apple1, Apple apple2) //це оператор додавання
        {
            var calories = (int)Math.Round(((apple1.Calorie + apple2.Calorie) / 2.0));
            var volume = apple1.Volume + apple2.Volume;
            var apple = new Apple("Apple", calories, volume);

            return apple;
        }
        /* Також є оператор: 
         * віднімання "operator - "; 
         * ділення "operator / "; 
         * множення "operator * "; 
         * Також оператори логічні та відношення 
         * Якщо є оператор != то має бути і == ; також тут можуть бути і унарні оператори*/

        //перегрузка оператора:
        public static Apple operator +(Apple apple1, int volume) //це оператор додавання
        {
            var apple = new Apple("Apple", apple1.Calorie, apple1.Volume + volume);

            return apple;
        }

        //оператор порівння
        public static bool operator ==(Apple apple1, Apple apple2)
        {
            return apple1.Name == apple2.Name; //порівняли до прикладу два яблука по імені
        }
        public static bool operator !=(Apple apple1, Apple apple2)
        {
            return apple1.Name == apple2.Name;
        }

        //також було би дуже добре переоприділити:
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //це все робиться якщо треба переоприділяти певні дані тощо
    }
}
