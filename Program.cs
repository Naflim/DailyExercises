using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(IsGoodArray.Run(new int[] { 3, 6 }));
    }
}