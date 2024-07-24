using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 98. 验证二叉搜索树
    /// </summary>
    internal class IsValidBST
    {
        public static bool Run(TreeNode root)
        {
            return IsValidByDFS(root, long.MinValue, long.MaxValue);
        }

        public static bool IsValidByDFS(TreeNode node, long min, long max)
        {
            if (node.left != null && (node.val <= node.left.val || node.left.val <= min || !IsValidByDFS(node.left, min, node.val)))
            {
                return false;
            }

            if (node.right != null && (node.val >= node.right.val || node.right.val >= max || !IsValidByDFS(node.right, node.val, max)))
            {
                return false;
            }

            return true;
        }
    }
}
