using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Уроки;

namespace _22.Struct_vs_class__структури_
{
    [MemoryDiagnoser]
    public class Benchmark_1
    {
        [Benchmark]
        public void StructTest()
        {
            StructPoint point = new StructPoint();
            point.X = 1;
            point.Y = 2;
            var result = point.X = point.Y;
        }
        [Benchmark]
        public void ClassTest()
        {
            ClassPoint point = new ClassPoint();
            point.X = 1;
            point.Y = 2;
            var result = point.X = point.Y;
        }
    }
    //в першому варіанті структура спрацювала так ніби її і не було, тобто дуже швидко
    //клас відповідно повільно
    public class Benchmark_2
    {
        [Benchmark]
        public void StructArrayTest()
        {
            StructPoint[] structPoints = new StructPoint[100];
            for (int i = 0; i < structPoints.Length; i++)
            {
                structPoints[i] = new StructPoint();
            }
        }
        [Benchmark]
        public void ClassArrayTest()
        {
            ClassPoint[] classPoints = new ClassPoint[100];
            for (int i = 0; i < classPoints.Length; i++)
            {
                classPoints[i] = new ClassPoint();
            }
        }
    }
    //месиви об"єктів структур створюються значно швидше ніж класів
    //але і тут на ці структури потребувалося виділенням пам"яті в кучі
    //треба пригадати що масив являється ссилочним типом, тобто являється тим же класом
    //сам масив це безперервна область в пам"яті, що дозволяє швидко отримати доступ до елементів масиву
    //знаючи адрес елементу масива
    //в масиві структури між елементами масиву існують реальні дані структури
    //в масиві класа існують не реальні дані, а ссилки на дані
    //таким чином, якщо в нас є масив класів, в оперативній пам"яті у нас знаходяться безперервно всі елементи які
    //складаються із ссилок на різні області в оперативній пам"яті де лежать реальні дані які належать об"єктам класа які
    //належать об"єктам класів які ми помістили в масив по певному індексу, і на цю всю роботу треба значно більше пам"яті
    //тобто в пам"яті створюємо дані потім знову поміщаємо ссилку в масив

    //чому так відбувається?
    //тому що ви створюємо ссилку на масив структур в пам"яті тільки один раз і кожний раз поміщаємо дані в масив
    //під тим індексом елемента який нам треба

    //для масиву класів ми створюємо спочатку сам масив в пам"яті де є ссилки на дані які також повинні бути в пам"яті
    //тобто щоб помістити дані в якийсь певний індекс масиву ми повинні пройти всі попередні індекси масиву,
    //щоб дібратися до потрібного

    public class Benchmark_3
    {
        struct MyStruct
        {
            public decimal MyProperty1 { get; set; }
            public decimal MyProperty2 { get; set; }
            public decimal MyProperty3 { get; set; }
            public decimal MyProperty4 { get; set; }
            public decimal MyProperty5 { get; set; }
            public decimal MyProperty6 { get; set; }
            public decimal MyProperty7 { get; set; }
            public decimal MyProperty8 { get; set; }
            public decimal MyProperty9 { get; set; }
            public decimal MyProperty10 { get; set; }

        }
        class MyClass
        {
            public decimal MyProperty1 { get; set; }
            public decimal MyProperty2 { get; set; }
            public decimal MyProperty3 { get; set; }
            public decimal MyProperty4 { get; set; }
            public decimal MyProperty5 { get; set; }
            public decimal MyProperty6 { get; set; }
            public decimal MyProperty7 { get; set; }
            public decimal MyProperty8 { get; set; }
            public decimal MyProperty9 { get; set; }
            public decimal MyProperty10 { get; set; }
        }
        private MyStruct _myStruct = new MyStruct();
        private MyClass _myClass = new MyClass();

        private void Foo(MyClass myClass)
        {
            var t = myClass.MyProperty1 + myClass.MyProperty2;
        }
        private void Bar(MyStruct myStruct)
        {
            var t = myStruct.MyProperty1 + myStruct.MyProperty2;
        }
        private void BarIn(in MyStruct myStruct)
        {
            var t = myStruct.MyProperty1 + myStruct.MyProperty2;
        }
        [Benchmark]
        public void StructTest()
        {
            Bar(_myStruct);
        }
        [Benchmark]
        public void StructTestIn()
        {
            BarIn(in _myStruct);
        }
        [Benchmark]
        public void ClassTest()
        {
            Foo(_myClass);
        }
    }
    //в третьому варіанті структура спрацювала вже повільно, а клас відповідно швидко
    //проблема полягає в тому скільки даних(полів) лежить в структурі а скільки в класі
    //в структурі всі дані копіюються кожний раз в коли відбувається робота
    //в класі кожний раз копіююється ссилка на ті дані які вже є
    //це є прикладом коли не треба використовувати структуру, тобто коли в ній є велика кількість даних
    //цього можна уникнути використовуючи ref in і тоді по швидкості клас і структура вирівнюються
    //але якщо треба використати елементи ООП типу наслідування і поліморфізму то вибір однозначно припадає на клас
    //тому що структура не може унаслідуватися але можемо реалізувати інтерфейс

    //далі в основновній програмі працюємо із інтерфейсом..
}
