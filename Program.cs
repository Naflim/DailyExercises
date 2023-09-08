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

        Console.WriteLine(FindDelayedArrivalTime.Run(13,11));

        Console.ReadLine();
    }
}