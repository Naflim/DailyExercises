using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2357. 使数组中所有元素都等于零
    /// </summary>
    internal class MinimumOperations
    {
        public static int Run(int[] nums)
        {
            return nums.Distinct().Where(n=>n!=0).Count();
        }
    }
}
