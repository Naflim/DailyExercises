using DailyExercises;
using DailyExercises.Helper.Tree;
using DailyExercises.LCP;
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
        var data = IOUtils.GetArrsByFile(@"C:\Users\Naflim\Desktop\data.txt");
        var val = PacificAtlantic.Run(data);
        foreach (var item in val)
        {
            string str = string.Join(',', item);
            Console.WriteLine(str);
        }
        Console.ReadLine();
    }
}
