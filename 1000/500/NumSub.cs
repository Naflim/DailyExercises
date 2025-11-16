using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1513. 仅含 1 的子串数
    /// </summary>
    internal class NumSub
    {
        public static int Run(string s)
        {
            int mod = 0x3b9aca07;
            long count = 0;
            long result = 0;

            foreach (var c in s)
            {
                if (c == '1')
                {
                    count++;
                }
                else
                {
                    if(count > 0)
                    {
                        result = (result + (count * (count + 1)) / 2) % mod;
                        count = 0;
                    }
                }
            }

            if (count > 0)
            {
                result = (result + (count * (count + 1)) / 2) % mod;
            }

            return (int)result;
        }
    }
}
