using DailyExercises;
using DailyExercises.Helper.Tree;
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
        Stopwatch timer = new Stopwatch();

        timer.Start();
        long count = 0;
        long rbKey = 0;
        long dicKey = 0;
        Random random = new Random();
        //for (long i = 1; i <= 10; i++)
        //{
        //    count++;
        //}
        //timer.Stop();
        //Console.WriteLine($"循环耗时：{timer.ElapsedMilliseconds}毫秒");

        timer.Restart();
        Dictionary<long, long> dic = new Dictionary<long, long>();
        for (long i = 1; i <= 1000000; i++)
        {
            dicKey = random.Next(1000000);
            //Console.WriteLine($"{dicKey}");
            dic[dicKey] = dicKey;
        }
        timer.Stop();
        Console.WriteLine($"字典耗时：{timer.ElapsedMilliseconds}毫秒");

        timer.Restart();
        RBTree<long, long> tree = new RBTree<long, long>();
        //var data = IOUtils.GetDataByFile("C:/Users/Naflim/Desktop/data.txt").ToArray();
        //data = data.Distinct().ToArray();
        //Console.WriteLine($"len:{data.Length}");
        //Console.WriteLine(string.Join(',', data));
        //for (long i = 0; i < data.Length; i++)
        //{
        //    rbKey = data[i];
        //    //Console.WriteLine($"添加{rbKey}");
        //    tree.Put(rbKey, rbKey);
        //    tree.PrintTree();
        //    //if (tree.Debug(77))
        //    //{
        //    //    Console.WriteLine("发生异常");
        //    //}
        //}


        //return;
        //for (long i = 0; i < data.Length; i++)
        //{
        //    rbKey = data[i];
        //    Console.WriteLine($"{rbKey}");
        //    tree.Put(rbKey, rbKey);
        //}
        for (long i = 1; i <= 1000000; i++)
        {
            rbKey = random.Next(1000000);
            //Console.WriteLine($"{rbKey}");
            tree.Put(rbKey, rbKey);
        }
        timer.Stop();
        Console.WriteLine($"红黑树耗时：{timer.ElapsedMilliseconds}毫秒");

        long value;

        timer.Restart();
        value = dic[dicKey];
        timer.Stop();
        Console.WriteLine($"字典查询{value},耗时{timer.ElapsedMilliseconds}毫秒");

        timer.Restart();
        value = tree.Find(rbKey);
        timer.Stop();
        Console.WriteLine($"红黑树查询{value},耗时{timer.ElapsedMilliseconds}毫秒");

        Console.ReadLine();
    }
}