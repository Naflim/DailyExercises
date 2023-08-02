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
        var fronts = new int[]
        {
           2,1,1,2,2
        };

        var backs = new int[]
       {
          2,2,1,2,1
       };

        Console.WriteLine(Flipgame.Run(fronts,backs));
        Console.ReadLine();
    }
}
