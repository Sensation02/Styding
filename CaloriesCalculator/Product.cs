using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCalculator
{
    internal class Product
    {
        public string Name { get; set; }
        public int Calorie { get; set; }
        public int Volume { get; set; }

        public double Energy 
        {
            get => Volume * Calorie / 100.0;
        }
        public Product()
        {

        }
        public Product(string name )
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }
        public Product(string name, int calorie, int volume)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (calorie < 0)
            {
                throw new ArgumentNullException(nameof(calorie));
            }
            if (volume <= 0)
            {
                throw new ArgumentNullException(nameof(volume));
            }
            Name = name;
            Calorie = calorie;
            Volume = volume;

        }

        public override string ToString()
        {
            return $"{Name}. Calories: {Calorie}, Volume: {Volume}";
        }
    }
}
