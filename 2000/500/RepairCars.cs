using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2594. 修车的最少时间
    /// </summary>
    internal class RepairCars
    {
        public static long Run(int[] ranks, int cars)
        {
            long left = 0, right = (long)(ranks.Min() * Math.Pow(cars,2));

            while (left + 1 != right)
            {
                var pointer = (left + right) / 2;
                var repairCarCount = GetRepairCarCount(ranks, pointer);
                if (repairCarCount > cars) right = pointer;
                else if (repairCarCount < cars) left = pointer;
                else break;
            }

            var val = left + 1 == right ? right : (left + right) / 2;
            long result = 0;

            while (true)
            {
                var repairCarCount = GetRepairCarCount(ranks, val);
                if (repairCarCount >= cars)
                {
                    result = val;
                    val--;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public static long GetRepairCarCount(int[] ranks, long time)
        {
            long count = 0;

            foreach (var rank in ranks)
                count += (long)Math.Sqrt(time / rank);

            return count;
        }
    }
}
