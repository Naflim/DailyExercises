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
        //TreeNode root = new TreeNode(-1, null, new TreeNode(-1));

        TreeNode root = new TreeNode(-1, new TreeNode(-1,new TreeNode(-1),new TreeNode(-1)), new TreeNode(-1));

        FindElements demo = new FindElements(root);

        Console.WriteLine(demo.Find(1));
        Console.WriteLine(demo.Find(3));
        Console.WriteLine(demo.Find(5));
    }
}
