using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._ООП__1___Класс
{
    static class MyExtensions
    {
        //при опису extension обов"язково пишемо this, потім вхідний тип даних, назва будь яка
        public static void Print(this DateTime dateTime)
        {
            Console.WriteLine(dateTime);
        }
        //перевірка сьогоднішнього дня
        public static bool IsDayOfWeek(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            return dateTime.DayOfWeek == dayOfWeek;
        }
    }
}
