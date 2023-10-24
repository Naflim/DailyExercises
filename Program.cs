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
        //var val = new int[][]
        //{
        //    new int[] { 0, 1,},
        //    new int[] { 0, 3,},
        //    new int[] { 1, 2,},
        //    new int[] { 1, 3,},
        //};

       // var val = new int[][]
       //{
       //     new int[] { 0, 1,},
       //     new int[] { 0, 3,},
       //     new int[] { 1, 2,},
       //     new int[] { 1, 3,},
       //     new int[] { 2, 3,},
       //     new int[] { 2, 4,},
       //};

        var val = new int[][]
       {
            new int[] { 2, 3,},
            new int[] { 0, 3,},
            new int[] { 0, 4,},
            new int[] { 4, 1,},
       };


        //foreach (var v in val)
        //{
        //    Console.WriteLine(v);
        //}

        Console.WriteLine(NumRollsToTarget.Run(30,30,500));
        Console.ReadLine();
    }
}
