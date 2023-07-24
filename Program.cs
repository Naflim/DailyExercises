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
        //var tree = new TreeNode(1,new TreeNode(2),new TreeNode(3));
        //var tree = new TreeNode(-10,new TreeNode(9),new TreeNode(20,new TreeNode(15),new TreeNode(7)));
        //var tree = new TreeNode(1, new TreeNode(-2, new TreeNode(1, null, new TreeNode(-1)), new TreeNode(3)), new TreeNode(-3, new TreeNode(-2)));
        var tree new TreeNode(2,)
        Console.WriteLine(MaxPathSum.Run(tree));
        Console.ReadLine();
    }
}

//[2,1,3,null,4]
//[5,4,8,11,null,13,4,7,2,null,null,null,1]
//[1,-2,-3,1,3,-2,null,-1]