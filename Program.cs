using DailyExercises;
using DailyExercises.Utils;

class Program
{
    public static void Main()
    {
        int[] skill = [1, 2, 3, 4];
        int[] mana = [1, 2];
        var result = MinTime.Run(skill, mana);

        Console.WriteLine(result);
    }
}
