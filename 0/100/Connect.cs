using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    /// <summary>
    /// 117. 填充每个节点的下一个右侧节点指针 II
    /// </summary>
    internal class Connect
    {
        public static Node? Run(Node? root)
        {
            if (root == null)
                return null;

            List<Node> row = new List<Node> { root };
            while (row.Count > 0) 
            {
                List<Node> newRow = new List<Node>();
                foreach (Node node in row) 
                {
                    if(node.left != null)
                        newRow.Add(node.left);

                    if(node.right != null)
                        newRow.Add(node.right);
                }

                for (int i = 0; i < newRow.Count - 1; i++)
                {
                    newRow[i].next = newRow[i + 1];
                }

                row = newRow;
            }

            return root;
        }
    }
}
