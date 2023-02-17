using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(Largest1BorderedSquare.Run(new int[][]
        {
            //new int[]{1,1,1 },
            //new int[]{1,0,1 },
            //new int[]{1,1,1 },
            new int[]{1,1,0,0},
        }));
    }
}