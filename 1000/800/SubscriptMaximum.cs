using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1802. 有界数组中指定下标处的最大值
    /// </summary>
    internal class SubscriptMaximum
    {
        public static int Run(int n, int index, int maxSum)
        {
            ulong left = 1; ulong right = (ulong)(maxSum - n + 1);

            int result = (int)left;
            while (left <= right)
            {
                ulong average = (ulong)(left + right) / 2;

                ulong remainderLeft = index > 0 ? GetRemainder((uint)index, average - 1) : 0;
                ulong remainderRight = n - 1 > index ? GetRemainder((uint)(n - index - 1), average - 1) : 0;
                if (remainderLeft + remainderRight + average > (uint)maxSum) right = average - 1;
                else
                {
                    result = (int)average;
                    left = average + 1;
                }
            }

            return result;
        }

        /// <summary>
        /// 获取最小和
        /// </summary>
        /// <param name="count">数组个数</param>
        /// <param name="max">最大值</param>
        /// <returns>最小和</returns>
        public static ulong GetRemainder(uint count, ulong max)
        {
            if (max > count) return count * (max - count + 1 + max) / 2;
            else return max * (max + 1) / 2 + count - max;
        }
    }
}
