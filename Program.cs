using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        foreach (var item in NumberOfPairs.Run(new int[] { 1, 1 }))
        {
            Console.WriteLine(item);
        }

    }
}