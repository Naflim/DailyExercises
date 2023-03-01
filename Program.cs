using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        var arr = LargestLocal.Run(new int[][]
       {
            new int[]{9,9,8,1},
            new int[]{5,6,2,6},
            new int[]{8,2,6,4},
            new int[]{6,2,2,2},
       }).ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                Console.Write($"{arr[i][j]},");
            }
            Console.WriteLine();
        }
    }

}