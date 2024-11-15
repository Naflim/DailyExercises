using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 342. 4的幂
    /// </summary>
    internal class IsPowerOfFour
    {
        public static bool Run(int n)
        {
            int lead = int.LeadingZeroCount(n);
            int trail = int.TrailingZeroCount(n);
            return lead + trail == 31 && trail % 2 == 0;
        }
    }
}
