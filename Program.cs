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
        Console.WriteLine(LongestArithSeqLength.Run(new int[] { 3, 6, 9, 12 }));
        Console.ReadLine();
    }
}

//[3,6,9,12]
//[9,4,7,2,10]
//[20,1,15,3,10,5,8]
//[83,20,17,43,52,78,68,45]