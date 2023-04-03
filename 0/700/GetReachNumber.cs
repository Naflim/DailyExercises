using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 754. 到达终点数字
    /// </summary>
    internal class GetReachNumber
    {
        public static int ReachNumber(int target)
        {
            target = Math.Abs(target);
            int s = 0, n = 0;
            while (s < target || (s - target) % 2 != 0) // 没有到达（越过）终点，或者相距奇数
                s += ++n;
            return n;
        }
    }
}
