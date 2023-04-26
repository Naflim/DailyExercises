using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1031. 两个非重叠子数组的最大和
    /// </summary>
    internal class MaxSumTwoNoOverlap
    {
        public static int Run(int[] nums, int firstLen, int secondLen)
        {
            int lLen = firstLen, sLen = secondLen;
            if (secondLen > firstLen) (lLen, sLen) = (sLen, lLen);

            int[] prefixSum = new int[nums.Length];
            prefixSum[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i];
            }

            int[] dp = new int[nums.Length - sLen + 1];
            dp[0] = prefixSum[sLen - 1];
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = prefixSum[i + sLen - 1] - prefixSum[i - 1];
            }

            int[] result = new int[nums.Length - lLen + 1];
            for (int i = 0; i < nums.Length - lLen + 1; i++)
            {
                int lCount = i - sLen;
                int rStart = i + lLen;
                int rCount = nums.Length - rStart - sLen + 1;

                int lSum = i == 0 ? prefixSum[lLen - 1] : prefixSum[i + lLen - 1] - prefixSum[i - 1];
                for (int j = 0; j < lCount; j++)
                {
                    result[i] = Math.Max(result[i], lSum + dp[j]);
                }

                for (int j = 0; j < rCount; j++)
                {
                    result[i] = Math.Max(result[i], lSum + dp[j + rStart]);
                }
            }

            return result.Max();
        }
    }
}
