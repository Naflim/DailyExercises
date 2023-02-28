using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        // var arr = MergeSimilarItems.Run(new int[][]
        // {
        //     new int[]{1,1},
        //     new int[]{4,5},
        //     new int[]{3,8},
        // }, new int[][]
        // {
        //     new int[]{3,1},
        //     new int[]{1,5},
        // }).ToArray();

        var arr = MergeSimilarItems.Run(new int[][]
       {
            new int[]{1,1},
            new int[]{3,2},
            new int[]{2,3},
       }, new int[][]
       {
            new int[]{2,1},
            new int[]{3,2},
             new int[]{1,3},
       }).ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"{arr[i][0]},{arr[i][1]}");
        }
    }
}