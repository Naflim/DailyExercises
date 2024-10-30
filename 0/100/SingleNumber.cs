using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 136. 只出现一次的数字
    /// </summary>
    class SingleNumber
    {
        public static int Run(int[] nums)
        {
            string positive = string.Empty, negative = string.Empty;

            foreach (int x in nums)
            {
                if (x < 0)
                {
                    string mark = BitwiseOperationUtils.GetMask(-x);
                    negative = BitwiseOperationUtils.XOR(negative, mark);
                }
                else
                {
                    string mark = BitwiseOperationUtils.GetMask(x);
                    positive = BitwiseOperationUtils.XOR(positive, mark);
                }
            }

            if (positive.Contains('1'))
            {
                var result = positive.ToGather();
                return result.First();
            }
            else
            {
                var result = negative.ToGather();
                return -result.First();
            }
        }

        public static int Run2(int[] nums)
        {
            int num = 0;

            foreach (int x in nums)
            {
                num ^= x;
            }

            return num;
        }
    }
}
