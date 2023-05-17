using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(FindNumberOfLIS.Run(new int[] { 1, 2, 4, 3, 5, 4, 7, 2 }));

        Console.ReadLine();
    }
}
//[1,3,5,4,7]

//[1,2,4,3,5,4,7,2]