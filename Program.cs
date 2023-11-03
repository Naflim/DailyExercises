using DailyExercises;
using DailyExercises.Helper.Tree;
using DailyExercises.LCP;
using DailyExercises.Utils;
using Newtonsoft.Json;
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
        Node node = new Node(1,new Node(2,new Node(4),new Node(5),null),new Node(3,null,new Node(7),null),null);
        Console.WriteLine(Connect.Run(node));
    }
}
