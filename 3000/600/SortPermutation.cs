using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 3644. 排序排列
    /// </summary>
    internal class SortPermutation
    {
        public static int Run(int[] nums)
        {
            int len = nums.Length;
            int k = -1;
            for (int i = 0; i < len; i++)
            {
                if (nums[i] != i)
                {
                    k &= i;
                }
            }

            return Math.Max(0, k);
        }
    }
}
