using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2651. 计算列车到站时间
    /// </summary>
    internal class FindDelayedArrivalTime
    {
        public static int Run(int arrivalTime, int delayedTime)
        {
            var result = arrivalTime + delayedTime;
            if(result >= 24)
                result -= 24;

            return result;
        }
    }
}
