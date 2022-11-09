using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
/*
Іноді виникає потреба перетворити тип даних збереження з одного на інший
Приклад, ООП, коли ми працюємо з класама та їх об"єктами через методи
але іноді треба це перетворити щоб можна було зберегти на жорсткий диск, наприклад, щоб відновити роботу

Serialization - дозволяє перетворювати об"єкти класів у потоковий формат, формат якогось файлу,
де будуть збережені всі властивості всіх значень і покласти це все на жорсткий диск чи, наприклад, на сервер
чи комусь відправити у вигляді повідомлення і вже через це повідомлення відновити роботу.

Тобто процес автоматизації, або збереження, процес перевода процеса що зберігається в оперативній пам"яті
в текстовий формат на жорсткий диск тощо. Як збереження в іграх, бекап програм тощо

Його можна зробити самому, через якийсь метод, який буде перебирати весь код і зберігати у файл,
щоб не витрачати час на придумування чогось (велосипеда), а брати все готове.

Формати в яких все зберігається:
1. Бінарний (серіалізується все)
2. SOAP формати (серіалізується все)
3. XML (private не серіалізується)
4. JSON (треба кожну властивість відмічати атрибутом серіалізації)


*/
namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Groups & Students
            var groups = new List<Group>(); // список груп в кількості 9
            var students = new List<Student>(); // список студентів

            for (int i = 1; i < 10; i++) // створюємо групи
            {
                groups.Add(new Group(i, "Група #" + i)); // додаємо у список
            }

            for (int i = 1; i < 10; i++) // створюємо студентів
            {
                var student = new Student(Guid.NewGuid().ToString().Substring(0, 5), i % 100)
                // присвоюємо студенту рандомне ім"я на основі Guid і даємо вік (i % 100)
                {
                    Group = groups[i % 9] // присвоюємо студенту номер групи
                };
                students.Add(student); // додаємо студента у список студентів
            }
            #endregion

            // безпосередньо тема серіалізації:
            // додаємо атрибути серіалізації нашим класам (рефлексія)
            // це все буде потрібно для серіалізацій

            #region Binary Serialization
            // створюємо об"єкт бінарної серіалізації та підключаємо відповідний using
            var binFormatter = new BinaryFormatter();

            // далі безпечна робота з потоком
            using (var file = new FileStream("group.bin", FileMode.OpenOrCreate))
            // FileMode.OpenOrCreate створює файл якщо такого не існує, якщо є - відкриває його
            {
                binFormatter.Serialize(file, groups);
                // (наш_поток, клас_який_серіалізуємо)
            }
            // тобто наша робота зберігається в текстовий файл
            // надалі при запуску роботи буде відкриватися цей файл і відновлюватися всі дані з нього 
            // і так можна робити зі всією своєю роботою

            // відновлюємо свою роботу (десеріалізуємо): 
            using (var file = new FileStream("group.bin", FileMode.OpenOrCreate))
            {
                var newGroups = binFormatter.Deserialize(file) as List<Group>;
                // десеріалізуємо з вказанням нашого файла, але буде повертатися тип даних -> object
                // тому приводимо до нашого списку груп назад -> as List<Group>

                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }

            Console.ReadLine();
            Console.WriteLine();

            #endregion

            #region SOAP 
            // Simple Object Access Protocol - згода по якій певним чином формуються данні в файлі,
            // що дозволяє різним користувачам коректно їх прочитати

            // дуже схожа на бінарну, тому що реалізують одни і той самий інтерфейс

            var soapFormatter = new SoapFormatter();
            using (var file = new FileStream("group.soap", FileMode.OpenOrCreate))
            // тут вже розширення файла інше -> group.soap
            {
                soapFormatter.Serialize(file, groups.ToArray());
                // groups.ToArray() - переводимо в масив 
            }
            using (var file = new FileStream("group.soap", FileMode.OpenOrCreate))
            {
                var newGroups = soapFormatter.Deserialize(file) as Group[];
                // newGroups як(as) масив Group[]

                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }

            Console.ReadLine();
            Console.WriteLine();

            // тобто вся різниця лише у зміні формата файла в який зберігається
            // але він не може працювати зі списком, а працює з масивом тому це треба враховувати
            // і де треба це змінювати

            #endregion

            #region XML
            // він не використовує інтерфейс форматера і не серіалізує приватні поля

            var xmlFormatter = new XmlSerializer(typeof(List<Group>));
            // тут вже треба вказувати тип того, що серіалізуємо -> typeof(List<Group>)

            using (var file = new FileStream("group.xml", FileMode.OpenOrCreate))
            // тут вже розширення файла інше -> group.xml
            {
                xmlFormatter.Serialize(file, groups);
                // знову список
            }
            using (var file = new FileStream("group.xml", FileMode.OpenOrCreate))
            {
                var newGroups = xmlFormatter.Deserialize(file) as List<Group>;
                // має співпадати - список до списка де в typeof і тут List<Group>

                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }

            Console.ReadLine();
            Console.WriteLine();


            // даний варіант серіалізації більш економічний

            #endregion

            #region JSON

            // для цієї серіалізації треба змінювати тег атрибута в класі студентів на [DataContract]
            // причому треба відмічати кожне поле яке треба серіалізувати за допомоги [DataMember]

            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Student>));
            // також вказуємо тип того, що серіалізуємо, в даному випадку Student[]

            using (var file = new FileStream("students.json", FileMode.Create))
            // тут вже інший файл з відповідним розширенням -> students.json
            {
                jsonFormatter.WriteObject(file, students);
                // зміна на WriteObject + незабуваємо про зміну з одного типу (група) на іншу (студенти)
            }
            using (var file = new FileStream("students.json", FileMode.OpenOrCreate))
            {
                var newStudents = jsonFormatter.ReadObject(file) as List<Student>;
                // зміна на newStudents + ReadObject + масив має співпадати

                if (newStudents != null)
                {
                    foreach (var student in newStudents) //знову змінюємо
                    {
                        Console.WriteLine(student);
                    }
                }
            }
            
            Console.WriteLine();

            #endregion

            // на виході файли серіалізації:
            // - бінарний - 769 байт
            // - soap     - 4305 байт
            // - xml      - 873 байти
            // - json     - 226 байт - найкращий варіант

            Console.ReadLine();
        }
    }
}
