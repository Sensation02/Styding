using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26.Interface__new_
{
    internal interface ICar : IStartEngine //якщо ми тут пишемо успадкування від ще одного інтерфейса
        //всі класи які упадковуються від цих інтерфейсів мають прописувати реалізацію вказаного
        //інтерфейса
    {
        /// <summary>
        /// Виконати переміщення
        /// </summary>
        /// <param name="distance"> Відстань. </param>
        /// <returns> Час руху. </returns>
        int Move(int distance);
    }
}
