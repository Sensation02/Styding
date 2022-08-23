using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace множинний_вибір
{
    internal class leson
    {
        static void Main(string[] args)
        {
            //множинний вибір або "switch case"
            Console.WriteLine("<start of conversation>\nSay hello");
            string word = Console.ReadLine();
            switch (word) //в () вкладаємо те на основі чого буде виконуватися 
            {
                case "hello": //працює при введенні "привіт"
                    Console.WriteLine("Hello! Whats your name?"); //далі виконується певна дія
                    break; //закінчувати кейс тільки так
                case "what?": //працює при введені "що?"
                    Console.WriteLine("Nevermind");
                    break;
                default: //по дефолту якщо буде введено ні перше ні друге
                    Console.WriteLine("WTF?");
                    break;
            }
            string name = Console.ReadLine();
            switch (name)
            {
                case "Vasyl":
                    Console.WriteLine("Beautiful name");
                    break;
                case "Natali":
                    Console.WriteLine("Very nice");
                    break;
                default:
                    Console.WriteLine("WTF?");
                    break;
            }

            ConsoleKey consoleKey = Console.ReadKey().Key; //фіксує нажату клавішу
            /*
            потім при переносі consoleKey у switch згенеруються кейси на кожну клавішу
            потім ці кейси можна використовувати на свій розсуд, тобто як макроси
            даний метод процює тільки зі switch case 
            */
        }
    }
}
