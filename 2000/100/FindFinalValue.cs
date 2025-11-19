using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2154. 将找到的值乘以 2
    /// </summary>
    internal class FindFinalValue
    {
        public static int Run(int[] nums, int original)
        {
            HashSet<int> result = new HashSet<int>(nums);

            while (result.Contains(original))
            {
                original *= 2;
            }

            return original;
        }
    }
}
