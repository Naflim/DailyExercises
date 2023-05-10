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
        Console.WriteLine(MinDistance.Run("pneumonoultramicroscopicsilicovolcanoconiosis", "ultramicroscopically"));

        Console.ReadLine();
    }
}