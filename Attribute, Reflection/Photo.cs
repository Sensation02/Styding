using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute__Reflection
{
    // для приєднання метаданих (Attribute):
    [Geo(10, 20)] // координати де зробили фото
    // вказані цифри (координати) будуть спільними для всіх екземплярів класа
    // для роботи атрибутів з властивостями треба вказувати це тільки перед проперті
    // і надалі ми зможемо отримати доступ по атрибутам тільки до того, що вказано 
    internal class Photo
    {
        [Geo(20, 30)]
        public string Name { get; set; }
        public string Path { get; set; }
        public Photo(string name)
        {
            // перевірка

            Name = name;
        }
        public Photo(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
