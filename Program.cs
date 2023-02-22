using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {

        Console.WriteLine(StoneGameII.Run(new int[]
        {
     1,2,3,4,5,100
        }));
    }
}