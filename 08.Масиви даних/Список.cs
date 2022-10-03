/*

    List - список чого завгодно (строк, зображення, дати, екзмепляри класів, структури, символи тощо)
    можливості:
    - додавання новго елементу
    - видалення елементу
    - вставка в задану позицію
    - сортування елементів у списку
    - пошук за індексом елемента
    
    Тобто структура даних №1

    відмінність List від Array
    масив має фіксовану розмірність, список такого немає і це зручно, тобто це динамічна структура даних
    список працює швидше, якщо нам треба додати новий елемент

*/
namespace Масиви_даних
{
    internal class Список
    {
        static void Main()
        {
            //List<Т> назва = new List<Т>(); де Т це тип_даних (int string тощо)
            //Т - це узагальнення(обопщения/Generics), він не пишеться в основній програмі а в методі у класі
            //поза програми, тут ми обов"язково маємо вказувати Тип_даних
            List<int> list = new List<int>();
            //це пустий список
            List<int> list2 = new List<int>();
            //список строк (повна конструкція для прикладу)
            List<string> socialNetworks = new List<string>();
            //коротше писати List<string> socialNetworks = () {"YouTube", "Facebook", "Instagram"};

            socialNetworks.Add("YouTube"); //додаємо(Add) елемент у список (Список також починається з 0)
            socialNetworks.Add("Facebook");
            socialNetworks.Add("Instagram");

            socialNetworks.Insert(1, "TikTok"); //вставляєм(Insert) по індексу 1
            //при чому всі елементи у списку зсовуються/переїжджають на наступний індекс
            //по принципу BIG-O insert не дуже добре О(n), тому що чим більше елементів у списку тим більше проблем
            //особливо коли ми звертаємося до якогось конкретного елементу за конкретним індексом
            //в такому випадку краще використовувати LinkedList<> але про це іншого разу...

            socialNetworks.Remove("Facebook");
            //Remove також не добре, його ефективність також О(n)
            //тому що спершу шукається спочатку елемент за індексом, видалення і зсув всіх елементів

            socialNetworks.RemoveAt(2);
            //погана ефективність - О(n) - бо зновуж: пошук, видалення і зсув
            //RemoveAt(3); - максимальна ефективність - О(1) - видалення останнього елементу

            socialNetworks.Sort(); //сортування списку по алфавіту

            foreach (string socialNetwork in socialNetworks)
            {
                Console.WriteLine(socialNetwork);
            }
            Console.WriteLine(socialNetworks[0]); //вивід елементу під індексом 0
            Console.ReadLine();

            string[] socialNetworksArray = { "YouTube", "Facebook", "Instagram" };
            List<string> socialNetworksList = new();
            socialNetworksList.AddRange(socialNetworksArray);
            //додавання у список з масиву (AddRange)

        }
    }
}
