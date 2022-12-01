namespace DailyExercises;

static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(NearestValidPoint.Run(3,4,new int[][] 
        {
            new int[]{2,3},
            //new int[]{3,1},
            //new int[]{2,4},
            //new int[]{2,3},
            //new int[]{4,4},
        }));
        Console.Read();
    }
}