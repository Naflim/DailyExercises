using DailyExercises;
using DailyExercises.Utils;

class Program
{
    public static void Main()
    {

        var result = KLengthApart.Run([1, 0, 0, 1, 0, 1],2);

        Console.WriteLine(result);
    }
}
