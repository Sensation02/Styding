using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Анонімні типи - такий собі синтаксичний цукор який дозволяє нам створювати об"єкти певного типу 
    без вказування класа який використовується. Такі типи можуть викликати помилки, 
    тому їх треба використовувати з обережністю. Також в них ми не можемо міняти значення властивостей, 
    тобто коли ми об"являємо анонімний тип ми одразу задаємо властивості, які доступні по суті тимчасово. 
    Вони хороші коли треба щось зробити тут і зараз, і тільки тут.

    Кортежі - дозволяють нам створювати нобари даних одного або декількох типів. Наприклад в нас є массив
    з одним типом даних, а кортежі допомагають нам його створити швидко, щоб потім використовувати в методах
    класах тощо. Тобто для економії часу, без створення класу. Але ціленаправлено їх створювати не треба, 
    також уникати ситуації коли їх треба створювати. Краще створити клас або структуру і туди помістити колекцію.
    
    якщо вже дуже треба і цього не уникнути, тоді розрподіляють два їх типи:
    1. Value Tuple
    2. Tuple
    
 */
namespace Anonymous_Type__ValueTuple__Анонімні_типи__кортежи_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region anonymous type
            var i = 0; //type int

            //anonymous type:
            var product = new
            {
                Name = "Milk",
                Energy = 100
            };
            //при чому всі ці значення доступні в режимі "тільки для читання" (readonly)
            //змінити ми їх не можемо і являється як "+" так і "-"

            Console.WriteLine(product); // Name = "Milk", Energy = 100
            Console.WriteLine(product.Energy); // 100
            Console.WriteLine(product.Name); // Milk

            // Далі, наприклад, ми хочемо об"єднати колекцію чого (їжі) і ми не хочемо робити окремий клас
            // Але хочемо зробити строгу відповідність

            var eat = new Eat()
            {
                Name = "Meat"
            };

            var product2 = new
            {
                eat.Name, // конкретного імені не задаємо, але беремо його з класа - М"ясо
                Energy = 200
            };

            Console.WriteLine(product2); // Name = "Meat", Energy = 200

            //тобто анонімні типи це таке собі спрощення життя
            #endregion

            #region ValueTuple & Tuple
            Tuple<int, string> tuple = new Tuple<int, string>(5, "Hello"); //пара значень, макс - 8 значень

            // варіанти виведення:
            Console.WriteLine(tuple.Item1 + " " + tuple.Item2);

            var item1 = tuple.Item1; // 5
            var item2 = tuple.Item2; // "Hello"
            Console.WriteLine(item1 + " " + item2);

            var tuple2 = (5, "Hello"); //цей варіант дуже не часто використовується (Nuget - systemvaluetuple)
            Console.WriteLine(tuple2);

            // кортежі класно використовувати коли з метода потрібно повернути більше одного значення
            // при чому їх треба отримати тут і зараз, і більше ніде їх не використовувати

            // відмінності між Value Tuple та Tuple
            // в Tuple використовуються стандартні імена типу Item1, Item2 тощо
            // в Value Tuple все по іншому, там можна задавати

            var tuple3 = (Name: "Tomato", Energy: 10);
            tuple3.Name = "Cabbage";
            tuple3.Energy = 20;
            // в таких кортежах можна міняти імена і значення полів
            // також для них неможна задавати якісь методи

            // тобто вони потрібні тільки для того щоб зібрати якісь хаотичні дані в одну конструкцію
            // якийсь один об"єкт який буде представляти всю цю інформацію

            // все це добре використовувати коли в проєкті дуже багато класів і ми не хочемо засмічувати
            // його ще одним класом

            var result = GetData();
            result.Number = 200; // і тут ми через . звертаємося або до Item1 якщо це Tuple
                                 // або до Number якщо це Value Tuple
            Console.WriteLine(result); // (200, ID, True)
            #endregion


            Console.ReadLine();
        }

        public static (int Number, string Name, bool Flag) GetData()
        // створюємо кортеж, якщо без імен -> Tuple, якщо писати тут імена -> Value Tuple 
        {
            var number = 7821; // метод отримання даних
            var name = Guid.NewGuid().ToString(); // метод повернення даних
            bool b = number > 500; // перевірка умови

            return (number, name, b);


        }
    }
}
