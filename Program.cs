using DailyExercises;
using DailyExercises.Helper.Tree;
using DailyExercises.LCP;
using DailyExercises.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        StockSpanner stock = new StockSpanner();
        Console.WriteLine(stock.Next(100));
        Console.WriteLine(stock.Next(80));
        Console.WriteLine(stock.Next(60));
        Console.WriteLine(stock.Next(70));
        Console.WriteLine(stock.Next(60));
        Console.WriteLine(stock.Next(75));
        Console.WriteLine(stock.Next(85));

        Console.ReadLine();
    }
}
