using DailyExercises;
using DailyExercises._2000._700;
using DailyExercises.Helper.Tree;
using DailyExercises.LCP;
using DailyExercises.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Naflim.DevelopmentKit.DataStructure.Tree;

class Program
{
    public static void Main()
    {
        var price = new int[]
        {
          7,7,7,7
        };

        //var price = IOUtils.GetArrByFile(@"C:\Users\Naflim\Desktop\data.txt");
        Console.WriteLine(MaximumTastiness.Run2(price, 0));
    }
}
