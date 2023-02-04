using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1798. 你能构造出连续值的最大数目
    /// </summary>
    internal class GetMaximumConsecutive
    {
        public static int Run(int[] coins)
        {
            int res = 1;
            Array.Sort(coins);
            foreach (int i in coins)
            {
                if (i > res)
                {
                    break;
                }
                res += i;
            }
            return res;
        }
    }
}
