using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
         Console.WriteLine(CheckXMatrix.Run(new int[][] 
         {
             //new int[]{2,0,0,1},
             //new int[]{0,3,1,0},
             //new int[]{0,5,2,0},
             //new int[]{4,0,0,2},
             new int[]{5,7,0},
             new int[]{0,3,1},
             new int[]{0,5,0},
         }));
    }
}
