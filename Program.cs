﻿using DailyExercises;
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

        Console.WriteLine(AverageValue.Run(new int[] { 1, 2, 4, 7, 10 }));
        Console.ReadLine();
    }
}
//[1,2,4,7,10]