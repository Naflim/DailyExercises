using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 260. 只出现一次的数字 III
    /// </summary>
    internal class SingleNumber3
    {
        public static int[] Run(int[] nums)
        {
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if(result.Contains(num))
                    result.Remove(num);
                else
                    result.Add(num);
            }

            return result.ToArray();
        }
    }
}
