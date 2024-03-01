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

class Program
{
    public static void Main()
    {

        Console.WriteLine(ValidPartition.Run(new int[]
        {
           993335,993336,993337,993338,993339,993340,993341
        }));
    }
}
