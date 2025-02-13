using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 477. 汉明距离总和
    /// </summary>
    internal class TotalHammingDistance
    {
        public static int Run(int[] nums)
        {
            int result = 0;

            for (int i = 0; i < 32; i++)
            {
                int mask = 1 << i;

                int zeroCount = 0;
                int oneCount = 0;

                foreach (var num in nums)
                {
                    if ((num & mask) == 0)
                    {
                        zeroCount++;
                    }
                    else
                    {
                        oneCount++;
                    }
                }

                result += zeroCount * oneCount;
            }

            return result;
        }
    }
}
