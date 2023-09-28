using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 918. 环形子数组的最大和
    /// </summary>
    internal class MaxSubarraySumCircular
    {
        public static int Run(int[] nums)
        {
            int len = nums.Length;
            if (len == 1) return nums[0];

            int[][] dp = new int[len - 1][];
            dp[0] = new int[len];
            Array.Copy(nums, dp[0], len);

            int max = dp[0].Max();
            for (int i = 1; i < len - 1; i++)
            {
                dp[i] = new int[len];
                for (int j = 0; j < len; j++)
                {
                    int index = j + i;
                    if (index >= len)
                        index -= len;

                    dp[i][j] = dp[i - 1][j] + nums[index];
                }
                max = Math.Max(max, dp[i].Max());
            }

            return Math.Max(max, nums.Sum());
        }

        public static int Run2(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            if (!nums.Any(n => n < 0))
                return nums.Sum();

            if (!nums.Any(n => n > 0))
                return nums.Max();

            var kadane = GetKadane4Max(nums);

            int maximumLoss = 0;
            int maximumLossIndex = -1;
            int lossCache = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]  > 0)
                {
                    lossCache  = 0;
                }
                else
                {
                    lossCache += nums[i];
                    if (lossCache < maximumLoss)
                    {
                        maximumLoss = lossCache;
                        maximumLossIndex = i;
                    }
                }
            }

            var dp = GetKadane4Max(nums);
            if (maximumLossIndex == 0)
                return dp[1..].Max();

            if (maximumLossIndex == nums.Length - 1)
                return dp[..^1].Max();

            var lastDp = GetKadane4Max(nums[(maximumLossIndex + 1)..]);
            int[] firstDp = new int[maximumLossIndex];
            firstDp[0] = nums[0];
            for (int i = 1; i < firstDp.Length; i++)
            {
                firstDp[i] = firstDp[i - 1] + nums[i];
            }

            return Math.Max(dp.Max(), lastDp[^1] + firstDp.Max());
        }

        public static int Run3(int[] nums)
        {
            int maxVal = nums.Max();
            if(maxVal < 0)
                return maxVal;

            var max = GetKadane4Max(nums);
            var min = GetKadane4Min(nums);

            return Math.Max(max.Max(), nums.Sum() - min.Min());
        }

        public static int[] GetKadane4Max(IList<int> nums)
        {
            int len = nums.Count;
            int[] dp = new int[len];
            dp[0] = nums[0];
            for (int i = 1; i < len; i++)
            {
                dp[i] = dp[i - 1] > 0 ? dp[i - 1] + nums[i] : nums[i];
            }

            return dp;
        }

        public static int[] GetKadane4Min(IList<int> nums)
        {
            int len = nums.Count;
            int[] dp = new int[len];
            dp[0] = nums[0];
            for (int i = 1; i < len; i++)
            {
                dp[i] = dp[i - 1] < 0 ? dp[i - 1] + nums[i] : nums[i];
            }

            return dp;
        }
    }
}
