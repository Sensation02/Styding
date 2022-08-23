using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._ООП__1___Класс
{
    internal class Gun
    {
        //ctor - скорочення(сніпет) для створення класу (або конструктор) ..далі нажимаємо 2 рази tab
        public Gun() //тут можна додати (bool isLoaded)
                     //при додаванні конструктора в даний клас, ми автоматично робимо так,
                     //що всі пушки вже будуть заряджені
        {
            IsLoaded = true;
            //тут може бути і Reload, тоді робота класу почнеться з перезарядки 
        }
        //тобто конструктор дозволяє нам змінювати дані класу без втручання в його роботу (не порушуємо інкапсуляцію)

        private bool IsLoaded;

        private void Reload()
        {
            Console.WriteLine("Заряджаю...");
            IsLoaded = true;
            Console.WriteLine("Заряджено!");
        } //всередину класу можна використовувати, поза нього - ні
        public void Shoot()
        {
            if (!IsLoaded)
            {
                Console.WriteLine("Зброя не зарадженя!");
                Reload();
            }
            Console.WriteLine("Постріл!\n");
            IsLoaded = false;
        } //можна поза класу

        //тобто в даному випадку "зброєю" ми можемо тільки стріляти, перезарядка відбувається сама по собі


    }
}
