using _21._ООП;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._ООП__1___Класс
{
    class NewStudent : Person //один клас наслідує інший клас
    {
        //і він отримує все те що властиво класу який наслідується + додається новий функціонал:
        public void Learn()
        {
            Console.WriteLine("i'm learning!");
        }
    }

}
