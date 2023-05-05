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
        Console.WriteLine(WordBreak.FWordBreak("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", new List<string>() 
        {
           "a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"
        }));

        Console.WriteLine();
    }
}