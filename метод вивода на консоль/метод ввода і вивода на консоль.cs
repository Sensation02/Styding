using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace метод_вивода_на_консоль
{
    internal class leson
    {
        static void PrintLine(string symbol, uint symbolsCount)
        {
            for (int i = 0; i < symbolsCount; i++)
            {
                Console.Write(symbol);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter your symbol");
            string symbol = Console.ReadLine();
            Console.WriteLine("enter you symbols count");
            uint symbolsCount = uint.Parse(Console.ReadLine());
            PrintLine(symbol, symbolsCount);
            Console.ReadLine();
        }
    }
}
