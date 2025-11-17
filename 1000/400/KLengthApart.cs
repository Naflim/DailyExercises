using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1437. 是否所有 1 都至少相隔 k 个元素
    /// </summary>
    internal class KLengthApart
    {
        public static bool Run(int[] nums, int k)
        {
            int start = Array.IndexOf(nums, 1);
            int count = 0;
            for (int i = start + 1; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    count++;
                }
                else
                {
                    if (count >= k)
                        count = 0;
                    else
                        return false;
                }
            }

            return true;
        }
    }
}
