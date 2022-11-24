using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 704. 二分查找
    /// </summary>
    public class BinarySearch
    {
        public static int Search(int[] nums, int target)
        {
            if (target < nums[0] || target> nums[^1]) return -1;
            int left = -1;
            int right = nums.Length;

            while (left +1 != right)
            {
                int pointer = (left + right)/2;
                if (nums[pointer]>target) right = pointer;
                else if (nums[pointer]<target) left = pointer;
                else return pointer;
            }

            return -1;
        }
    }
}
