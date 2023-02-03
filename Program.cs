using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        //TreeNode root = new(1, new(2, new(4, new(8), new(9)), new(5, new(10), new(11))), new(3, new(6), new(7)));
        //Console.WriteLine(BtreeGameWinningMove.Run(root, 11, 3));
        TreeNode root = new(1, new(2, new(4), new(5)), new(3));
        Console.WriteLine(BtreeGameWinningMove.Run(root, 5, 1));
        //TreeNode root = new(1,new(2),new(3));
        //Console.WriteLine(BtreeGameWinningMove.Run(root, 7, 3));
        //TreeNode root = new(6, new(3, new(7), new(4, null, new(2, null, new(1, null, new(5))))), null);
        //Console.WriteLine(BtreeGameWinningMove.Run(root, 7, 3));
    }
}