using DailyExercises;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        var val = TwoOutOfThree.Run(new int[] { 1, 2, 2 }, new int[] { 4, 3, 3 }, new int[] { 5 });
        foreach (var v in val) Console.WriteLine(v);

        Console.ReadLine();
    }
}

