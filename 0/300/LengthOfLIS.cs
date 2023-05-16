using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 300. 最长递增子序列
    /// </summary>
    internal class LengthOfLIS
    {
        public static int Run(int[] nums)
        {
            int result = 1;
            SortedDictionary<int, int> dic = new SortedDictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                result = Math.Max(result, AddDPList(dic, nums[i]));
            }

            return result;
        }

        public int lengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int maxans = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                maxans = Math.Max(maxans, dp[i]);
            }
            return maxans;
        }

        public static int AddDPList(SortedDictionary<int, int> dic, int num)
        {
            dic[num] = 0;

            int max = 0;
            foreach(var item in dic)
            {
                if (item.Key == num)
                    break;

                max = Math.Max(max, item.Value);
            }


            dic[num] =  max + 1;
            return dic[num];
        }

    }
}