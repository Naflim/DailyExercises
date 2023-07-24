using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 124. 二叉树中的最大路径和
    /// </summary>
    internal class MaxPathSum
    {
        public static int Run(TreeNode root)
        {
            int result = int.MinValue;
            HashSet<int> values = new HashSet<int>();
            var val = GetMaxValue(root, values, ref result);
            if (values.Any(v => v >= 0))
                return result;
            else
                return values.Max();
        }

        public static (int, int) GetMaxValue(TreeNode root, HashSet<int> values, ref int maxValue)
        {
            int left = 0;
            if (root.left != null)
            {
                var leftVal = GetMaxValue(root.left, values, ref maxValue);
                var maxItem = Math.Max(leftVal.Item1, leftVal.Item2);
                if (maxItem > 0) left += maxItem;
                left += root.left.val;
                if (left < 0) left = 0;
            }

            int right = 0;
            if (root.right != null)
            {
                var rightVal = GetMaxValue(root.right, values, ref maxValue);
                var maxItem = Math.Max(rightVal.Item1, rightVal.Item2);
                if (maxItem > 0) right += maxItem;
                right += root.right.val;
                if (right < 0) right = 0;
            }

            values.Add(root.val);
            maxValue = Math.Max(maxValue, left + right + root.val);
            return (left, right);
        }
    }
}
