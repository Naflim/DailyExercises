using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1785. 构成特定和需要添加的最少元素
    /// </summary>
    internal class MinElements
    {
        public static int Run(int[] nums, int limit, int goal)
        {
            double differ = Math.Abs(goal - Sum(nums));
  
            return differ > 0 ? (int)Math.Ceiling(differ / limit) : (int)Math.Floor(differ / limit);
        }

        public static double Sum(int[] nums)
        {
            double sum = 0; 
            for(int i=0;i< nums.Length;i++) 
            {
                sum += nums[i];
            }
            return sum;
        }
    }
}
