using DailyExercises;
using DailyExercises.Utils;

class Program
{
    public static void Main()
    {
        string data = File.ReadAllText("E:/Script/logging/data.txt");
        var result = NumSub.Run(data);

        Console.WriteLine(result);
    }
}
