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
        //int[][] g = new int[][]
        //{
        //    new int[] { 1,1,0},
        //    new int[] { 1,1,0},
        //    new int[] { 0,0,1},
        //};

        //int[] initial = new int[] { 0, 1 };

        //int[][] g = new int[][]
        //{
        //    new int[] { 1,1,0},
        //    new int[] { 1,1,1},
        //    new int[] { 0,1,1},
        //};

        //int[] initial = new int[] { 0, 1 };

        int[][] g = new int[][]
        {
            new int[] { 1,1,0,0},
            new int[] { 1,1,1,0},
            new int[] { 0,1,1,1},
              new int[] { 0,0,1,1},
        };

        int[] initial = new int[] { 0, 1 };
        Console.WriteLine(MinMalwareSpread.Run(g,initial));
    }
}
