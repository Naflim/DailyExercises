using DailyExercises;
using DailyExercises.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(FindReplaceString.Run("abcd",
            new int[] { 0, 2 },
            new string[] { "a", "cd" },
            new string[] { "eee", "ffff" }));


        //Console.WriteLine(FindReplaceString.Run("abcd",
        //    new int[] { 0, 2 },
        //    new string[] { "ab", "ec" },
        //    new string[] { "eee", "ffff" }));

        //Console.WriteLine(FindReplaceString.Run("vmokgggqzp",
        //    new int[] { 3, 5, 1 },
        //    new string[] { "kg", "ggq", "mo" },
        //    new string[] { "s", "so", "bfr" }));

        //    Console.WriteLine(FindReplaceString.Run("abcde",
        //new int[] { 2, 2 },
        //new string[] { "cdef", "bc" },
        //new string[] { "f", "fe" }));
        Console.ReadLine();
    }
}