using DailyExercises;
using DailyExercises.Helper.Tree;
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
        Console.WriteLine(NumOfMinutes.Run(6,2,new int[] 
        {
            2,2,-1,2,2,2
        },new int[] 
        {
            0,0,1,0,0,0
        }));
        Console.ReadLine();
    }
}