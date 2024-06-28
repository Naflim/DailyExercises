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
        //int[] val = new int[]
        //{
        //    3,2,4,1
        //};

//        int[] val = new int[]
//{
//           3,5,1,2,6
//};

        int[] val = new int[]
{
           2,6,2,2,7,4,7
};


        //int[] val = new int[]
        //{
        //   6,4,4,6
        //};
        Console.WriteLine(MaxmiumScore.Run(new int[] 
        {
        7,4,1
        }, 1));
    }
}
