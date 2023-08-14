using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 617. 合并二叉树
    /// </summary>
    internal class MergeTrees
    {
        public static TreeNode Run(TreeNode root1, TreeNode root2)
        {
            if (root1 == null  && root2 == null) 
                return null;

            TreeNode root = new TreeNode();
            AddNode(root, root1, root2);
            return root;
        }

        public static void AddNode(TreeNode root, TreeNode? node1, TreeNode? node2) 
        {
            root.val = (node1?.val ?? 0) + (node2?.val ?? 0);
            if(node1?.left != null || node2?.left != null) 
            {
                root.left = new TreeNode();
                AddNode(root.left, node1?.left, node2?.left);
            }

            if(node1?.right != null || node2?.right != null)
            {
                root.right = new TreeNode();
                AddNode(root.right, node1?.right, node2?.right);
            }
        }
    }
}
