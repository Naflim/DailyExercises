/*************************************************************************************
 *
 * 文 件 名:   StockSpanner
 * 描    述:   股票价格跨度
 * 
 * 版    本：  V1.0
 * 创 建 者：  柯懿
 * 创建时间：  2022/10/21 10:37:08
 * ======================================
 * 历史更新记录
 * 版本：V          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    public class StockSpanner
    {

        readonly List<int> _stock;

        public StockSpanner()
        {
            _stock = new List<int>();
        }

        public int Next(int price)
        {
            int days = 0;
            _stock.Add(price);
            for (int i = _stock.Count - 1; i>=0; i--)
            {
                if (_stock[i]>price) break;
                days++;
            }
            return days;
        }
    }


    //public class StockSpanner
    //{
    //    readonly List<Stock> _stocks;
    //    int _now = -1;

    //    public StockSpanner()
    //    {
    //        _stocks = new();
    //    }

    //    public int Next(int price)
    //    {
    //        _now++;

    //        int days = 0;
    //        if (_stocks.Find(s => s.Value == price) is Stock stock)
    //        {
    //            _stocks.Remove(stock);
    //            _stocks.Add(new Stock(price, _now));
    //        }
    //        else _stocks.Add(new Stock(price, _now));

    //        for (int i = _stocks.Count - 1; i>=0; i--)
    //        {
    //            var nowStock = _stocks[i];
    //            if (nowStock.Value>price)
    //            {
    //                days = _now - nowStock.Index;
    //                break;
    //            }
    //        }

    //        if (days == 0) days = _now + 1;
    //        return days;
    //    }
    //}

    //public class Stock
    //{
    //    public int Value { get; set; }
    //    public int Index { get; set; }

    //    public Stock(int value, int index)
    //    {
    //        Value=value;
    //        Index=index;
    //    }
    //}
}
