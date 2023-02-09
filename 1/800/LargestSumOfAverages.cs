using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 813. 最大平均值和的分组
    /// </summary>
    internal class LargestSumOfAverages
    {
        public static double Run(int[] nums, int k)
        {
            int n = nums.Length;
            double[] sums = new double[n];
            sums[0] = nums[0];
            for (int i = 1; i < n; i++)
            {
                sums[i] = sums[i - 1] + nums[i];
            }

            double[,] dp = new double[k, nums.Length];
            for (int i = 0; i<nums.Length; i++)
            {
                dp[0, i] = sums[i]/(i + 1);
            }

            for (int i = 1; i<k; i++)
            {
                for (int j = 0; j<nums.Length; j++)
                {
                    if (j<i) dp[i, j] = 0;
                    else
                    {
                        double[] buffer = new double[j - i + 1];
                        for (int x = 0; x < buffer.Length; x++)
                        {
                            buffer[x] = dp[i-1, j-1-x] + (sums[j] - sums[j - x - 1])/(x + 1);
                        }

                        dp[i, j] = buffer.Max();
                    }
                }
            }

            return dp[k-1, n - 1];
        }
    }
}
