using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2413. 最小偶倍数
    /// </summary>
    public class SmallestEvenMultiple
    {
        public static int Run(int n)
        {
            return n % 2 == 0 ? n : n * 2;
        }
    }
}
