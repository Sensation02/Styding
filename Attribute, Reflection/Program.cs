using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Дані - наприклад в нас є певний набір даних в яких знаходяться певні корисні дані які нам треба
    прочитати, вони знаходяться у вигляді двоїчного коду який складається з 0 та 1. 

    Як їх інтерпретувати?

    Для цього створені супутні Метадані, які за собою нічого не містять корисного, але вони нам розповідають
    як ці дані читати і використовувати. Наприклад дані про автора твору тобто дані про дані) тощо.
    
    Іноді виникає потреба самостійно прикріпити якісь метадані які будуть додатково передавати якусь інфу
    Для цього буле створено атрибути.

    Attribute - додаткові описові дані, які безпосередньо не зв"язані із тим, що представлено в класі, 
    або слугують для кращої інтерпретації того, що є в класі і дозволяють регулювати поведінку програми
    за допомоги цих метаданих тобто додаткових конструкцій атрибутів
 
    для атрибутів створюємо окреми клас
    для назви такого класа є певна згода в компанії якої потрібно слідкувати
    тобто може додаватися постфікс або суфікс Attribute
    це робиться для того щоб відрізнити цей клас від інших в дереві програми

    Далі створюємо окреми клас атрибута GeoAttribute
    Створили клас Photo з атрибутом який містить координати де зробили фото
 */


namespace Attribute__Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // створили якесь фото зі шляхом до нього:
            var photo = new Photo("Cat.JPG")
            {
                Path = @"D:\Photo\107APPLE\IMG_7702.JPG" //шлях до фото
            };

            var type = typeof(Photo); // опис типу даних

            // далі можемо отримати атрибути нашого класу:
            var attributes = type.GetCustomAttributes(false); // кастомний атрибут
            // отримали колекцію (масив об"єктів) атрибутів нашого класу

            // вивід в консоль наших атрибутів:
            foreach (var attribute in attributes)
            {
                Console.WriteLine("Атрибут класа: ");
                Console.WriteLine(attribute);
            }
            Console.WriteLine();
            // Координати нашого фото: [10; 20]
            // вивели той атрибут який вказаний перед класом

            // але це не основна задача для чого взагалі потрібні ці атрибути
            // основна задача це - можливість отримання даних тільки з певних параметрів
            // які відмічені нашими атрибутами

            // треба отримати набори полів:
            var properties = type.GetProperties();
            Console.WriteLine("пропертi класа: ");
            foreach (var property in properties)
            {

                Console.WriteLine(property.PropertyType + " - " + property.Name);
                // можна і просто написати property

                var attrs = property.GetCustomAttributes(false);
                foreach (var a in attrs)
                {
                    Console.WriteLine($"Атрибут пропертi {property.Name}: ");
                    Console.WriteLine(a);
                    Console.WriteLine();
                }

            }
            Console.WriteLine();
            // System.String - Name;
            // Координати нашого фото: [20; 30]
            // System.String - Path;


            foreach (var property in properties)
            {
                var attrs = property.GetCustomAttributes(false);
                // вивід тільки того проперті, в якого є атрибут:
                
                if (attrs.Any(a => a.GetType() == typeof(GeoAttribute)))
                {
                    Console.WriteLine("Пропертi який має атрибут: ");
                    Console.WriteLine(property.PropertyType + " - " + property.Name);
                }
            }
            Console.WriteLine();
            // System.String - Name;

            // ці атрибути є загальними для всіх об"єктів класа
            // можемо накладати обмеження на ці атрибути щоб уберегтися від помилок
            // треба зробити атрибут для атрибута

            Console.ReadLine();
        }
    }
}
