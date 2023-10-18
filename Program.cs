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
        var data = IOUtils.GetArrByFile(@"C:\Users\Naflim\Desktop\data.txt");
        Console.WriteLine(MaxKelements.Run2(data, 1000));
        Console.ReadLine();
    }
}
