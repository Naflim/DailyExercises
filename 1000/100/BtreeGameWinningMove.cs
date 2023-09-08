using DailyExercises.Helper.Graph;
using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DailyExercises
{
    /// <summary>
    /// 1145. 二叉树着色游戏
    /// </summary>
    internal class BtreeGameWinningMove
    {
        public static bool Run(TreeNode root, int n, int x)
        {
            TreeNodeAsVertex vertex = new(root);

            if (vertex.GetTargetNode(x) is not TreeNodeAsVertex xVertex) return false;

            List<int> paths = new List<int>();

            int[] nextVal = xVertex.NextVertex.Select(v => v.GetValue()).ToArray();

            foreach (int val in nextVal)
            {
                paths.Add(xVertex.DFS(new HashSet<int>(nextVal.Where(v => v!=val))).Count - 1);
            }

            if (paths.Count == 1) return true;
            else 
            {
                int max = paths.Max();
                paths.Remove(max);
                return max > paths.Sum();
            }
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class TreeNodeAsVertex : TreeNode, IVertex<int>
    {

        private readonly List<TreeNodeAsVertex> _nextVertex;

        public IVertex<int>[] NextVertex
        {
            get { return _nextVertex.ToArray(); }
        }

        public int GetValue()
        {
            return val;
        }

        public TreeNodeAsVertex(TreeNodeAsVertex parentNode, TreeNode node)
        {
            _nextVertex = new() { parentNode };
            val = node.val;
            left = node.left;
            right = node.right;
            if (node.left != null) _nextVertex.Add(new TreeNodeAsVertex(this, node.left));
            if (node.right != null) _nextVertex.Add(new TreeNodeAsVertex(this, node.right));
        }

        public TreeNodeAsVertex(TreeNode root)
        {
            _nextVertex = new();
            val = root.val;
            left = root.left;
            right = root.right;
            if (root.left != null) _nextVertex.Add(new TreeNodeAsVertex(this, root.left));
            if (root.right != null) _nextVertex.Add(new TreeNodeAsVertex(this, root.right));
        }

        public TreeNodeAsVertex? GetTargetNode(int target)
        {
            return GetTargetNode(this, new HashSet<TreeNodeAsVertex>(), target);
        }

        public static TreeNodeAsVertex? GetTargetNode(TreeNodeAsVertex? node, HashSet<TreeNodeAsVertex> hashSet, int target)
        {
            if (node == null) return null;

            hashSet.Add(node);
            if (node.val == target) return node;
            else
            {
                foreach (var next in node._nextVertex)
                {
                    if (hashSet.Contains(next)) continue;
                    if (GetTargetNode(next, hashSet, target) is TreeNodeAsVertex targetNode) return targetNode;
                }
            }

            return null;
        }
    }
}
