using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2455. 可被三整除的偶数的平均值
    /// </summary>
    internal class AverageValue
    {
        public static int Run(int[] nums)
        {
            int[] filter = nums.Where(n => n % 2 == 0 && n % 3 == 0).ToArray();

            if(filter.Length == 0) return 0;
            return filter.Sum() / filter.Length;
        }
    }
}
