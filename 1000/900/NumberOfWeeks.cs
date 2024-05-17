using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1953. 你可以工作的最大周数
    /// </summary>
    internal class NumberOfWeeks
    {
        public static long Run(int[] milestones)
        {
            long sum = 0;
            int max = int.MinValue;

            foreach(var num in milestones)
            {
                sum += num;
                max = Math.Max(max, num);
            }

            long diff = sum - max;

            if (diff < max)
                return diff * 2 + 1;
            else
                return sum;
        }
    }
}
    