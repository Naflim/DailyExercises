using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 190. 颠倒二进制位
    /// </summary>
    public class ReverseBits
    {
        public static uint Run(uint n)
        {
            for (int i = 0; i < 16; i++)
            {
                uint leftMask = (1u << 31 - i);
                uint rightMask = (1u << i);

                uint leftVal = ((n >> (31 - i)) & 1) << i;
                uint rightVal = ((n >> i) & 1) << (31 - i);

                n = n & ~leftMask & ~rightMask | leftVal | rightVal;
            }

            return n;
        }
    }
}
