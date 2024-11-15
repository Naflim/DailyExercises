using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 389. 找不同
    /// </summary>
    internal class FindTheDifference
    {
        public static char Run(string s, string t)
        {
            int result = 0;

            foreach (char c in s) 
            {
                result ^= c;
            }

            foreach (char c in t)
            {
                result ^= c;
            }

            return (char)result;
        }
    }
}
