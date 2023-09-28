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

        //Console.WriteLine(LadderLength.Run("hit", "cog", new List<string> 
        //{
        //    "hot","dot","dog","lot","log","cog"
        //}));

        //var val = FullBloomFlowers.Run(new int[][]
        //{
        //    new int[] { 1, 6,},
        //    new int[] { 3,7},
        //    new int[] { 9,12},
        //    new int[] { 4,13},
        //}, new int[]
        //{
        //    2,3,7,11
        //});

        // var val = FullBloomFlowers.Run(new int[][]
        //{
        //     new int[] { 1,10},
        //     new int[] { 3,3},
        //}, new int[]
        //{
        //     3,3,2
        //});

        var flowers = IOUtils.GetArrsByFile("C:\\Users\\Naflim\\Desktop\\flowers.txt");
        var people = IOUtils.GetArrByFile("C:\\Users\\Naflim\\Desktop\\people.txt");

      //  var val = FullBloomFlowers.Run(new int[][]
      //{
      //      new int[] { 21,34},
      //      new int[] {17,37},
      //      new int[] { 23,43},
      //      new int[] { 17,46},
      //      new int[] { 37,41},
      //      new int[] { 44,45},
      //      new int[] { 32,45},
      //}, new int[]
      //{
      //      31,41,10,12
      //});

        var val = FullBloomFlowers.Run(flowers, people);


        foreach (var item in val) 
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();


        Console.ReadLine();
    }
}
