/*
    LINQ - спеціальна мова сішарп яка дозволяє ефективно працювати з колекціями 
     або мова запросів
    
    за її допомоги можна перетворювати один клас на інший
    можна накладати умови на вибірку з колекцій
    можна упорядковувати колекцію, спочатку по одному полю а потім по іншому і тд 
    можна робити групи колекцій з однієї або з декількох в одну
    сортування в колекціях, вибір останнього чи першого чи якогось іншого елемента колекцій
    
    
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Learning
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            #region Where
            //починаємо з простого списку

            //"збираємо повну колекцію"
            var collectionList = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                collectionList.Add(i);
            }

            //форми запису LINQ:
            // 1 - стандартна (схожа на SQL)
            // 2 - у вигляді методів розширення (поверх класу без створення наступника)

            // 1 стандартна:
            //збираємо числа менше 5
            var resultList = from item in collectionList //поміщаємо по черзі всі елементи колекції
                             where item < 5
                             select item;

            // 2 тепер пишемо те саме тільки з використанням розширення
            var resultList2 = collectionList.Where(item => item < 5); //item такий що(або лямбда вираз) item < 5
            //collectionList. і після точки ми можемо бачити лінкю
            //це методи з <>,
            //щоб створити таке для нашого класу треба щоб цей клас реалізовував інтерфейс IEnumerable
            //після . можуть бути ще команди

            //перебираємо числа на консоль
            foreach (var item in resultList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in resultList2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //трохи складніше, з окремим класом Product (з іменем та калоріями)
            var productCollection = new List<Product>();
            
            for (int i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "product" + i,
                    Energy = rnd.Next(10, 500)
                };
                productCollection.Add(product);
            }

            //сортуємо наші продукти по кількості калорій між 100 та 400
            var prodResult = from item in productCollection
                             where item.Energy > 100 && item.Energy < 400
                             select item;
            //або між 200 й 300
            var prodResult2 = productCollection.Where(item => item.Energy > 200 && item.Energy < 300);

            //перебираємо
            foreach (var item in prodResult)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in prodResult2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region Select
            //Перетворення одного типу в другий - Select

            var selectCollection = productCollection.Select(item => item.Energy);
            //взяли всю колекцію, взяли звідти один елемент, витягнули енергетичну цінність
            //і вставили в результующу колекцію
            //тобто на вході колекція продуктів, на виході колекція цілих чисел

            foreach (var item in selectCollection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region OrderBy
            //упорядкування колекції - OrderBy
            //...по калорійності, в порядку зростання:
            foreach (var item in productCollection.OrderBy(item => item.Energy))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //у порядку спадання:
            foreach (var item in productCollection.OrderByDescending(item => item.Energy))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region ThanBy
            //спорядкування по двом значенням: - ThanBy
            foreach (var item in productCollection.OrderBy(item => item.Energy).ThenBy(item => item.Name))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //по двом значенням, один у зсворотньому:
            foreach (var item in productCollection.OrderBy(item => item.Energy)
                                                  .ThenByDescending(item => item.Name))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region GroupBy
            //упорядкування
            foreach (var group in productCollection.GroupBy(item => item.Energy))
            {
                Console.WriteLine($"Key: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"\t{item}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //тут повертається згрупований елемент (не IEnumerable)
            //де перший елемент являється ключем, другий елемент є колекцією який містить в собі елементи
            //які задовільняють ключ
            //це яв визначення у словинку: де ключ - це визначення,
            //а другий елемент з колекцією - це пояснення 
            //насправді, на виході буде цифра нашої калорійності як ключ, і під ключем будуть продукти які 
            //які відповідають нашій калорійності
            #endregion

            #region Reverse
            //розвертає нашу колекцію у зворотньому порядку
            productCollection.Reverse();
            foreach (var item in productCollection)
            {
                Console.WriteLine(productCollection);
            }
            #endregion

            #region All & Any
            //повертають не елемент колекції а булеве значення

            //All - Перше значення буде повертати тру(правду) якщо умові заданій в ній
            //відповідають всі елементи колекції
            //тобто якщо повертається правда якщо всі елементи колекції, наприклад,
            //будуть мати таку ж енергетичну цінність як і перший елемент колекції, інакше неправда
            Console.WriteLine(productCollection.All(item => item.Energy == 10));

            //Any - це якщо хоча б один елемент колекції буде відповідати першому елементу
            //(по калорійності наприклад)
            //якщо ніодин не відповідає - неправда
            Console.WriteLine(productCollection.Any(item => item.Energy == 10));
            #endregion

            #region Contains
            //перевіряє входження елемента в колекцію
            //наприклад, чи входить в нашу колекцію продукт з калорійністю 20?
            Console.WriteLine(productCollection.Contains(productCollection[20]));
            //true or false
            #endregion

            #region Distinct
            //це по суті Equal - перевіряє по хеш коду елемента
            //тобто робить нашу колекцію наповненою унікальними елементам,
            //дублюючі елементи будуть видалені з колекції
            List<int> intCollection = new List<int>()
            {
                1,2,3,2,3,4,4,5,6,3,4,5
            };
            var MS = intCollection.Distinct();
            #endregion

            #region Union
            var array = new int[] { 1, 2, 3, 4, 1, 2, 4, 5 };
            var array2 = new int[] { 1, 4, 3, 4, 1, 3, 7, 6 };

            var union = array.Union(array2);
            foreach (var item in union)
            {
                Console.WriteLine(item);
            }
            //output: 1,2,3,4,5,6,7 - дубльоване видаляється
            #endregion

            #region Intersect
            var intersect = array.Intersect(array2);
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }
            //output: 1,3,4 - те що є в обох колекціях
            #endregion

            #region Except
            var except = array.Except(array2);
            foreach (var item in except)
            {
                Console.WriteLine(item);
            }
            // output: 2,5 - окремо те що є в пешій колекції чого немає в іншій колекції
            // тобто від першої колекції вирахували те що є в іншій колекції
            // 6,7 - навпаки якщо поміняти array2.Except(array); місцями
            #endregion

            #region Sum, Min & Max
            var sum = array.Sum(); //сума того що є в масиві
            var min = productCollection.Min(p => p.Energy); // продукт з мінімальним значення калорійності
            var max = productCollection.Max(p => p.Energy); // з максимальним значенням
            #endregion

            #region Aggregate
            var aggreagate = array.Aggregate((x, y) => x * y); //вказуємо над якими буде дія і потім сама дія
                                                               // тобто беруть всі елементи колекції і по черзі перемножуються
            #endregion

            #region Skip & Take
            //хочемо обробити не всю колекцію а якусь її частину?
            //суму але не всіх елементів?
            var sum2 = array.Skip(1).Take(2).Sum();
            // Skip(1) - пропускаємо один елемент (цифра 1)
            // Take(2) - скільки елементів з колекції треба взяти (цифри 2, 3)

            // без Skip, Take візьме перші два елементи
            // без Take, Skip пропустить перший елемент і всі решту будуть сумуватися
            #endregion

            #region Операції вибору - First, Last & Single
            // це робиться 4-ма способами
            var first = array.First();
            // First - беремо перший елемент з колекції (1), але якщо масив пустий - зловимо помилку
            // FirstOrDefault - те саме але використовується коли колекція пуста (1 або Null)
            var first1 = productCollection.First(a => a.Energy == 10);
            // виберемо той перший продукт який буде дорівнювати 10
            // якщо перший продукт не має калорійності 10 - помилка

            var last = array.Last();
            // Last - останній елемент (5) або помилка
            // LastOrDefault - останній елемент але без помилки (5 або Null)

            // використовується також у зв"язці з Where також використовується тому що там повертається колекція
             
            var single = productCollection.Single(a => a.Energy == 10);
            // вибираємо один той продукт(елемент) калорійність якого буде дорівнювати 10
            // якщо в колекції вже два і більше елементів які мають калорійність 10 то отримуємо помилку

            // Single використовуємо коли ми очікуваємо один єдиний екзмпляр з таким ідентифікатором (10)
            #endregion

            #region ElementAt & ElementAtOrDefault
            // отримуємо елемент по індексу (4): 3 елемент (по з 0 відлік)
            // якщо такого елемента немає - помилка
            var element = productCollection.ElementAt(4);

            // отримуємо 19 елемент (індекс 20), якщо його немає - Null
            var elementDef = productCollection.ElementAtOrDefault(20);
            #endregion

            Console.ReadLine();
                    
        }
    }
}
