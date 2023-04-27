using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(LongestStrChain.Run(new string[] 
        {
            "a","b","ba","bca","bda","bdca"
        }));
    }
}