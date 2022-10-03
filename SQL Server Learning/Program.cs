using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Server_Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //працюємо в БД
            
            //створюємо підключення до нашої віртуальної БД
            //так можна створити тестову БД і вже з нею проводити всі тести, що нам потрібні
            //а як треба бойову БД - підключаємося до бойової
            //все це відбуваєтться через App.Config (DbConnectionString)
            using (var context = new MyDbContext())
            //до речі через using відкриття і закриття БД відбувається автоматично
            {
                //створюємо екземпляри
                var group = new Group()
                {
                    Name = "White Snake",
                    Year = 1968
                };
                var group2 = new Group()
                {
                    Name = "Linkin Park"
                    
                };

                //в контексті вибираємо колекцію:
                context.Groups.Add(group);
                context.Groups.Add(group2);
                //але ми ще не додаємо до БД, це ще проміжний етап, кешоване зберігання
                //для цього є команда:
                context.SaveChanges();

                //додаємо пісні, це обов"язково робиться після створення наших груп
                //тобто ми зберігаємо наші групи в БД, нам повертається екземпляр з ідентифікатором
                //і після цього ми виконаємо створення іншої таблиці на основі цих отриманих ідентифікаторів
                var songs = new List<Song>()
                {
                    new Song() {Name = "In The End", GroupId = group2.Id},
                    new Song() {Name = "Is This Love", GroupId = group.Id},
                    new Song() {Name = "Numb", GroupId = group2.Id}
                };



                //зберігаємо наші пісні:
                context.Songs.AddRange(songs);
                //додаємо БД:
                context.SaveChanges();

                //вивід через цикл ім"я групи (яке прив"язано по ідентифікатору до пісні) та назву пісні
                foreach (var song in songs)
                {
                    Console.WriteLine($"Group name is: {song.Group.Name}, with song: {song.Name}");
                }

                //зміни таблиць і коміти (міграція) в БД
                //наприклад додати нове поле, проперті в наші класи (дивимося клас Group)

                // ... після написання PM>enable-migrations у вікні під полемо коду
                // створиться окремий файл міграції де описаний метод який нам допомагаю в цій міграції
                // пишемо внизу PM>update-database і воно оновить, але це треба робити до створення БД
                // якщо додавати в процесі роботи з БД, то використовується постійна команда
                // PM> add-migration ім"я міграції і вже після цього знову PM>update-database 

                //Підсумки:
                // 1. на самому старті проекта - enable-migrations
                // 2. після кожної зміни БД    - add-migration
                // 3. оновлення БД             - update-database 

                //варіант зміни назви групи з використанням LINQ
                //var s = context.Groups.Single(x => x.Id == group2.Id);
                //s.Name = "Papercut";
                //але про це пізніше
                //context.SaveChanges();

                Console.ReadLine();
            }
            //в SQL menagement studio створилася нова таблиця з нашою групою та піснями
        }
    }
}
