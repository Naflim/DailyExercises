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
        Console.WriteLine(FindMaxForm.Run(new string[] 
        {
           "10", "0", "1"
        },1,1));
        Console.ReadLine();
    }
}
