using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21._ООП;

namespace _21._ООП__1___Класс
{
    class DbRepository //клас який має організовувати роботу з якоюсь SQL базою даних
                       //і нам потрібна буде інформація про строку підключення до бази даних
                       //така строка має бути одна і та ж для кожного об"єкта і в такому випадку немає змісту
                       //виділяти пам"ять для кожного об"єкта щоб зберігати цю саму строку ()це трата пам"яті)
                       //тут використовується клас зі статичним конструктором який буде зберігати цю строку
                       //з посиланням на базу даних для всіх об"єктів
    {
        private static string connectionString = "local DB";

        //без такого статичного конструктора нам прийдеться кожний раз залазити в конфіг і міняти адрес
        //і кожний раз створювати програму наново

        //як ми це все можемо зробити?

        static DbRepository() //через public дуже затратно для пам"яті тому робимо його статичним
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            connectionString = connectionString.GetConnectionString();
        } //так ми звертаємося один раз до бази даних і ця строка з посиланням
          //буде розповсюджуватися на кожний об"єкт класу і це економія


        public void GetData()
        {
            Console.WriteLine("Using: " + connectionString);
        }
    }

    class ConfigurationManager
    {
        public string GetConnectionString()
        {
            return "local DB"; //тут ніби тягнуться дані з реального файлу конфіга
        }
    }

    class Program
    {
        DbRepository dbRepository = new DbRepository();

        dbRepository.GetData();
    }
}
