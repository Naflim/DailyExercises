using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        

        Console.WriteLine(CountDaysTogether.Run("08-15", "08-18","08-16","08-16"));
    }
}