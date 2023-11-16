using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2760. 最长奇偶子数组
    /// </summary>
    internal class LongestAlternatingSubarray
    {
        public static int Run(int[] nums, int threshold)
        {
            int result = 0;
            int left = nums[0] % 2 == 0 && threshold >= nums[0] ? 1 : 0;
            
            for (int i = 1; i < nums.Length; i++)
            {
                var prev = nums[i - 1];
                var now = nums[i];
                if(left == 0)
                {
                    if (now % 2 == 0 && threshold >= now)
                    {
                        left = 1;
                    }
                }
                else
                {
                    if (prev % 2 != now % 2 && threshold >= now)
                    {
                        left++;
                    }
                    else
                    {
                        result = Math.Max(result, left);
                        left = now % 2 == 0 && threshold >= now ? 1 : 0;
                    }
                }
            }

            result = Math.Max(result, left);
            return result;
        }
    }
}
