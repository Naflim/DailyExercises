using DailyExercises;
using DailyExercises.Utils;

class Program
{
    public static void Main()
    {
        var result = CreateGrid.Run(2, 3);
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }
    }
}
