using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26.Interface__new_
{
    internal class BMW : ICar
    {
        public int Move(int distance)
        {
            return distance / 100;
        }
        public string StartEngine(string word)
        {
            if (word == "Start")
            {
                return "Engine started";
            }
            else
            {
                return "Start Engine!";
            }
        }
    }
}
