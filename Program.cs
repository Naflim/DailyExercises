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
        //        int[][] data = new int[][]
        //       {
        //              new int[] { 2,3,1},
        //              new int[] { 4,5,1},
        //              new int[] { 1,5,2 },
        //       };

        //        int[][] data = new int[][]
        //{
        //                    new int[] { 1,3,2},
        //                    new int[] { 2,5,3},
        //                    new int[] { 5,6,2 },
        //};

        int[][] data = IOUtils.GetArrsByFile(@"C:\Users\Naflim\Desktop\data.txt");

        //Console.WriteLine(FindMinimumTime.Run(data));

        //data = IOUtils.GetArrsByFile(@"C:\Users\Naflim\Desktop\data.txt");

        Console.WriteLine(FindMinimumTime.Run2(data));
    }
}
