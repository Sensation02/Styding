/*
    Колекції це масиви (array), списки(list), перечислення(enum)
    
    це ніби коробка з чимось в якій, скажімо, є дві однакові перемінні і для кращого їх використання є масиви
    масив це як потяг, де кожна перемінна це вагон і вони йдуть один за одним, і в кожний вагон ми можемо щось
    поміщати, або взагалом 
*/
namespace Масиви_даних
{
    internal class leson
    {
        static void Main(string[] args)
        {
            //Одномірний масив
            //Тип_елементів_масива[] імя_масиву
            //тобто це є якась колекція однотипних даних
            int[] nums = new int[5]; //містить 5 елементів; new означає що виділяється память на масив
            nums[0] = 250; //завжди починається з 0 і відповідно 1 елементу присвоєно 250
            nums[1] = 50;
            nums[2] = 20;

            int[] myArray = new[] { 1, 2, 3, 4, 5 }; //можна відображати так
            int[] myArray1 = { 1, 2, 3, 4 }; //або так
            //myArray.Lenght - довжина масиву

            int[] myArray2 = Enumerable.Repeat(5, 10).ToArray();
            //повторює "5" 10 раз
            int[] myArray3 = Enumerable.Range(5, 10).ToArray();
            //від 5 до 10

            //використання циклів з масивами: for або for each (про нього пізніше)
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
                //тобто будуть перебиратися всі елементи масиву
                //в "0" буде 1, в 1 буде 2 і так далі з роботою циклу коли "і" буде збільшуватися (і++) на 1
            }

            //ввід даних в масив

            Console.Write("введіть кількість елементів масиву:\t");
            int elementsCount = int.Parse(Console.ReadLine());
            int[] myArrayNew = new int[elementsCount]; //вводимо кількість даних в масиві
            for (int i = 0; i < myArrayNew.Length; i++)
            {
                Console.Write($"введи елемент масиву під індексом {i}:\t");
                myArrayNew[i] = int.Parse(Console.ReadLine()); //ввід даних в конекретний масив
            }                                                  //без цього будуть одні "0"
            Console.WriteLine("вивід масиву: ");
            for (int i = 0; i < myArrayNew.Length; i++)
            {
                Console.WriteLine(myArrayNew[i]);
            }

            //ввід даних в масив у оборотньому порядку

            Console.Write("введіть кількість елементів масиву:\t");
            int elementsCount1 = int.Parse(Console.ReadLine());
            int[] myArrayNew1 = new int[elementsCount1];
            for (int i = elementsCount1 - 1; i >= 0; i--)
            { //обов"язково пишемо int i = elementsCount1 - 1, тому що нам треба щоб рахувало до "0", а не до 1!!
                Console.Write($"введи елемент масиву під індексом {i}:\t");
                myArrayNew1[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("вивід масиву: ");
            for (int i = elementsCount1 - 1; i >= 0; i--)
            {
                Console.WriteLine(myArrayNew1[i]);
            }

            //сума парний і непарних чисел
            int[] newArray = Enumerable.Range(1, 10).ToArray();
            int oddNumbers = 0;
            int evenNumbers = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i] % 2 == 0)
                {
                    oddNumbers += newArray[i];
                }
                else
                {
                    evenNumbers += newArray[i];
                }
            }
            Console.WriteLine("сума непарних чисел: " + oddNumbers); //30
            Console.WriteLine("сума парних чисел: " + evenNumbers); //25

            //знаходження найменшого і найбільшого елементу масива
            int[] lowArray = { 321, 23, 125, 55, 87, 132, 8876, 12, 65 };
            int minValue = lowArray[0]; //перший елемент масиву
            int maxValue = lowArray[8]; //останній елемент масиву
            for (int i = 1; i < lowArray.Length; i++)
            {
                if (lowArray[i] < minValue) //найменше число - 12
                {
                    minValue = lowArray[i];
                }
                else if (lowArray[i] > maxValue) //найбільше число - 8876
                {
                    maxValue = lowArray[i];
                }
            }
            Console.WriteLine(minValue);
            Console.WriteLine(maxValue);

            //як працювати з масивами насправді
            //мінімальне і максимальне число але значно простіше
            int[] myArrayNew2 = { 321, 23, 125, 55, 87, 132, 8876, 125, 65 };
            int res = myArrayNew2.Max(); //максимальне число з масиву
            int res2 = myArrayNew2.Min(); //мінімальне

            Console.WriteLine(myArrayNew2.Sum());
            //..сума всіх елементів

            Console.WriteLine(myArrayNew2.Where(i => i % 2 == 0).Sum());
            //..сума парних; метод where дозволяє помістити в себе якусь умову для пошуку в масиві

            Console.WriteLine(myArrayNew2.Where(i => i % 2 != 0).Sum());
            //..сума непраних

            Console.WriteLine(myArrayNew2.Where(i => i % 2 != 0).Min());
            //..найменше непарне число; відповідно .Мах - максимальне; так само з парними

            //переміщення 1 елементу з масиву в інший масив
            int[] resultNew = myArrayNew2.Distinct().ToArray();
            //..позбудемося лишніх елементів масиву і перенесемо їх в новий масив
            //..тобто будуть лише унікальні, ті що повторюються - не перенесуться

            int[] resultNew1 = myArrayNew2.OrderBy(i => i).ToArray();
            //..сортування елементів масиву від меншого до більшого
            //   .OrderByDescending - від більшого до меншого

            Array.Sort(myArrayNew2);
            //знову сортування від меншого до більшого, але значно коротше

            int resultNew2 = Array.Find(myArrayNew2, i => i < 70);
            // АБО
            int resultNew3 = myArrayNew2.Where(i => i < 70).First();
            //..пошук першого числа меншого 70-ти і присвоєння його в перемінну
            //   .FindLast - пошук з останнього числа
            //   .FindAll - всі числа які менші за 70
            //   .FindIndex - за яким індексом знаходиться число 70 (але його там немає, буде "-1")
            //..якби було наприклад 23 - був би індекс "2"
            //   .FindIndexLast - пошук з кінця
            //   .Reverse - елементи будуть йти у зворотньому порядку, але не в порядку зростання чи спадання

            //сортування цифр в масиві на парні та непарні
            int[] myArrayNumbers = Enumerable.Range(0, 10).ToArray();
            foreach (int evenNumbersArray in myArrayNumbers.Where(i => i % 2 == 0))
                Console.WriteLine($"{evenNumbersArray} ");
            Console.WriteLine("\n");
            foreach (int oddNumbersArray in myArrayNumbers.Where(i => i % 2 != 0))
                Console.WriteLine($"{oddNumbersArray} ");
            Console.WriteLine("\n");
            //далі даний цикл буде ще розглядатися окремо (кожний foreach це for але простіше))


            //двовимірні та багатовимірні масиви (прямокутні, зубчасті тощо)
            //тобто одномірний масив це ніби лінія
            //двовимірний це вже як фігура (прямокутник до прикладу)
            //тип_даних [,] ім"я_масиву - кома в дужках означає що масив двовимірний

            int[,] array1 = new int[3, 5]; //можна писати [,] але тоді не зорзуміло скільки там всього
            int[,] array =
            {
                {1,5,6,8,2 },
                {4,321,78,1,76 },
                {87,32,751,9,21 }
            }; //той же масив тільки розгорнутий і заповнений числами

            Console.WriteLine(array.Rank);
            //Rank - містить інформацію про кількість вимірів масиву = 2
            //GetLength - інформація про кількість елементів в ондому з рівнів
            //.. причому починати треба з 0
            Console.WriteLine(array.GetLength(0));
            //на виході - 3, тобто кількість елементів в першому вимірі масиву (довжина/висота)
            Console.WriteLine(array.GetLength(1));
            //на виходы - 5, тобто кількість елементів у другому вимірі масиву (ширина)


            //вивід даних масиву
            int haigth = array.GetLength(0); //дані про довжину масиву (висота)
            int width = array.GetLength(1); //дані про ширину масиву

            for (int y = 0; y < haigth; y++)
            {
                Console.WriteLine($"количество елементов в {y + 1} масиве: ");
                for (int x = 0; x < width; x++)
                {

                    Console.Write(array[y, x] + " "); //перебор елементів масиву з другого виміра
                }
                Console.WriteLine(); //щоб переходити на наступний рядок
            }

            //той самий варіант тільки без виноса у перемінну: (простіше)
            for (int y = 0; y < array.GetLength(0); y++)
            {
                Console.WriteLine($"количество елементов в {y + 1} масиве: ");
                for (int x = 0; x < array.GetLength(1); x++)
                {

                    Console.Write(array[y, x] + " ");
                }
                Console.WriteLine();
            }

            //ввід даних у масив (спочатку випадковими числами потім з клави)

            int[,] array2 = new int[3, 4];
            Random random = new Random();

            //далі окремі цикли для генерації чисел
            //чому окремі? тому що так краще для програми (культура написання)
            for (int y = 0; y < array2.GetLength(0); y++)
            {
                for (int x = 0; x < array2.GetLength(1); x++)
                {
                    array2[y, x] = random.Next(10); //заповнення рандомними числами до 10
                }
            }
            for (int y = 0; y < array2.GetLength(0); y++)
            {
                Console.WriteLine($"Цифры в {y + 1} масиве: ");
                for (int x = 0; x < array2.GetLength(1); x++)
                {
                    Console.Write(array2[y, x] + " ");
                }
                Console.WriteLine();
            }


            //ввід з клавіатури
            int[,] array3 = new int[3, 4];
            for (int y = 0; y < array3.GetLength(0); y++)
            {
                for (int x = 0; x < array3.GetLength(1); x++)
                {
                    Console.Write("Массив по длинне: " + y + " Масив по ширине: " + x + "\n");
                    array3[y, x] = int.Parse(Console.ReadLine()); //заповнення рандомними числами до 10
                }
            }
            Console.WriteLine("\nВывод масивов: ");
            for (int y = 0; y < array3.GetLength(0); y++)
            {
                Console.WriteLine($"Цифры в {y} масиве: ");
                for (int x = 0; x < array3.GetLength(1); x++)
                {
                    Console.Write(array3[y, x] + " ");
                }
                Console.WriteLine();
            }

            //зубчастий масив, або масив одновимірних масивів

            int[][] tArray = new int[5][]; //[][] - масив масивів або трьовимірний в якому 3 масиви
            //перший масив у масиві:
            tArray[0] = new int[3];
            //другий
            tArray[1] = new int[2];
            tArray[2] = new int[5];
            tArray[3] = new int[10];
            tArray[4] = new int[4];

            Random rand = new Random();

            //ввід:
            for (int i = 0; i < tArray.Length; i++)
            {
                for (int j = 0; j < tArray[i].Length; j++)
                {
                    tArray[i][j] = rand.Next(100);
                }
            }
            //вивід:
            for (int i = 0; i < tArray.Length; i++)
            {
                Console.WriteLine($"Цифры в масиве {i}:");
                for (int j = 0; j < tArray[i].Length; j++)
                {
                    Console.Write(tArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            //трьохвимірний масив (об'ємний або як книжка в якій є сторінки і рядки)

            int[,,] ttArray = new int[4, 3, 4];

            Random r = new Random();

            for (int y = 0; y < ttArray.GetLength(0); y++) //цикл для "книжки"
            {
                for (int x = 0; x < ttArray.GetLength(1); x++) //сторінка
                {
                    for (int z = 0; z < ttArray.GetLength(2); z++) //рядок
                    {
                        ttArray[y, x, z] = r.Next(100); //заповнюється рандомними цифрами
                    }
                }
            }
            for (int y = 0; y < ttArray.GetLength(0); y++)
            {
                Console.WriteLine("страница №: " + (y + 1));
                for (int x = 0; x < ttArray.GetLength(1); x++)
                {
                    for (int z = 0; z < ttArray.GetLength(2); z++)
                    {
                        Console.Write(ttArray[y, x, z] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            //зубчастий трьохвимірний масив

            int[][][] tZarray = new int[r.Next(3, 6)][][];
            //..масив в якому є масив з масивами
            for (int i = 0; i < tZarray.Length; i++)
            {
                tZarray[i] = new int[r.Next(2, 6)][];

                for (int j = 0; j < tZarray[i].Length; j++)
                {
                    tZarray[i][j] = new int[r.Next(2, 6)];

                    for (int k = 0; k < tZarray[i][j].Length; k++)
                    {
                        tZarray[i][j][k] = r.Next(100);
                    }
                }
            }
            for (int i = 0; i < tZarray.Length; i++)
            {
                Console.WriteLine("Page #: " + (i + 1));
                for (int j = 0; j < tZarray[i].Length; j++)
                {

                    for (int k = 0; k < tZarray[i][j].Length; k++)
                    {
                        Console.Write(tZarray[i][j][k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }




            Console.ReadLine();
        }
    }
}
