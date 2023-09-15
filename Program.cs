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
        //    new int[]{ 1,2 },
        //    new int[]{ 3 },
        //    new int[]{ 3 },
        //    new int[]{ },
        //};

        //var val = new int[][]
        //{
        //    new int[]{4,3,1 },
        //    new int[]{ 3,2,4 },
        //    new int[]{ 3 },
        //    new int[]{ 4 },
        //    new int[]{ },
        //};

        var val = new int[][]
       {
             new int[]{ 0,2 },
             new int[]{ 2,1 },
              new int[]{ 2,0 },
       };

        Console.WriteLine(GiveGem.Run(new int[] { 3, 1, 2 }, val));


        Console.ReadLine();
    }
}