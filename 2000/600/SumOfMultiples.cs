using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2652. 倍数求和
    /// </summary>
    internal class SumOfMultiples
    {
        public static int Run(int n)
        {
            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                if(i % 3 == 0 || i % 5 == 0 || i % 7 == 0)
                    result += i;
            }

            return result;
        }
    }
}
