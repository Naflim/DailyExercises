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
using DailyExercises;

class Program
{
    public static void Main()
    {
        //for (int s = 0; s < (1 << 5); s++)
        //{
        //    Console.WriteLine($"s{s}");

        //    for (int t = s; t > 0; t &= t - 1)
        //    {
        //        int i = int.TrailingZeroCount(t);
        //        Console.WriteLine(i);
        //    }

        //    Console.WriteLine("_____");
        //}

        //int s = 31;
        //for (int sub = s; sub > 0; sub = (sub - 1) & s)
        //{
        //    Console.WriteLine($"sub{sub}");

        //    for (int t = sub; t > 0; t &= t - 1)
        //    {
        //        Console.WriteLine($"t{t}");
        //        int i = int.TrailingZeroCount(t);
        //        Console.WriteLine(i);
        //    }

        //    Console.WriteLine("_____");
        //}

        var result = Subsets.Run([-1, 1, 2]);

        foreach (var item in result) 
        {
            Console.WriteLine(string.Join(",",item));
        }
    }
}
    