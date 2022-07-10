using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учоба
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double FirstValue, SecondValue, ThirdValue;
            System.Console.WriteLine("Type your first value");
            FirstValue = double.Parse(Console.ReadLine());
            System.Console.WriteLine("Type your second value");
            SecondValue = double.Parse(Console.ReadLine());
            System.Console.WriteLine("Type your third value");
            ThirdValue = double.Parse(Console.ReadLine());
            double sumresult = (FirstValue + SecondValue + ThirdValue);
            double multresult = (FirstValue * SecondValue * ThirdValue);
            System.Console.WriteLine("Your summ result is: " + sumresult);
            System.Console.WriteLine("Your mult result is: " + multresult);
            Console.ReadLine();
        }
    }
}
