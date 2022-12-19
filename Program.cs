using DailyExercises;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(ValidPath.Run(6,new int[][]
        {
            new int[] { 0,1},
            new int[] { 0,2},
            new int[] {3,5},
              new int[] {5,4},
              new int[] {4,3},
        }, 0, 5));
        Console.ReadLine();
    }
}

