namespace DailyExercises;

class Program
{
    public static void Main()
    {
        StockSpanner stockSpanner = new();
        Console.WriteLine(stockSpanner.Next(100));
        Console.WriteLine(stockSpanner.Next(80));
        Console.WriteLine(stockSpanner.Next(60));
        Console.WriteLine(stockSpanner.Next(70));
        Console.WriteLine(stockSpanner.Next(60));
        Console.WriteLine(stockSpanner.Next(75));
        Console.WriteLine(stockSpanner.Next(85));

        //Console.WriteLine(stockSpanner.Next(31));
        //Console.WriteLine(stockSpanner.Next(41));
        //Console.WriteLine(stockSpanner.Next(48));
        //Console.WriteLine(stockSpanner.Next(59));
        //Console.WriteLine(stockSpanner.Next(79));

        //Console.WriteLine(stockSpanner.Next(28));
        //Console.WriteLine(stockSpanner.Next(14));
        //Console.WriteLine(stockSpanner.Next(28));
        //Console.WriteLine(stockSpanner.Next(59));
        //Console.WriteLine(stockSpanner.Next(79));


        //Console.WriteLine(stockSpanner.Next(1));
        //Console.WriteLine(stockSpanner.Next(79));
        //Console.WriteLine(stockSpanner.Next(34));
        //Console.WriteLine(stockSpanner.Next(21));
        //Console.WriteLine(stockSpanner.Next(34));
        //Console.WriteLine(stockSpanner.Next(16));
        //Console.WriteLine(stockSpanner.Next(59));
        //Console.WriteLine(stockSpanner.Next(63));
        //Console.WriteLine(stockSpanner.Next(72));
        //Console.WriteLine(stockSpanner.Next(5));
        Console.Read();
    }
}