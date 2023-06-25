using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1312. 让字符串成为回文串的最少插入次数
    /// </summary>
    internal class MinInsertions
    {
        public static int Run(string s)
        {
            return s.Length - LongestPalindromeSubseq.Run(s);
        }
    }
}