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
        Console.WriteLine(MaxArea.Run(5, 4, new int[]
        {
            1,2,4
        }, new int[]
        {
            1,3
        }));

        Console.WriteLine(MaxArea.Run(5, 4, new int[]
       {
            3,1
       }, new int[]
       {
            1
       }));

        Console.WriteLine(MaxArea.Run(5, 4, new int[]
      {
           3
      }, new int[]
      {
            3
      }));
        Console.ReadLine();
    }
}
