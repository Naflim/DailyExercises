using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1758. 生成交替二进制字符串的最少操作数
    /// </summary>
    internal class MinOperations
    {
        public static int Run(string s)
        {
            int countA = 0, countB = 0;
            for(int i=0;i<s.Length;i++) 
            {
                if ((i%2==0 && s[i] == '0') || (i%2==1 && s[i] == '1'))countA++;
            }
            for (int i = 0; i<s.Length; i++)
            {
                if ((i%2==0 && s[i] == '1') || (i%2==1 && s[i] == '0')) countB++;
            }

            return Math.Min(countA, countB);
        }
    }
}
