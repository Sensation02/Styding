using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25.Generics
{
    internal class MyList<T>
    {
        private T[] array = Array.Empty<T>(); //повертаємо в ролі значення метод Empty класу Array
        //new T [0] не можемо використати тому що на це використовується пам"ять в кучі під масив який ми ніколи не будемо
        //використовувати так як в ньому 0 елементів
        //метод масиву "пустий"(Empty) робить впринципі те саме але повертає ссилку на статичне поле класу Array
        //а статичне поле створюється і використовується лише один раз і це працює як "заглушка" і ми використаємо менше пам"яті

        public T this[int index]
        //індексатор який дозволяє звертатися до колекції (той самий список)
        //і через [int index] ми можемо або додати елемент, або витягнути
        {
            get { return array[index]; } //повертаємо елемент по індексу
            set { array[index] = value; } //отримуємо елемент по індексу
        }
        public int Count { get { return array.Length; } } //повертає к-сть елементів

        public void Add(T value) //метод додавання елементу в колекціют
        {
            var newArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++) //збільшуємо к-сть елементів у масиві
            {
                newArray[i] = array[i];
            }
            newArray[array.Length] = value;
            array = newArray;
        }
        //і скрізь як тип даних ми вказуємо <T>
        //насправді у класі List все працює по іншому, там не виділяється пам"ять в кучі і не виконується копіювання всіх елементів


    }
}
