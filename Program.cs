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
using DailyExercises;

class Program
{
    public static void Main()
    {
        var result = SingleNumber2.Run3([2, 2, 3, 2]);

        Console.WriteLine(result);

        //Console.WriteLine(Convert.ToString(int.MaxValue, 2).Length);
        //Console.WriteLine(Convert.ToString(int.MinValue, 2).Length);
        //Console.WriteLine(Convert.ToString(-1, 2));
    }
}
    