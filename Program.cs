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

class Program
{
    public static void Main()
    {
        //var data1 = IOUtils.GetArrByFile(@"C:\Users\Naflim\Desktop\data.txt");
        //var data2 = IOUtils.GetArrByFile(@"C:\Users\Naflim\Desktop\flowers.txt");

        var data1 = new int[] {1,3 };
        var data2 = new int[] {2,1 };


        Console.WriteLine(StoneGameVI.Run2(data1,data2));
    }
}
