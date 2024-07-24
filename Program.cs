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
        //int[][] val = new int[][]
        //{
        //    new int[] {2,1,3 },
        //    new int[] { 6,1,4 },
        //};

        // int[][] val = new int[][]
        //{
        //      new int[] {1,1,5 },
        //      new int[] { 10,10,5 },
        //};

        //   int[][] val = new int[][]
        //{
        //          new int[] {1,2,3 },
        //          new int[] { 2,3,1 },
        //           new int[] {3,4,2 },
        //            new int[] { 4,5,3 },
        //             new int[] {5,6,4 },
        //};

        int[][] val = IOUtils.GetArrsByFile(@"C:\Users\Naflim\Desktop\data.txt");

        var 

        Console.WriteLine(MaximumDetonation.Run2(val));
    }
}
