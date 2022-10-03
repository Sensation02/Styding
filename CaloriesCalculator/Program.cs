namespace CaloriesCalculator
{
    class Program
    {
        public static void Main()
        {
            Apple apple = new Apple("Red appale", 100, 100);
            Apple apple2 = new Apple("Green appale", 90, 110);

            //Дві однакові дії використовуючи operator
            var sumApple = Apple.Add(apple, apple2);
            var sumApple2 = apple + apple2;
            //використовуючи перегружений оператор:
            var sumApple3 = apple + 100;


            Console.WriteLine(apple);
            Console.WriteLine(apple2);
            Console.WriteLine(sumApple);
            Console.WriteLine(sumApple2);
            Console.WriteLine(sumApple3);
            //використовуємо оператори порівняння:
            Console.WriteLine(apple == apple2);
            Console.WriteLine(sumApple == sumApple2);
            Console.ReadLine();
        }
    }
}