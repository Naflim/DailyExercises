using DailyExercises;

class Program
{
    public static void Main()
    {
        foreach (var item in ReadBinaryWatch.Run(2))
        {
            Console.WriteLine(item);
        }
    }
}
