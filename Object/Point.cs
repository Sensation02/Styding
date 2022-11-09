using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object
{
    internal class Point
    {
        public int X { get; set; }

        public Point Y { get; set; } // це тут тільки для прикладу, в роботі це не правильно і погано

        public override bool Equals(object obj) // якщо переоприділяємо Equals то треба переоприділити GetHashCode
        {
            // виконуємо елементарне порівняння в певних жорстких правилах:

            // 1 - він не повинен кидати ексепшн (помилку)
            // наприклад якщо сюди заходить null, його треба коректно обробити і вернути bool значення
            if (obj == null) return false;

            // 2 - він має бути оптимальним, порівнювані об"єкти мають співпадати
            // наприклад некоректно порівнювати землю з хробаком, або смачно і рідкий

            // is as - пригадуємо: 
            // is - повертає булеве значення якщо цей тип являється тим же типом з яким порівнюємо:
            // if (obj is Point);  чи object == Point - true або false, якщо ні

            // as - якщо один об"єкт такого ж типу як інший 
            // при чому об"єкт Point ми перетворюємо в obj - true
            // якщо це не вдається - false

            if (obj is Point point)
            {
                // тут працємо з point так як нам треба:
                return X == point.X;
            }
            else
            {
                return false;
            }
        }

        public override string ToString() 
            // приведення значення до строки (строкового формата)
            // якщо приведення ссилочного типу - буде повернуто повне ім"я об"єкта класа
        {
            return X.ToString();
        }

        public new Type GetType()
        {
            return typeof(UInt16);
        }
        public Point Clone()
        {
            // неглибоке клонування:
            return MemberwiseClone() as Point;

            // глибоке клонування:
            // var result = (Point)MemberwiseClone();
            // result.Y = Y.Clone(); // улюблена рекурсія))
        }
    }
}
