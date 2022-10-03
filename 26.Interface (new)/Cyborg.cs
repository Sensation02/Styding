using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26.Interface__new_
{
    internal class Cyborg : ICar, IPerson //клас який реалізовує декілька інтерфейсів
    {
        //реалізація двох інтерфейсів:
        //так буває рідко, коли ми реалізовуємо два однакових інтерфейса
        //тому взагалому це розмежовується і треба явно реалізовувати інтерфейси
        int IPerson.Move(int distance) 
        {
            return distance / 20;
        }
        
        int ICar.Move(int distance) //при такій реалізації ми вже пишемо ICar.Move і тд.
        {
            return distance / 100;
        }
    }
}
