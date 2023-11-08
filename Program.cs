using DailyExercises;
using DailyExercises.Helper.Tree;
using DailyExercises.LCP;
using DailyExercises.Utils;
using Newtonsoft.Json;
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
        //var val = SortItems.Run3(8, 2,
        //    new int[]
        //    {
        //        -1,-1,1,0,0,1,0,-1
        //    },
        //    new int[][]
        //    {
        //        new int[]{},
        //        new int[]{6},
        //        new int[]{5},
        //        new int[]{6},
        //        new int[]{3,6},
        //        new int[]{},
        //        new int[]{},
        //    });


        //var val = SortItems.Run(5, 5,
        //   new int[]
        //   {
        //        2,0,-1,3,0
        //   },
        //   new int[][]
        //   {
        //        new int[]{2,1,3},
        //        new int[]{2,4},
        //        new int[]{},
        //        new int[]{},
        //        new int[]{},
        //   });

        //     var val = SortItems.Run(5, 5,
        //new int[]
        //{
        //             0,0,2,1,0
        //},
        //new int[][]
        //{
        //             new int[]{3},
        //             new int[]{},
        //             new int[]{},
        //             new int[]{},
        //             new int[]{1,3,2},
        //});


        //     var val = SortItems.Run2(8, 2,
        //new int[]
        //{
        //                  -1,-1,1,0,0,1,0,-1
        //},
        //new int[][]
        //{
        //                  new int[]{3},
        //                  new int[]{6,0},
        //                  new int[]{5},
        //                  new int[]{6},
        //                  new int[]{3,6,7},
        //                  new int[]{},
        //                  new int[]{},
        //                  new int[]{},
        //});

        //     var val = SortItems.Run2(10, 4,
        //new int[]
        //{
        //                       0,1,1,2,3,-1,0,0,0,1
        //},
        //new int[][]
        //{
        //                       new int[]{2,5},
        //                       new int[]{3,5,4,6,8,7,2},
        //                       new int[]{7},
        //                       new int[]{},
        //                       new int[]{},
        //                       new int[]{},
        //                       new int[]{},
        //                       new int[]{},
        //                       new int[]{},
        //                       new int[]{},
        //});

        var data1 = IOUtils.GetArrByFile(@"C:\Users\Naflim\Desktop\data.txt");
        var data2 = IOUtils.GetArrsByFile(@"C:\Users\Naflim\Desktop\people.txt");


        var val = SortItems.Run3(30000, 13931, data1, data2);

        foreach (var item in val)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }
}
