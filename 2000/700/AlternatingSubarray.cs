using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises._2000._700
{
    /// <summary>
    /// 2765. 最长交替子数组
    /// </summary>
    internal class AlternatingSubarray
    {
        public static int Run(int[] nums)
        {
            if (nums.Length <= 1)
                return -1;

            int result = 0;
            int count = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (count % 2 == 0)
                {
                    if (nums[i] -  nums[i - 1] == 1)
                    {
                        count++;
                    }
                    else
                    {
                        result = Math.Max(result, count);
                        count = 0;
                    }

                }
                else
                {
                    if (nums[i] -  nums[i - 1] == -1)
                    {
                        count++;
                    }
                    else
                    {
                        result = Math.Max(result, count);
                        if (nums[i] -  nums[i - 1] == 1)
                            count = 1;
                        else
                            count = 0;
                    }
                }
            }

            result = Math.Max(result, count);

            if (result == 0)
                return -1;
            else
                return result + 1;
        }
    }
}
