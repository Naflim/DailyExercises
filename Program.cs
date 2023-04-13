using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(MostFrequentEven.Run(new int[] { 29, 47, 21, 41, 13, 37, 25, 7 }));
    }
}

