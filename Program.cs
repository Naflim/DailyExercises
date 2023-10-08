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
        //var val = UpdateMatrix.Run(new int[][]
        //{
        //    new int[] { 0, 0, 0 },
        //    new int[] { 0, 1, 0 },
        //    new int[] { 0, 0, 0 },
        //});

        var val = UpdateMatrix.Run(new int[][]
       {
            new int[] { 0, 0, 0 },
            new int[] { 0, 1, 0 },
            new int[] { 1, 1, 1 },
       });

        for (int i = 0; i < val.Length; i++)
        {
            for (int j = 0; j < val[i].Length; j++)
            {
                Console.Write($"{val[i][j]},");
            }
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
