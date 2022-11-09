using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    // додаємо атрибут для серіалізації з метою захисту щоб не серіалізувати щось не те:
    [Serializable]
    public class Group
    {
        // якщо ми хочещо щоб якийсь елемент класа не буде серіалізованим то ми перед цим полеми пишемо:
        [NonSerialized]
        private readonly Random random = new Random(DateTime.Now.Millisecond);

        // далі поле для прикладу серіалізації приватного поля
        // private int privateInt = 3215933; 
        // після виконання роботи програми це збережеться у файл
        public int Number { get; set; }
        public string Name { get; set; }

        public Group()
        {
            Number = random.Next(1, 10);
            Name = "Група #" + random;
        }
        public Group(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
