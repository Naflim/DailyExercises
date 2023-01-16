using DailyExercises;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        //string[] demo = { "1", "2", "3" };
        //demo = demo.Reverse().ToArray();
        //for (int i = 0; i < demo.Length; i++)
        //{
        //    Console.WriteLine(demo[i]);
        //}

        Console.WriteLine(AreSentencesSimilar.Run("Eating right now", "Eating"));
        Console.ReadLine();
    }
}

