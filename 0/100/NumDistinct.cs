using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 115. 不同的子序列
    /// </summary>
    internal class NumDistinct
    {
        public static int Run(string s, string t)
        {
            int sLen = s.Length;
            int tLen = t.Length;

            if (tLen > sLen) return 0;
            if (tLen == sLen) return s == t ? 1 : 0;

            int count = 0;

            int[,] dp = new int[tLen, sLen];
            for (int i = 0; i < sLen; i++)
            {
                if (s[i] == t[0]) count++;
                dp[0, i] = count;
            }

            count = 0;
            for (int i = 0; i<tLen; i++)
            {
                if (s[0] == t[i]) count++;
                dp[i, 0] = count;
            }

            for (int i = 1; i<tLen; i++)
            {
                for (int j = 1; j < sLen; j++)
                {
                    if (i > j)
                    {
                        if (t[i] == s[j])
                        {
                            dp[i, j] = dp[i - 1, j] + dp[i - 1, j - 1];
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                    else if (i < j)
                    {
                        if (t[i] == s[j])
                        {
                            dp[i, j] = dp[i, j - 1] + dp[i - 1, j - 1];
                        }
                        else
                        {
                            dp[i, j] = dp[i, j - 1];
                        }
                    }
                    else
                    {
                        dp[i, j] = s[..(j + 1)] == t[..(i + 1)] ? 1 : 0;
                    }
                }
            }

            return dp[tLen - 1, sLen - 1];
        }
    }
}
