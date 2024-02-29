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
        //  int[][] edges = new int[][]
        //  {
        //        new int[] {0,1},
        //        new int[] { 1,2},
        //        new int[] {1,3},
        //        new int[] { 4,2},
        //  };

        //  int[][] guesses = new int[][]
        //{
        //        new int[] {1,3},
        //        new int[] { 0,1},
        //        new int[] {1,0},
        //        new int[] { 2,4},
        //};

        //  int[][] edges = new int[][]
        // {
        //           new int[] {1,3},
        //          new int[] { 0,1},
        //          new int[] {2,3},
        //          new int[] { 3,4},
        // };

        //  int[][] guesses = new int[][]
        //{
        //          new int[] {1,0},
        //          new int[] { 3,4},
        //          new int[] {2,1},
        //          new int[] {3,2},
        //};

        int[][] edges = IOUtils.GetArrsByFile(@"C:\Users\Naflim\Desktop\data.txt");

        int[][] guesses = IOUtils.GetArrsByFile(@"C:\Users\Naflim\Desktop\data2.txt");


        Console.WriteLine(RootCount.Run2(edges, guesses, 50000));
    }
}
