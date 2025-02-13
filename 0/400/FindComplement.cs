using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 476. 数字的补数
    /// </summary>
    internal class FindComplement
    {
        public static int Run(int num)
        {
            uint uNum = (uint)num;

            uint len = uint.LeadingZeroCount(uNum);

            uNum = ~uNum;
            uNum <<= (int)len;
            uNum >>= (int)len;

            return (int)uNum;
        }
    }
}
