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
        Console.WriteLine(FindTheArrayConcVal.Run(new int[] 
        {
           5,14,13,8,12
        }));
        Console.ReadLine();
    }
}
