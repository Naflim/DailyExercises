using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 461. 汉明距离
    /// </summary>
    internal class HammingDistance
    {
        public static int Run(int x, int y)
        {
            int result = 0;
            for (int i = 0; i < 32; i++)
            {
                int mask = 1 << i;
                if((x & mask) != (y & mask))
                {
                    result++;
                }
            }

            return result;
        }
    }
}
