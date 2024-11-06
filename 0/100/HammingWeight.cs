using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 191. 位1的个数
    /// </summary>
    internal class HammingWeight
    {
        public static int Run(int n)
        {
            return Convert.ToString(n, 2).Count(v => v == '1');
        }
    }
}
