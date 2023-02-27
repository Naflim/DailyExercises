using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1144. 递减元素使数组呈锯齿状
    /// </summary>
    internal class MovesToMakeZigzag
    {
        public static int Run(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int odd = 0, even = 0;

            if (nums[0] >= nums[1]) odd += nums[0] - nums[1] + 1;
            if (nums.Length % 2 == 0)
            {
                if (nums[^1] >= nums[^2]) even += nums[^1] - nums[^2] + 1;
            }
            else
            {
                if (nums[^1] >= nums[^2]) odd += nums[^1] - nums[^2] + 1;
            }

            for (int i = 1; i < nums.Length - 1; i++)
            {
                int[] section = new int[] { nums[i-1], nums[i], nums[i+1] };
                Array.Sort(section);

                if (nums[i] == section[1] || nums[i] == section[2])
                {
                    if (i % 2 == 1)
                    {
                        even += nums[i] - section[0] + 1;
                    }
                    else
                    {
                        odd += nums[i] - section[0] + 1;
                    }
                }
            }

            return Math.Min(odd, even);
        }
    }
}
