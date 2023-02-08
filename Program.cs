using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        RemoveSubfolders
            .Run(new string[] { "/ah/al/am", "/ah/al" })
            .ToList()
            .ForEach(name => Console.WriteLine(name));

        Console.ReadLine();
    }
}