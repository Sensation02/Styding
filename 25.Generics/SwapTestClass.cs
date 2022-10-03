using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25.Generics
{
    /// <summary>
    /// зміна даних об"єктів місцями
    /// </summary>
    public static class SwapTestClass
    {
        public static void GenericSwap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        public static void Swap(ref object a, ref object b)
        {
            object temp = a;
            a = b;
            b = temp;
        }
        //по результатам бенчмарка дженерік метод працює краще і швидше, менше витрачається пам"ять
        //звичайний метод забирає багато пам"яті і працює повільніше через упаковку типів даних
        //з інт в обжект
    }
}
