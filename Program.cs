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
        Console.WriteLine(MaxSubarraySumCircular.Run2(new int[] { -2, -3, -1}));
        Console.ReadLine();
    }
}