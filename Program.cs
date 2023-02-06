using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        //TreeNode root = new(2, new(1), new(3,new(0), new(1)));
        TreeNode root = new(0);
        Console.WriteLine(EvaluateTree.Run(root));
    }
}