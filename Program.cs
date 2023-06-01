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
        var val = LongestObstacleCourseAtEachPosition.Run(new int[] { 3, 1, 5, 6, 4, 2 });
        foreach (var i in val)
        {
            Console.WriteLine(i);
        }
        Console.ReadLine();
    }
}
//[1,2,4,7,10]
//[1,2,3,2]
//[2,2,1]
//[3,1,5,6,4,2]
//[5,1,5,5,1,3,4,5,1,4]