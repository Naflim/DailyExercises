using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 91. 解码方法
    /// </summary>
    internal class NumDecodings
    {
        public static int Run(string s)
        {
            if (s[0] == '0') return 0;
            if (s.Length == 1) return 1;

            int[] nums = s.Select(c => c - 48).ToArray();

            int[] dp = new int[s.Length];
            dp[0] = 1;
            if (nums[0] * 10 + nums[1] <= 26)
                dp[1] = 1;

            if (s[1] != '0')
                dp[1]++;

            for (int i = 2; i < dp.Length; i++) 
            {
                if (s[i] != '0')
                    dp[i] += dp[i - 1];

                if (s[i-1] != '0' && nums[i - 1] * 10 + nums[i] <= 26)
                    dp[i] += dp[i - 2];
            }

            return dp[^1];
        }
    }
}
