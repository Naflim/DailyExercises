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
        var arr = IOUtils.GetDataByFile("C:\\Users\\Naflim\\Desktop\\data.txt");
        Console.WriteLine(RepairCars.Run(arr, 1000000));

        Console.ReadLine();
    }
}