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
        var arr = SortPeople.Run(new string[]
        {
           "Alice","Bob","Bob"
        }, new int[]
        {
            155,185,150
        });

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
        //Console.WriteLine(LastSubstring.Run("cacacb"));
    }
}