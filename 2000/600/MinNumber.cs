using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2605. 从两个数字数组里生成最小数字
    /// </summary>
    internal class MinNumber
    {
        public static int Run(int[] nums1, int[] nums2)
        {
            var intersect = nums1.Intersect(nums2).ToArray();

            if (intersect.Length > 0)
                return intersect.Min();

            int min1 = nums1.Min();
            int min2 = nums2.Min();

            if (min1 < min2)
                return min1 * 10 + min2;
            else
                return min2 * 10 + min1;
        }
    }
}
