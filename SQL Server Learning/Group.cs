using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Server_Learning
{
    //модель для групи
    public class Group
    {
        //створюємо ідентифікатор, зачастую це Id, або ім"я цього класу + Id = GroupId
        //можна і по іншому але перед таким проперті має бути [Key]
        public int Id { get; set; }
        //у нашої групи є ім"я
        public string Name { get; set; }
        //до речі string може і не стояти якщо не стоїть атрібут рекваєрмент в SQL таблиці
        //але int має бути точно, якщо нам і таке поле треба щоб було необов"язковим то має бути так:
        public int? Year { get; set; }

        //зв"язок із іншою таблицею:
        public virtual ICollection<Song> Songs { get; set; }
        //тобто в кожної групи буде берегтися колекція пісень
        //але потрібен і зворотній зв"язок

        //додаємо щось нове в БД, чого що там ще немає і поки що там не буде відображатися
        //після створення такого з послідуючим запуском програми буде виникати помилка
        //тому це треба все робити правильно - синхронізувати
        //для цього йдемо (наверху) View -> Other Windows -> Packege Manager Console
        //це робиться один раз для проекта, повторювати непотрібно
        //ми ніби надаємо дозвіл на міграцію (коміт і далі робота в основній програмі) ... 
        public string Ganre { get; set; }
    }
}
