using DailyExercises;
using DailyExercises.Helper.Tree;
using DailyExercises.LCP;
using DailyExercises.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        var val = AvoidFlood.Run(new int[] { 1, 2, 0, 1, 2 });
        foreach (int i in val)
        {
            Console.WriteLine(i);
        }
        Console.ReadLine();
    }
}
