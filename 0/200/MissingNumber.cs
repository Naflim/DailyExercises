using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 268. 丢失的数字
    /// </summary>
    internal class MissingNumber
    {
        public static int Run(int[] nums)
        {
            Array.Sort(nums);

            if (nums[0] != 0)
                return 0;

            int index = nums.Length - 2;

            if (index < 0 || nums[index] == index)
            {
                return nums[index + 1] == index + 1 ? nums.Length : nums.Length - 1;
            }

            int left = 0;
            int right = nums.Length - 1;

            while (left + 1 < right)
            {
                int pointer = (left + right) / 2;
                if (nums[pointer] == pointer)
                    left = pointer;
                else
                    right = pointer;
            }

            return right;
        }
    }
}
