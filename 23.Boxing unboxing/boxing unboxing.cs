namespace Уроки
{
    /*
     *  Упаковка і розпаковка значимих типів (boxin unboxing)
     *      це спливає на швидкодію комп"ютера, при чому в гіршу сторону
     *
     *
     *
     *
     */

    internal class leson
    {
        private static void Main(string[] args)
        {
            int a = 1;
            object b = a; //так ми упаковуємо перемінну типа інт в тип об"єкт
            int c = (int)b; //розпаковка

            decimal d = (decimal)b; //при спробі розпаковки з інт в децимал отримуємо InvalidCastException
        }
    }
}