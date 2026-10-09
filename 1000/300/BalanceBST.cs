using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DailyExercises
{
    /// <summary>
    /// 1382. 将二叉搜索树变平衡
    /// </summary>
    internal class BalanceBST
    {
        public static TreeNode Run(TreeNode root)
        {
            List<int> vals = new List<int>();
            GetVals(root, vals);
            return GenerateAVLTree(vals);
        }

        public static void GetVals(TreeNode? node, List<int> vals)
        {
            if (node == null) return;
            vals.Add(node.val);
            GetVals(node.left, vals);
            GetVals(node.right, vals);
        }

        public static TreeNode GenerateAVLTree(List<int> vals)
        {
            vals.Sort();
            int left = 0;
            int right = vals.Count - 1;
            int pointer = right / 2;
            TreeNode root = new TreeNode(vals[pointer]);
            AddNode(root, left, right, pointer, vals);
            return root;
        }

        public static void AddNode(TreeNode parent, int left, int right, int pointer, List<int> vals)
        {
            if (pointer != left)
            {
                int lLeft = left;
                int lRight = pointer - 1;
                int lPointer = lRight - ((lRight - lLeft) / 2);
                TreeNode leftNode = new TreeNode(vals[lPointer]);
                parent.left = leftNode;
                if (lLeft != lPointer)
                    AddNode(leftNode, lLeft, lRight, lPointer, vals);
            }

            if (pointer != right)
            {
                int rLeft = pointer + 1;
                int rRight = right;
                int rPointer = rLeft + ((rRight - rLeft) / 2);
                TreeNode rightNode = new TreeNode(vals[rPointer]);
                parent.right = rightNode;
                if (rRight != rPointer)
                    AddNode(rightNode, rLeft, rRight, rPointer, vals);
            }
        }

        public static void FixAfterPut(ref TreeNode node, TreeNode? parent)
        {
            int leftHeight = GetHeight(node.left);
            int rightHeight = GetHeight(node.right);

            if (Math.Abs(leftHeight - rightHeight) <= 1)
            {
                if (node.left != null)
                    FixAfterPut(ref node.left, node);

                if (node.right != null)
                    FixAfterPut(ref node.right, node);
            }
            else
            {
                if (leftHeight < rightHeight)
                {
                    //判断是否为特殊右三">"子树,如果是将父节点右旋使其成为一个标准右三子树
                    if (node.right.right == null)
                    {
                        RightRotate(ref node.right!, node);
                    }
                    LeftRotate(ref node, parent);
                }
                else
                {
                    //判断是否为特殊左三"<"子树,如果是将父节点左旋使其成为一个标准左三子树
                    if (node.left.left == null)
                    {
                        LeftRotate(ref node.left!, node);
                    }
                    RightRotate(ref node, parent);
                }

                FixAfterPut(ref node, parent);
            }
        }

        public static void FixAfterPut2(ref TreeNode node, TreeNode? parent)
        {
            var flag = GetHeightFlag(node);

            if (flag == null)
            {
                if (node.left != null)
                    FixAfterPut2(ref node.left, node);

                if (node.right != null)
                    FixAfterPut2(ref node.right, node);
            }
            else
            {
                if (flag == true)
                {
                    //判断是否为特殊右三">"子树,如果是将父节点右旋使其成为一个标准右三子树
                    if (node.right.right == null)
                    {
                        RightRotate(ref node.right!, node);
                    }
                    LeftRotate(ref node, parent);
                }
                else
                {
                    //判断是否为特殊左三"<"子树,如果是将父节点左旋使其成为一个标准左三子树
                    if (node.left.left == null)
                    {
                        LeftRotate(ref node.left!, node);
                    }
                    RightRotate(ref node, parent);
                }

                FixAfterPut2(ref node, parent);
            }
        }

        public static int FixAfterPut3(ref TreeNode node, TreeNode? parent, int level)
        {
            level++;
            int leftBottom = level, rightBottom = level;
            if (node.left != null)
                leftBottom = FixAfterPut3(ref node.left, node, level);

            if (node.right != null)
                rightBottom = FixAfterPut3(ref node.right, node, level);

            int leftHeight = leftBottom - level;
            int rightHeight = rightBottom - level;

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                if (leftHeight < rightHeight)
                {
                    //判断是否为特殊右三">"子树,如果是将父节点右旋使其成为一个标准右三子树
                    if (node.right.right == null)
                    {
                        RightRotate(ref node.right!, node);
                    }
                    LeftRotate(ref node, parent);
                }
                else
                {
                    //判断是否为特殊左三"<"子树,如果是将父节点左旋使其成为一个标准左三子树
                    if (node.left.left == null)
                    {
                        LeftRotate(ref node.left!, node);
                    }
                    RightRotate(ref node, parent);
                }
            }

            return Math.Max(leftBottom, rightBottom);
        }

        private static void LeftRotate(ref TreeNode node, TreeNode? parent)
        {
            bool isLeftChild = parent != null && parent.left == node;

            //确定左旋节点
            TreeNode leftRotateNode = node;
            //上升节点
            node = node.right!;

            //继承父节点
            if (parent != null)
            {
                if (isLeftChild)
                    parent.left = node;
                else
                    parent.right = node;
            }

            //桥接
            leftRotateNode.right = node.left;
            node.left = leftRotateNode;
        }

        private static void RightRotate(ref TreeNode node, TreeNode? parent)
        {
            bool isLeftChild = parent != null && parent.left == node;

            //确定左旋节点
            TreeNode rightRotateNode = node;
            //上升节点
            node = node.left!;

            //继承父节点
            if (parent != null)
            {
                if (isLeftChild)
                    parent.left = node;
                else
                    parent.right = node;
            }

            //桥接
            rightRotateNode.left = node.right;
            node.right = rightRotateNode;
        }

        public static int GetHeight(TreeNode? node)
        {
            if (node == null) return 0;
            return Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
        }

        public static bool? GetHeightFlag(TreeNode node)
        {
            if (node.left == null)
            {
                var right = node.right;
                if (right != null && (right.left != null || right.right != null))
                {
                    return true;
                }
            }
            else if (node.right == null)
            {
                var left = node.left;
                if (left != null && (left.left != null || left.right != null))
                {
                    return false;
                }
            }

            return null;
        }
    }
}