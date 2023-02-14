using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(LongestWPI.Run(new int[] { 9, 9, 6, 0, 6, 6, 9 }));
    }
}