using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _16.__Перетворення_і_приведення_типів
{
    /* 
     * 
     *   Перетворення і приведення примітивних типів
     * 
     *   - процес приведення одного типу даних в інший
     *   неявне (implicit) приведення - float number2 = number1; (інт)         - або розширююче
     *   явне   (explicit) приведення - float number5 = (float)number3; (дабл) - або звужуюче
     *   
     *   звужуюче   приведення - з double у float (явне)   - від більшого до меншого
     *   розширююче приведення - з int у float    (неявне) - від меншого до більшого
     *   
    */
    internal class leson
    {
        static void TestMethod(float value)
        {
            Console.WriteLine(value);
        }
        static void Main(string[] args)
        {
            //приведення тип даних int у float:
            int number1 = 5; 
            float number2 = number1; //тобто "implicit - приведення" (неявне)
            double number3 = 12.3;
            TestMethod(number1);
            TestMethod((float)number3);
            float number4 = number3; //помилка - неможливо не явно перетворити тип даних float у double
            float number5 = (float)number3; //треба перетворити явно - "explicit"
            //чому так відбуваєтьс? - тому що тип даних float може помістити в собі більший діапазон значень 
            //double не можна перетворити у float тому, що він потенціально може містити в собі більше число
            //ніж це може зробити float, тобто через таке приведення можна втратити якусь частину даних і це помилка..
            int number6 = 257;
            byte number7 = (byte)number6;
            //і таке приведення може нам видати замість числа 257 1

            int a = 5;
            float b = 2.5F; //F обовязквого інакше буде double
            float result = a + b; //тут також відбувається неявне приведення int у float - 7.5
            int result1 = (int)(a + b); //перевід у Явне приведення, надалі варіант того ж приведення
            int result3 = a + (int)b;
            //або взагалі перетворити попередній результат у новий
            int result2 = (int)result;


            //далі Явне перетворення
            string word = "2040";
            int num1 = Convert.ToInt32(word);
            //Перетворення стрінга в інт через метод конверт,
            //але якщо у строці немає цифр то перетворення не відбудеться
            //це Явне перетворення

            int num2 = int.Parse("23");
            //варіант явного перетворення

            //НЕЯВНЕ перетворення:
            //неявне перетворення цисла до строки
            string word1 = "string" + num1;
            //довший варіант => num1.ToString(); але це вже ЯВНЕ перетворення числа в строку
            //тобто з числа зробиться строка і склеїться в одну строку => string2040

            bool bool1 = (bool)num2; //тут не працює
            bool bool2 = Convert.ToBoolean(num2);
            //в такому випадку позитивне число буде True
            //негативне - False

            string word2 = "True";
            bool1 = word2; //не можна
            bool1 = Convert.ToBoolean(word2); //True

            //далі складніший матеріал з перетворення, з перевіркою написаного
            if (int.TryParse("4215)", out int res)) //"4215)" - тут можне бути Console.ReadLine()
            {
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("ERROR");
            }
            //можна це зациклити щоб після перевірки можна було наново ввести
        }
    }
}