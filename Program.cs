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
        Console.WriteLine(LengthOfLIS.Run(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));

        Console.ReadLine();
    }
}
//[10,9,2,5,3,7,101,18]
//[4,10,4,3,8,9][0,1,0,3,2,3]