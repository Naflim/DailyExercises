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
        Console.WriteLine(MaxProfit3.Run2(new int[] { 3, 3, 5, 0, 0, 3, 1, 4 }));
        Console.ReadLine();
    }
}