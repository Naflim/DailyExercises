using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        AlertNames.Run(new string[]
        {
      "a","a","a","a","a","a","b","b","b","b","b"
        }, new string[]
        {
    "23:27","03:14","12:57","13:35","13:18","21:58","22:39","10:49","19:37","14:14","10:41"
        }).ToList().ForEach(name => Console.WriteLine(name));

        Console.ReadLine();
    }
}