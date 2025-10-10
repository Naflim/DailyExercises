using DailyExercises;
using DailyExercises.Utils;

class Program
{
    public static void Main()
    {
        int[] energy = [-2, -3, -1];
        var result = MaximumEnergy.Run(energy, 2);

        Console.WriteLine(result);
    }
}
