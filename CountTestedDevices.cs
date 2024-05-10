using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2960. 统计已测试设备
    /// </summary>
    internal class CountTestedDevices
    {
        public static int Run(int[] batteryPercentages)
        {
            int result = 0;
            for (int i = 0; i < batteryPercentages.Length; i++)
            {
                if (batteryPercentages[i] - result > 0)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
