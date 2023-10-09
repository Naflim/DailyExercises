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

        Console.WriteLine(ShortestPathBinaryMatrix.Run(new int[][] 
        {
            new int[] { 0, 1,},
            new int[] { 1, 0,},
        }));

        Console.WriteLine(ShortestPathBinaryMatrix.Run(new int[][]
      {
            new int[] { 0, 0,0},
            new int[] { 1, 1,0},
            new int[] { 1, 1,0},
      }));

        Console.WriteLine(ShortestPathBinaryMatrix.Run(new int[][]
     {
            new int[] { 1, 0,0},
            new int[] { 1, 1,0},
            new int[] { 1, 1,0},
     }));

        Console.ReadLine();
    }
}
