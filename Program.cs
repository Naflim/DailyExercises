using DailyExercises;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(AlternateParenthesis.Run("(a)(a)(a)aaa", new string[][]
        {
            new string[] { "a","yes"},
             //new string[] { "age", "two"},
        }));
        Console.ReadLine();
    }
}


