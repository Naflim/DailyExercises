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
        Console.WriteLine(MaxProfit4.Run(2,new int[] { 1, 2, 4, 7 }));
        Console.ReadLine();
    }
}