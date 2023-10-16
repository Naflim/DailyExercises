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
        var val = SingleNumber.Run(new int[] { 0, 1 });
        for (int i = 0; i < val.Length; i++)
        {
            Console.WriteLine(val[i]);
        }
        Console.ReadLine();
    }
}
