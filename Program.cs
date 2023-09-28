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

        Console.WriteLine(MaxSubarraySumCircular.Run3(new int[]
        {
           1,-2,3,-2
        }));


        Console.WriteLine(MaxSubarraySumCircular.Run3(new int[] 
        {
            5,-3,5
        }));

        Console.WriteLine(MaxSubarraySumCircular.Run3(new int[]
        {
            3,-2,2,-3
        }));


        Console.ReadLine();
    }
}
