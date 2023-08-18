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
        Console.WriteLine(MaxSizeSlices.Run2(new int[] { 1, 2, 3, 4, 5, 6 }));

        Console.ReadLine();
    }
}