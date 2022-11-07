namespace DailyExercises;

class Program
{
    public static void Main()
    {

        foreach(string str in FuzzyCoordinates.AmbiguousCoordinates("(123)"))
        {
            Console.WriteLine(str);
        }
        Console.ReadLine();
    }
}