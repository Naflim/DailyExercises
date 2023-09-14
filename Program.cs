using DailyExercises;
using DailyExercises.Helper.Tree;
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
        var val = new int[][]
        {
            new int[]{ 0,1 },
            new int[]{ 1,3 },
            new int[]{ 2,3 },
            new int[]{ 4,0 },
            new int[]{ 4,5 },
        };

        //var val = new int[][]
        //{
        //    new int[]{ 1,0 },
        //    new int[]{ 1,2 },
        //    new int[]{ 3,2 },
        //    new int[]{ 3,4 },
        //};

        // var val = new int[][]
        //{
        //     new int[]{ 1,0 },
        //     new int[]{ 2,0 },
        //};

        Console.WriteLine(MinReorder.Run2(6, val));
        Console.ReadLine();
    }
}