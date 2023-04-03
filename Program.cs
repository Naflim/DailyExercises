using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        //foreach (var val in PrevPermOpt1.Run(new int[] { 1, 9, 6, 7, 9, 6, 4, 4, 2, 2, 7, 7, 7, 6, 3, 5, 7, 7, 3, 8, 8, 4, 4, 1, 5, 4, 7, 4, 7, 3, 7, 5, 4, 1, 7, 4, 9, 6, 5, 9, 8, 9, 9, 4, 6, 6, 5, 5, 7, 7, 8, 1, 4, 6, 4, 5, 4, 4, 8, 9, 5, 7, 2, 4 }))
        //{
        //    Console.WriteLine(val);
        //}

        foreach (var val in PrevPermOpt1.Run(new int[] { 1, 1, 5 }))
        {
            Console.WriteLine(val);
        }
    }
}

