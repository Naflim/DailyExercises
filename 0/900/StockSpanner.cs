namespace DailyExercises
{
    //public class StockSpanner
    //{

    //    readonly List<int> _stock;

    //    public StockSpanner()
    //    {
    //        _stock = new List<int>();
    //    }

    //    public int Next(int price)
    //    {
    //        int days = 0;
    //        _stock.Add(price);
    //        for (int i = _stock.Count - 1; i>=0; i--)
    //        {
    //            if (_stock[i]>price) break;
    //            days++;
    //        }
    //        return days;
    //    }
    //}

    /// <summary>
    /// 901 股票价格跨度
    /// </summary>
    //public class StockSpanner
    //{
    //    readonly List<Stock> _stocks;
    //    int _now = -1;

    //    public StockSpanner()
    //    {
    //        this._stocks = new();
    //    }

    //    public int Next(int price)
    //    {
    //        _now++;

    //        int days = 0;
    //        for (int i = _stocks.Count - 1; i>=0; i--)
    //        {
    //            var nowStock = _stocks[i];
    //            if (nowStock.value>price)
    //            {
    //                days = _now - nowStock.index;
    //                break;
    //            }
    //            else _stocks.Remove(nowStock);
    //        }
    //        _stocks.Add(new Stock(price, _now));
    //        if (days == 0) days = _now + 1;
    //        return days;
    //    }
    //}

    //public struct Stock
    //{
    //    public int value;
    //    public int index;
    //    public Stock(int value, int index)
    //    {
    //        this.value=value;
    //        this.index=index;
    //    }
    //}

    /// <summary>
    /// 901 股票价格跨度
    /// </summary>
    public class StockSpanner
    {
        readonly Stack<(int val, int count)> stack;

        public StockSpanner()
        {
            stack = new();
        }

        public int Next(int price)
        {
            int days = 1;
            while (stack.Count > 0)
            {
                var val = stack.Peek();
                if (val.val > price)
                    break;

                days += val.count;
                stack.Pop();
            }

            stack.Push((price, days));
            return days;
        }
    }
}
