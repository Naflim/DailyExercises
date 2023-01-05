using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1803. 统计异或值在范围内的数对有多少
    /// </summary>
    internal class CountPairs
    {
        public static int Run(int[] nums, int low, int high)
        {
            Array.Sort(nums);
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for(int j = i+1; j<nums.Length; j++) 
                {
                    var xor = nums[i]^nums[j];
                    if (xor >= low && xor <= high) count++;
                }
            }

            return count;
        }
    }
}
