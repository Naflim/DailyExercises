using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 231. 2 的幂
    /// </summary>
    internal class IsPowerOfTwo
    {
        public static bool Run(int n)
        {
            if (n <= 0) return false;
            return 32 - int.LeadingZeroCount(n) - int.TrailingZeroCount(n) == 1;
        }
    }
}
