using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 337. 打家劫舍 III
    /// </summary>
    internal class Rob3
    {
        public static int Run(TreeNode root)
        {
            List<int> route1 = new List<int>();
            List<int> route2 = new List<int>();
            DFS(route1, route2, true, root);
            return Math.Max(route1.Sum(), route2.Sum());
        }

        public static int Run2(TreeNode root)
        {
            List<int> rows = new List<int>();
            BFS(rows,new TreeNode[] { root });
            int[] dp = new int[rows.Count];
            for (int i = 0; i < dp.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        dp[0] = rows[0];
                        break;
                        case 1:
                        dp[1] = rows[1];
                        break;
                    case 2:
                        dp[2] = rows[0] + rows[2];
                        break;
                    default:
                        dp[i] = Math.Max(dp[i - 2] + rows[i], dp[i - 3] + rows[i]);
                        break;
                }
            }

            return dp.Max();
        }

        public static int Run3(TreeNode root)
        {
            var maximumBenefit = GetMaximumBenefit(root);
            return Math.Max(maximumBenefit.sel, maximumBenefit.unsel);
        }

        /// <summary>
        /// 获取最大利益
        /// </summary>
        /// <param name="root">根节点</param>
        /// <returns>选中节点与不选节点的最大利益</returns>
        public static (int sel,int unsel) GetMaximumBenefit(TreeNode root)
        {
            (int sel, int unsel) leftInterest = (0, 0);

            if (root.left != null)
                leftInterest = GetMaximumBenefit(root.left);

            (int sel, int unsel) rightInterest = (0, 0);
            if (root.right != null)
                rightInterest = GetMaximumBenefit(root.right);

            int selInterest = root.val + leftInterest.unsel + rightInterest.unsel;
            int unselInterest = Math.Max(leftInterest.sel, leftInterest.unsel) + Math.Max(rightInterest.sel, rightInterest.unsel);

            return (selInterest, unselInterest);
        }

        public static void DFS(IList<int> route1, IList<int> route2, bool isRoute1, TreeNode node)
        {
            if (isRoute1)
                route1.Add(node.val);
            else
                route2.Add(node.val);

            if (node.left != null)
                DFS(route1, route2, !isRoute1, node.left);

            if (node.right != null)
                DFS(route1, route2, !isRoute1, node.right);
        }

        public static void BFS(IList<int> rows, IEnumerable<TreeNode> nodes)
        {
            int row = 0;
            List<TreeNode> nextNodes = new List<TreeNode>();
            foreach (TreeNode node in nodes)
            {
                row += node.val;
                if (node.left != null)
                    nextNodes.Add(node.left);

                if(node.right != null)
                    nextNodes.Add(node.right);
            }

            rows.Add(row);
            if(nextNodes.Count > 0)
                BFS(rows, nextNodes);
        }
    }
}
