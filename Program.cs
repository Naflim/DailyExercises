using DailyExercises;
using DailyExercises.Helper.Tree;
using DailyExercises.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        var redEdges = IOUtils.GetArrsByFile("C:/Users/Naflim/Desktop/red2.txt");
        var blueEdges = IOUtils.GetArrsByFile("C:/Users/Naflim/Desktop/blue2.txt");

        var val = ShortestAlternatingPaths.Run(9, redEdges, blueEdges);

        foreach (var item in val) 
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();
    }
}