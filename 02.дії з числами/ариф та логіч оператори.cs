using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace дії_з_числами
{
    internal class leson
    {
        static void Main(string[] args)
        {
            //Арифметичні операції з цислами (оператори)
            int num3 = 1;
            int res = num3 + 1;
            /* 
            оператор "+" (інкремент), також "-" (декремент), "*", "/", "=",
            "%" - ділення по модулю, залишок від числа (парність чи непарність, кратність)
            1 + 2 де "1" і "2" операнди і це бінарний операнд
            також є унарний (num3++) і тернатний (про який пізніше)
            і порядок дії (логіка) в коді такий:
            спочатку йде "num3 + 1", далі сума присвоюється в тип даних "int res"
            */

            int res1 = num3++; //операція інкремента, аналогом є num3 + 1 
            int res2 = num3--; //декремент, і такі записи називаються постфіксними
            //++num3 - префіксний запис, такий запису буде означати "+1" і він має пріорітет
            //також існує спрощений варіант - int res1 += або -= тощо

            //такі операції мають приорітет
            int res3 = ++num3 - 1;
            //тобто спочатку до "num3" додастся 1 і вже потім відніметься оператором ще 1
            //результат буде: 1 (2-1)
            int res4 = num3++ - 1;
            //результат: 0 , тому що спочатку num3 - 1 , а потім +1 (num3++)
            //так само відбувається і з "--"

            //ще варіанти операцій
            int res5 = ++num3 * num3;
            //результат: 4 , тому що ми до 1 + 1 і num3 стає "2"
            int res6 = num3++ * num3;
            //результат: 2

            //оператори порівняння та відношення (умови):
            /*
            
            ==    рівно (одне = означає що ми щось чомусь присвоюємо!)
            !=    не рівно
            >     більше
            <     менше
            <=    більше або рівно
            >=    менше або рівно

            */

            int num = 1;
            int num1 = 1;
            bool res7 = num == num1;
            Console.WriteLine(num == num1); //якщо num=num1 - true, якщо ні - false

            //Логічні оператори
            /*
            
            &&   Коротке "і", перевіряє щоб всі параметри були, наприклад, "правда" або через інше вираження
            ||   Коротке "або", перевіряє щоб "або" перший "або" другий вираз був "правдою"
            &    і - те саме що "коротке" тільки виконується довше
            |    або
            !    Не (унарний(!= не дорівнює))

            */

            //приклад через логічний вибір (через коротке "і")
            Console.WriteLine("Say something");
            string word = Console.ReadLine();
            Console.WriteLine("Introduce yourself");
            string name = Console.ReadLine();
            if (word == "Hello" && name == "Vasyl") //тобто якщо введене слово буде "Hello" і "Vasyl"..
            {
                Console.WriteLine("Hello dear Vasyl"); //.. буде цей результат
            }
            else //якщо якесь інакше слово..
            {
                Console.WriteLine("Who are you?"); //..буде цей результат
            }

            //інакший приклад з коротким "або"
            bool radiationLevelHigh = true;
            bool biohazardLevelHigh = true;

            if (radiationLevelHigh || biohazardLevelHigh) //тобто якщо перше або друге слово "правда"..
            {
                Console.WriteLine("Its dangerous outside!!"); //.. буде цей результат
            }
            else //якщо щось інакше..
            {
                Console.WriteLine("Its safe"); //..буде цей результат
            }

            //приклад з "не" унарним через логічний вибір
            Console.WriteLine("Enter you password:");
            string pass = Console.ReadLine();
            if (pass != "nata24")
            {
                Console.WriteLine("Wrong password!");
            }
            else
            {
                Console.WriteLine("Succes!\tYou may enter");
            }

            //більш складний приклад
            Console.WriteLine("Enter the level of radiation contamination:");
            int radiationLevel = int.Parse(Console.ReadLine());
            bool radLevelHigh = radiationLevel >= 400 || radiationLevel <= 600;
            bool radLevelMid = radiationLevel >= 200 || radiationLevel <= 399;
            bool radLevelLow = radiationLevel >= 0 || radiationLevel <= 199;
            bool nullRad = radiationLevel == 0;
            Console.Clear(); //очищує консоль від попередніх записів
            if (radLevelHigh || radLevelMid)
            {
                Console.WriteLine(radiationLevel + " Rad \nIts dangerous. \nStay in safe.");
            }
            else if (radLevelLow || nullRad)
            {
                Console.WriteLine(radiationLevel + " Rad \nContamination level is low. \nYou can leave safe place");
            }
            else
            {
                Console.WriteLine("Unmeasurabel level of radiation contamination");
            }
            Console.Write("Information:" +
            "\nFrom 400 to 600 and more Rad - its high level of pollution." +
            "\nFrom 200 to 400 Rad - its mid level." +
            "\nFrom 100 to 200 Rad - its low level." +
            "\n0 Rad - its no pollution.");

            //тернарний оператор (виконує операції над трьома операндами)
            //(перший операнд - умова) ? (другий операнд if_true) : (третій операнд if_else)
            //тобто трернаний оператор це "?:"
            int q = 0;
            int result1 = q + 1; //унарний оператор виконує дію над одним операндом
            int b = 1;
            int result2 = b + q; //бінарний оператор виконує дію над двома операндами

            //приклад з перевірки паролю

            bool accessAllowed;
            string storedPass = "Nata";
            string enteredPass = Console.ReadLine();

            if (storedPass == enteredPass)
            {
                accessAllowed = true;
            }
            else
            {
                accessAllowed = false;
            }
            Console.WriteLine(accessAllowed);


            //а тепер те саме з використанням тернарного оператора

            accessAllowed = storedPass == enteredPass ? true : false;
            Console.WriteLine(accessAllowed);

            //приклад з числами
            int inputData = int.Parse(Console.ReadLine());
            int outputData = inputData < 0 ? 0 : inputData;
            Console.WriteLine(outputData);
            Console.ReadLine();
        }

    }
}