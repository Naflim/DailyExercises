using DailyExercises;
using DailyExercises.Helper.Tree;
using DailyExercises.LCP;
using DailyExercises.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        //int[][] val = new int[][]
        //{
        //    new int[] { 0,1},
        //    new int[] { 1,0},
        //};

        //int[][] val = new int[][]
        //{
        //    new int[] { 0,1,0},
        //    new int[] { 0,0,0},
        //     new int[] { 0,0,1},
        //};

        int[][] val = new int[][]
        {
            new int[] { 1,1,1,1,1},
            new int[] { 1,0,0,0,1},
            new int[] { 1,0,1,0,1},
            new int[] { 1,0,0,0,1},
            new int[] { 1,1,1,1,1},
        };

        Console.WriteLine(ShortestBridge.Run(val));

        Console.ReadLine();
    }
}
