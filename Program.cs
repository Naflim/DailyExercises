using DailyExercises;
using DailyExercises._2000._700;
using DailyExercises.Helper.Tree;
using DailyExercises.LCP;
using DailyExercises.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Naflim.DevelopmentKit.DataStructure.Tree;

class Program
{
    public static void Main()
    {
        //int[] data = new int[]
        //{
        //    5,2,1
        //};

        int[] data = IOUtils.GetArrByFile(@"C:\Users\Naflim\Desktop\data.txt");
        Console.WriteLine(NumberOfWeeks.Run(data));
    }
}
