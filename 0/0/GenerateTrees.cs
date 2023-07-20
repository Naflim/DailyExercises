using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 95. 不同的二叉搜索树 II
    /// </summary>
    internal class GenerateTrees
    {
        public static IList<TreeNode> Run(int n)
        {
            List<TreeNode> trees = new List<TreeNode>();
            for (int i = 1; i <= n; i++)
            {
                TreeNode node = new TreeNode(i);
                var val = Generate(node, 1, n);
                trees.AddRange(val);
            }

            return trees;
        }

        private static List<TreeNode> Generate(TreeNode node, int start, int end)
        {
            //左树
            List<TreeNode> leftTrees = new List<TreeNode>();
            var now = node.val;
            for (int i = start; i < now; i++)
            {
                TreeNode leftTree = new TreeNode(i);
                leftTrees.AddRange(Generate(leftTree, start, now - 1));
            }

            //右树
            List<TreeNode> rightTrees = new List<TreeNode>();
            for (int i = now + 1; i <= end; i++)
            {
                TreeNode rightTree = new TreeNode(i);
                rightTrees.AddRange(Generate(rightTree, now + 1, end));
            }

            //组装左树
            List<TreeNode> leftResult = new List<TreeNode>();
            if (leftTrees.Count > 0)
            {
                leftTrees.ForEach(leftTree =>
                {
                    TreeNode copy = new();
                    Copy(node, copy);
                    copy.left = leftTree;
                    leftResult.Add(copy);
                });
            }
            else
            {
                leftResult = new List<TreeNode> { node };
            }


            //组装右树
            List<TreeNode> result = new List<TreeNode>();
            foreach (var tree in leftResult)
            {
                foreach (var rightTree in rightTrees)
                {
                    TreeNode copy = new();
                    Copy(tree, copy);
                    copy.right = rightTree;
                    result.Add(copy);
                }
            }

            if (result.Count == 0)
                return leftResult;
            else
                return result;
        }


        private static TreeNode? Search(TreeNode root, out bool isLeft)
        {
            if (root.left ==  null)
            {
                isLeft = true;
                return root;
            }
            else if (root.left.val != -1)
            {
                var node = Search(root.left, out isLeft);
                if (node != null) return node;
            }

            if (root.right == null)
            {
                isLeft = false;
                return root;
            }
            else if (root.right.val != -1)
            {
                var node = Search(root.right, out isLeft);
                if (node != null) return node;
            }

            isLeft = false;
            return null;
        }

        public static void Copy(TreeNode node, TreeNode copyNode)
        {
            copyNode.val = node.val;
            if (node.left != null)
            {
                copyNode.left = new TreeNode();
                Copy(node.left, copyNode.left);
            }

            if (node.right != null)
            {
                copyNode.right = new TreeNode();
                Copy(node.right, copyNode.right);
            }
        }

        public static TreeNode? Find(TreeNode root, int val)
        {
            if (root.val == val) return root;

            if (root.left != null)
            {
                var node = Find(root.left, val);
                if (node != null) return node;
            }

            if (root.right != null)
            {
                var node = Find(root.right, val);
                if (node != null) return node;
            }

            return null;
        }
    }
}
