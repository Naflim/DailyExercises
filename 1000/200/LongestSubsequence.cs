
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1218. 最长定差子序列
    /// </summary>
    internal class LongestSubsequence
    {
        public static int Run(int[] arr, int difference)
        {
            int[] dp = new int[arr.Length];
            Array.Fill(dp, 1);

            for (int i = 1; i < arr.Length; i++) 
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] + difference == arr[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                    else
                    {
                        dp[i] = Math.Max(dp[i], dp[j]);
                    }
                }
            }

            return dp[^1];
        }

        public static int Run2(int[] arr, int difference)
        {
            Dictionary<int,int> dp = new Dictionary<int,int>();
            foreach (int v in arr) 
            {
                int prve = dp.ContainsKey(v - difference) ? dp[v - difference] : 0;
                dp[v] = prve + 1;
            }

            return dp.Values.Max();
        }
    }
}