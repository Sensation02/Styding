using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Навчання_ООП
{
    class Bot : RobotBase 
    {
        public Bot(){}

        public Bot(string name) : base(name)
        {
        }

        public Bot(string name, int weight) : base(name, weight) 
        {
        }

        public Bot(string name, int weight, byte[] coordinates) : base(name, weight, coordinates)
        {
        }

        public override void PrintValues()
        {
               Console.WriteLine($"Robot name: {Name}, Weight: {Weight} kg, Height: {Height} sm, Coordinates: ");
               foreach (var item in Coordinates)
               {
                    Console.Write(item);
               }
        }
    }
}
