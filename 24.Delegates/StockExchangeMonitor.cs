namespace Уроки
{
    public class StockExchangeMonitor
    {
        public delegate void PriceChange(int price); //делегат який приймає параметр ціни на акцію

        //через нього ми будемо сповіщати всіх про зміну ціни акції
        public PriceChange? PriceChangeHandler { get; set; } // "?" щоб повертати Null якщо немає даних

        //створили властивість через яку можна буде зареєструвати ссилку на метод
        //через цю властивість зовнішній код зможе додавати методи для сповіщення про нову ціну

        public void Start() //метод який запускає StockExchangeMonitor
        {
            while (true) //цикл який буде повторюватися безкінечно
            {
                int bankOfAmericaPrice = (new Random().Next(100)); //отримуємо ціну на акцію рандомно
                PriceChangeHandler(bankOfAmericaPrice); //оповіщаємо всіх про нову ціну
                Thread.Sleep(2000); //затримка між повідомленням 2 секунди
            }
        }
    }
}