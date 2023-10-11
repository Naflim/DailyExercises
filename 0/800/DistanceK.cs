using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 863. 二叉树中所有距离为 K 的结点
    /// </summary>
    internal class DistanceK
    {
        public static IList<int> Run(TreeNode root, TreeNode target, int k)
        {
            var list = GetAdjacencyList(root);
            HashSet<TreeNode> visited = new HashSet<TreeNode>(new TreeNodeEqualityCompare());
            List<TreeNode> result = new List<TreeNode> { target };

            for (int i = 0; i < k; i++)
            {
                List<TreeNode> newResult = new List<TreeNode>();
                foreach (TreeNode node in result) 
                {
                    visited.Add(node);
                    newResult.AddRange(list[node].Where(n => !visited.Contains(n)));
                }

                result = newResult;

                if(result.Count == 0)
                    break;
            }

            return result.Select(v => v.val).ToList();
        }

        public static Dictionary<TreeNode,List<TreeNode>> GetAdjacencyList(TreeNode root) 
        {
            Dictionary<TreeNode, List<TreeNode>> list = new Dictionary<TreeNode, List<TreeNode>>(new TreeNodeEqualityCompare())
            {
                { root, new List<TreeNode>() }
            };

            DFS(list, root);

            return list;
        }

        private static void DFS(Dictionary<TreeNode, List<TreeNode>> list,TreeNode node)
        {
            if(node.left != null)
            {
                var left = node.left;
                list[node].Add(left);
                if(!list.ContainsKey(left))
                    list[left] = new List<TreeNode>();
                list[left].Add(node);
                DFS(list, node.left);
            }

            if(node.right != null) 
            {
                var right = node.right;
                list[node].Add(right);
                if (!list.ContainsKey(right))
                    list[right] = new List<TreeNode>();
                list[right].Add(node);
                DFS(list, node.right);
            }
        }
    }
}
