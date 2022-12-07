using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1775. 通过最少操作次数使数组的和相等
    /// </summary>
    internal class MinOperationNumber
    {
        public static int Run(int[] nums1, int[] nums2)
        {
            List<int> big, small;
            if (nums1.Sum()>nums2.Sum())
            {
                big = nums1.ToList();
                small = nums2.ToList();
            }
            else if (nums1.Sum()<nums2.Sum())
            {
                big = nums2.ToList();
                small = nums1.ToList();
            }
            else return 0;

            List<int> operations = new List<int>();

            big.ForEach(v=>operations.Add(v - 1));
            small.ForEach(v=>operations.Add(6 - v));

            operations.Sort();
            operations.Reverse();

            int disparity = big.Sum() - small.Sum();

            int i = 0,count = 0;
            for (; i<operations.Count; i++)
            {
                count += operations[i];
                if (count >= disparity) break;
            }

            if (i == operations.Count) return -1;
            else return i + 1;
        }
    }
}
