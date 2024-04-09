using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2529. 正整数和负整数的最大计数
    /// </summary>
    internal class MaximumCount
    {
        public static int Run(int[] nums)
        {
            int positiveCount = 0, negativeCount = 0;

            foreach (int num in nums)
            {
                if (num > 0)
                    positiveCount++;
                else if (num < 0)
                    negativeCount++;
            }

            return Math.Max(positiveCount, negativeCount);
        }
    }
}
