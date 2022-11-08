namespace DailyExercises;

class Program
{
    public static void Main()
    {
        Console.WriteLine(ConsistentStringCount.CountConsistentStrings("abc", new string[] { "aaaaaaaaaaaa", "b", "c", "ab", "ac", "bc", "abc" }));

        Console.ReadLine();
    }
}