using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(BestHand.Run(new int[] { 13, 2, 3, 1, 9 }, new char[] { 'a', 'a', 'a', 'a', 'a' }));
        Console.WriteLine(BestHand.Run(new int[] { 4, 4, 2, 4, 4 }, new char[] { 'd', 'a', 'a', 'b', 'c' }));
        Console.WriteLine(BestHand.Run(new int[] { 10, 10, 2, 12, 9 }, new char[] { 'a', 'b', 'c', 'a', 'd' }));
    }
}