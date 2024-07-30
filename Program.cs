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
        int[][] val = new int[][]
        {
            new int[] { 2,3,3,10 },
            new int[] { 3,3,3,1 },
            new int[] { 6,1,1,4 },
        };

       // int[][] val = new int[][]
       //{
       //      new int[] { 39,3,1000,1000 },
       //};

        string log = string.Join(',', GetGoodIndices.Run2(val, 2));
        Console.WriteLine(log);
    }
}
