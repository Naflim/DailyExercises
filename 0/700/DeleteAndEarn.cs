using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 740. 删除并获得点数
    /// </summary>
    internal class DeleteAndEarn
    {
        public static int Run(int[] nums)
        {
            if(nums.Length == 0) return 0;
            

            SortedDictionary<int, int> dic = new SortedDictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i])) dic[nums[i]] += nums[i];
                else dic[nums[i]] = nums[i];
            }

            if (dic.Count == 1) return dic.Values.First();

            int[] dp = new int[dic.Count];
            dp[0] = dic.Values.First();
            int prev = dic.Keys.First();
            var cache = dic.ElementAt(1);
            if (prev + 1 == cache.Key)
            {
                if (cache.Value > dp[0])
                {
                    dp[1] = cache.Value;
                    prev = cache.Key;
                }
                else
                {
                    dp[1] = dp[0];
                }
            }
            else
            {
                dp[1] = dp[0] + cache.Value;
                prev = cache.Key;
            }

            for (int i = 2; i < dic.Count; i++)
            {
                var item = dic.ElementAt(i);
                if(prev + 1 == item.Key)
                {
                    if(dp[i-1] <  dp[i - 2] + item.Value)
                    {
                        dp[i] = dp[i - 2] + item.Value;
                        prev = item.Key;
                    }
                    else
                    {
                        dp[i] = dp[i - 1];
                    }
                }
                else
                {
                    dp[i] = dp[i-1] + item.Value;
                    prev = item.Key;
                }
            }
            return dp.Last();
        }
    }
}
