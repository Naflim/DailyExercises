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
        //var val = FindSmallestSetOfVertices.Run(6, new int[][]
        //{
        //    new int[] { 0, 1,},
        //    new int[] { 0, 2,},
        //    new int[] { 2, 5,},
        //    new int[] { 3, 4,},
        //    new int[] { 4, 2,},
        //});

        ////var val = FindSmallestSetOfVertices.Run(5, new int[][]
        ////{
        ////    new int[] { 0, 1,},
        ////    new int[] { 2, 1,},
        ////    new int[] { 3, 1,},
        ////    new int[] { 1, 4,},
        ////    new int[] { 2, 4,},
        ////});


        //foreach (var v in val)
        //{
        //    Console.WriteLine(v);
        //}

        Console.WriteLine(CountSeniors.Run(new string[]
        {
            "7868190130M7522","5303914400F9211","9273338290F4010"
        }));
        Console.ReadLine();
    }
}
