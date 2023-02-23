using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        foreach (var item in CircularPermutation.Run(2, 3))
        {
            Console.WriteLine(item);
        }
    }
}