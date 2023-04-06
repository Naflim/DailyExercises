using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1017. 负二进制转换
    /// </summary>
    internal class BaseNeg2
    {
        public static string Run(int n)
        {
            if (n == 0) return "0";
            string bytecode = string.Empty;
            while (true)
            {
                if (n != 1)
                {
                    bytecode += Math.Abs(n % -2).ToString();
                    n = (int)Math.Ceiling((double)n / -2);
                }
                else 
                {
                    bytecode += Math.Abs(n).ToString();
                    break;
                }
            }

            return new string(bytecode.Reverse().ToArray());
        }
    }
}
