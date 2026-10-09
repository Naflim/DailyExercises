using DailyExercises;
using DailyExercises.Utils;

class Program
{
    public static void Main()
    {
        //var root = new TreeNode(1, null, new TreeNode(15, new TreeNode(14,new TreeNode(7,new TreeNode(2,null,new TreeNode(3)),new TreeNode(12,new TreeNode(9,null,new TreeNode(11)))),new TreeNode(17))));
        var root = new TreeNode(1,null,new TreeNode(2,null,new TreeNode(3,null,new TreeNode(4))));
        var result = BalanceBST.Run(root);
        Console.WriteLine(result);
    }
}
