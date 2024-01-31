using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2670. 找出不同元素数目差数组
    /// </summary>
    internal class DistinctDifferenceArray
    {
        public static int[] Run(int[] nums)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>(nums);
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                left.Add(nums[i]);
                right.Remove(nums[i]);
                result[i] = left.Distinct().Count() - right.Distinct().Count();
            }

            return result;
        }
    }
}
