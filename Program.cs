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
        var val = CriticalConnections.Run(4, new int[][]
        {
            new int[] { 0, 1,},
            new int[] { 1, 2,},
            new int[] { 2, 3,},
            //new int[] { 1, 3,},
        });

        //        var val = CriticalConnections.Run(2, new int[][]
        //{
        //                    new int[] { 0, 1,},
        //});

        //var val = CriticalConnections.Run(6, new int[][]
        //{
        //    new int[] { 0, 1,},
        //    new int[] { 1, 2,},
        //    new int[] { 2, 0,},
        //    new int[] { 1, 3,},
        //    new int[] { 3, 4,},
        //    new int[] { 4, 5,},
        //    new int[] { 5, 3,},
        //});


        foreach (var conn in val)
        {
            string log = string.Join(',', conn);
            Console.WriteLine(log);
        }

        Console.ReadLine();
    }
}

