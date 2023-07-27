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
        var val = new int[][]
        {
            new int[]{10},
            //new int[]{3,3,1},
        };
        Console.WriteLine(DeleteGreatestValue.Run(val));
        Console.ReadLine();
    }
}
