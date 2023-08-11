using DailyExercises;
using DailyExercises.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        var demo = new int[][]
        {
            new int[]{1,2,3},
            new int[]{4,5,6},
            new int[]{7,8,9},
        };
        Console.WriteLine(DiagonalSum.Run(demo));
        Console.ReadLine();
    }
}