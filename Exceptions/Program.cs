using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //var i = 5;
            //var j = i / 0; exception - ділити на 0 неможна

            //int a = 200000000;
            //int b = 200000000;
            //int c = checked(a * b); і тут нам буде вибиватися помилка переповнення, тому що число більше
            //чим може вміститися в int

            while (true) //безкінечний цикл
            {
                var input = Console.ReadLine(); //вели якісь дані
                if (int.TryParse(input, out int result)) //перевіряємо чи ввели ціле число
                {
                    Console.WriteLine($"інтовий {result}"); //якщо правильно ввели
                    break; //вихід із циклу
                }
                else
                {
                    Console.WriteLine("некоректний код. введи ціле число"); //якщо неправильно ввели
                }
            }

            var i = 5;
            var j = i / 0;
            Console.WriteLine(j);


            try
            {
                //тут код який потенційно може мати загрозу, слідкуємо за ним, якщо отримуємо помилку йдемо далі


                throw new DivideByZeroException("Error");
                //генеруємо помилку, далі відповідно спрацює блок з повідомленням про цю помилку

                //throw new ArgumentNullException("i", "fix this");
                //вивели перемінну і наше повідомлення 

                throw new MyOwnException();
                //створили свою помилку
            }
            catch (MyOwnException ex) 
            //виводимо повідомлення про свою помилку
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex) when (i == 5)
            //за допомоги when можна робити додаткові умови
            //і буде відловлено саме що дає помилку
            //якщо var і = 6; то буде спрацьовувати throw new DivideByZeroException();
            //також за допомоги when створюється фільтр помилки, ніби додаткова градація одніє і тієїж помилки
            {
                Console.WriteLine("ділення на нуль (i == 5)");
                //через ex. можна передати точніші дані як саме відбулася помилка

                //тут - throw new DivideByZeroException("Error"); - задали повідомлення
                //тут його вивели - ex.Message - "Error" 
            }
            catch (Exception ex)
            {
                //(тип_помилки назва_перемінної) але ці дужки необов"язкові, тільки якщо конкретно шукаємо
                Console.WriteLine(ex.Message);
                //відловили помилку, зафіксували, записали її
                //throw; - кинули помилку далі
                //і таких блоків catch може бути багато
                //ще блоки catch мають бути у правильному порядку, це середовище розробки нам підкаже
                //якби DivideByZeroException був нижче цього блоку було б помилка, тому він має бути зверху 
            }
            finally
            {
                //тут поміщається блок коду який обов"яжково мусить виконатися, що не виконався в блоці try
                //тобто в try виконується код допоки не вилізе помилка,
                //після виникнення помилки код далі не виконується
                //для цього і потрібен блок finally, щоб виконати той код який невиконався через помилку
                //але він не є обов"язковим
                Console.WriteLine("work is done");
                Console.ReadLine();
            }
        }
    }
}