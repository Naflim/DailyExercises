﻿using System;
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

        }

        public static int[] GetKadane(IEnumerable<int> nums) 
        {
            var numArr = nums.ToArray();
            int[] dp = new int[numArr.Length];
            dp[0] = numArr[0];
            for (int i = 1; i < numArr.Length; i++)
            {
                dp[i] = dp[i - 1] > 0 ? dp[i - 1] + numArr[i] : numArr[i];
            }

            return dp;
        }
    }
}