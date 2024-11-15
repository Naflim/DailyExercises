using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 338. 比特位计数
    /// </summary>
    internal class CountBits
    {
        public static int[] Run(int n)
        {
            int len = n + 1;
            int[] result = new int[len];

            for (int i = 0; i < len; i++) 
            {
                int jLen = 32 - int.LeadingZeroCount(i);

                int num = 0;
                for (int j = 0; j < jLen; j++)
                {
                    int mask = 1 << j;
                    if((i & mask) != 0)
                        num++;
                }

                result[i] = num;
            }

            return result;
        }

        public static int[] Run2(int n) 
        {
            int len = n + 1;
            int[] result = new int[len];

            for (int i = 1; i < len; i++)
            {
                result[i] = result[i >> 1] + i % 2;
            }

            return result;
        }
    }
}
