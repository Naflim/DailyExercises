﻿using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {

        Console.WriteLine(CountNicePairs.Run(IOUtils.GetDataByFile("C:\\Users\\Naflim\\Desktop\\test.txt")));
        Console.ReadLine();
    }
}

