using Naflim.DevelopmentKit.DataStructure.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 222. 完全二叉树的节点个数
    /// </summary>
    internal class CountNodes
    {
        public static int Run(TreeNode root)
        {
            if (root == null) return 0;

            Tree<TreeNode> tree = new Tree<TreeNode>(root, n =>
            {
                List<TreeNode> list = new List<TreeNode>();
                if (n.left != null)
                    list.Add(n.left);

                if (n.right != null)
                    list.Add(n.right);

                return list;
            });

            return tree.Count();
        }
    }
}
