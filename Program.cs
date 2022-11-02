namespace DailyExercises;

class Program
{
    public static void Main()
    {
        var demo = BestNetworkSignal.BestCoordinate(new int[][]
        {
            new int[]{ 30,34,31 },
            new int[]{10,44,24},
            new int[]{14,28,23},
             new int[]{ 50, 38, 1 },
             new int[]{ 40,13,6 },
              new int[]{ 16,27,9 },
               new int[]{ 2,22,23 },
                new int[]{ 1,6,41 },
                 new int[]{ 34,22,40 },
                  new int[]{40,10,11 },
        }, 20);
        for (int i = 0; i <demo.Length; i++)
        {
            Console.WriteLine(demo[i]);
        }
        Console.Read();
    }
}
