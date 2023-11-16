using DailyExercises;
using DailyExercises.Helper.Tree;
using DailyExercises.LCP;
using DailyExercises.Utils;
using Newtonsoft.Json;
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



        //var val = LargestPathValue.Run4("abaca", new int[][]
        //{
        //    new int[]{0,1},
        //    new int[]{0,2},
        //    new int[]{2,3},
        //    new int[]{3,4},
        //});

        var val = LongestAlternatingSubarray.Run(new int[]
        {
           1,2
        },2);
        //for (int i = 0; i < 100000; i++)
        //{
        //    Console.WriteLine(i);
        //}
        //return;
        //string data1 = File.ReadAllText(@"C:\Users\Naflim\Desktop\data.txt");
        //var data2 = IOUtils.GetArrsByFile(@"C:\Users\Naflim\Desktop\data2.txt");
        //var val = LargestPathValue.Run4(data1, data2);

        //var data = IOUtils.GetArrsByFile(@"C:\Users\Naflim\Desktop\people.txt");
        //var val = LargestPathValue.Run2("nnllnzznn", data);

        Console.WriteLine(val);
    }
}
