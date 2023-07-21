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
        //var tree = new TreeNode(3, new TreeNode(2, right: new TreeNode(3)), new TreeNode(3, right: new TreeNode(1)));
        //var tree = new TreeNode(3, new TreeNode(4,new TreeNode(1) , new TreeNode(3)), new TreeNode(5, right: new TreeNode(1)));
        //var tree = new TreeNode(4, new TreeNode(1, new TreeNode(2, new TreeNode(3))));
        var tree = new TreeNode(2,new TreeNode(1,new TreeNode(4)),new TreeNode(3));

        Console.WriteLine(Rob3.Run3(tree));
        Console.ReadLine();
    }
}

//[2,1,3,null,4]