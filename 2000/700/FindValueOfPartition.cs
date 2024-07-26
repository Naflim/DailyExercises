using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2740. 找出分区值
    /// </summary>
    internal class FindValueOfPartition
    {
        public static int Run(int[] nums)
        {
            int result = int.MaxValue;

            Array.Sort(nums);

            for (int i = 1; i < nums.Length; i++)
            {
                int prev = nums[i - 1];
                int now = nums[i];

                result = Math.Min(result, Math.Abs(prev - now));
            }

            return result;
        }
    }
}
