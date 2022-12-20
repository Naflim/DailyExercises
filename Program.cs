using DailyExercises;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(FewestBallsInBag.Run(new int[] { 7, 17 }, 2));
        Console.ReadLine();
    }
}

