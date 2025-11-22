using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 3190. 使所有元素都可以被 3 整除的最少操作数
    /// </summary>
    internal class MinimumOperations3
    {
        public static int Run(int[] nums)
        {
            int result = 0;
            foreach (int num in nums)
            {
                if (num % 3 != 0)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
