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
        TreeNode root1 = new TreeNode(1, new TreeNode(3, new TreeNode(5)), new TreeNode(2));
        TreeNode root2 = new TreeNode(2, new TreeNode(1, null, new TreeNode(4)), new TreeNode(3, null, new TreeNode(7)));
        var node = MergeTrees.Run(root1, root2);
        ConsoleNode(node);
        Console.ReadLine();
    }

    public static void ConsoleNode(TreeNode node)
    {
        Console.WriteLine(node.val);
        if(node.left != null)
            ConsoleNode(node.left);

        if(node.right != null)
            ConsoleNode(node.right);
    }
}