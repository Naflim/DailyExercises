using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2913. 子数组不同元素数目的平方和 I
    /// </summary>
    internal class SumCounts
    {
        public static int Run(IList<int> nums)
        {
            int result = 0;
            int len = nums.Count;

            for (int i = 0; i < len; i++)
            {
                HashSet<int> set = new HashSet<int>();
                int val = 0;
                for (int j = i; j < len; j++)
                {
                    if (!set.Contains(nums[j]))
                    {
                        set.Add(nums[j]);
                        val = set.Count * set.Count;
                    }

                    result += val;
                }
            }

            return result;
        }
    }
}
