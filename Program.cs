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
        var val = TopStudents.Run(new string[]
        {
            "smart","brilliant","studious"
        }, new string[]
        {
            "not"
        }, new string[]
        {
            "this student is studious","the student is smart"
        }, new int[]
        {
            1,2
        }, 2);

        foreach (var item in val)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }
}
