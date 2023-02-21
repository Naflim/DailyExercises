using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(MinTaps.Run(7, new int[]
        {
       1,2,1,0,2,1,0,1
        }));
    }
}