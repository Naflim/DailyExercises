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
        //Stack<int> stack = new Stack<int>();
        //Queue<int> queue = new Queue<int>();
        //for (int i = 0; i < 10; i++)
        //{
        //    stack.Push(i);
        //    queue.Enqueue(i);
        //}

        //while (stack.Count > 0) 
        //{
        //    Console.WriteLine($"stack:{stack.Pop()}");
        //    Console.WriteLine($"queue:{queue.Dequeue()}");
        //}


        //var val = NearestExit.Run(new char[][] 
        //{
        //    new char[]{ '+', '+', '.', '+' },
        //    new char[]{ '.','.','.','+' },
        //    new char[]{ '+','+','+','.' },
        //}, new int[]
        //{
        //    1,2
        //});

        //var val = NearestExit.Run(new char[][]
        //{
        //    new char[]{ '+','+','+' },
        //    new char[]{ '.','.','.' },
        //    new char[]{ '+','+','+' },
        //}, new int[]
        //{
        //    1,0
        //});

        var val = NearestExit.Run(new char[][]
        {
            new char[]{'+','.','+','+','+','+','+' },
            new char[]{'+','.','+','.','.','.','+' },
            new char[]{ '+','.','+','.','+','.','+' },
            new char[]{ '+','.','.','.','+','.','+' },
            new char[]{'+','+','+','+','+','.','+' },
        }, new int[]
        {
            3,2
        });

        //var val = NearestExit.Run(new char[][]
        //{
        //    new char[]{'.','+' },
        //}, new int[]
        //{
        //    0,0
        //});


        Console.WriteLine(val);

        Console.ReadLine();
    }
}
