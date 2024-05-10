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
        int[][] p = new int[][]
        {
            new int[] { 1,4,2 },
            new int[] { 2,2,7 },
            new int[] { 2,1,3 },
        };

        //int[][] p = new int[][]
        //{
        //    new int[] { 3,2,10 },
        //    new int[] { 1,4,2 },
        //    new int[] { 4,1,3 },
        //};
        Console.WriteLine(SellingWood.Run2(3,5,p));
    }
}
