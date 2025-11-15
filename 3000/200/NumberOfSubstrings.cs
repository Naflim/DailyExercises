using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 3234. 统计 1 显著的字符串的数量
    /// </summary>
    internal class NumberOfSubstrings
    {
        public static int Run(string s)
        {
            int len = s.Length;

            int[,] dp = new int[len, 2];

            int result = 0;
            if (s[0] == '0')
            {
                dp[0, 0] = 1;
            }
            else
            {
                dp[0, 1] = 1;
                result++;
            }

            for (int i = 1; i < len; i++)
            {
                if (s[i] == '0')
                {
                    dp[i, 0] = dp[i - 1, 0] + 1;
                    dp[i, 1] = dp[i - 1, 1];
                }
                else
                {
                    dp[i, 0] = dp[i - 1, 0];
                    dp[i, 1] = dp[i - 1, 1] + 1;
                }

                if (dp[i, 0] * dp[i, 0] <= dp[i, 1])
                    result++;
            }

            for (int i = 1; i < len; i++)
            {
                bool isZero = s[i - 1] == '0';
                for (int j = i; j < len; j++)
                {
                    if (isZero)
                        dp[j, 0]--;
                    else
                        dp[j, 1]--;

                    if (dp[j, 0] * dp[j, 0] <= dp[j, 1])
                        result++;
                }
            }

            return result;
        }

        public static int Run2(string s)
        {
            //0的下标
            List<int> indexs = new List<int>();
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                if (s[i] == '0')
                    indexs.Add(i);
            }

            //1的总数
            int tot1 = len - indexs.Count;
            indexs.Add(len);

            int result = 0;
            int left = 0;

            for (int i = 0; i < len; i++)
            {
                for (int j = left; j < indexs.Count - 1; j++)
                {
                    int cnt0 = j - left  +1;
                    if (cnt0 * cnt0 > tot1)
                        break;

                    int p = indexs[j];
                    int q = indexs[j + 1];
                    int cnt1 = p - i + 1 - cnt0;

                    if (cnt1 >= cnt0 * cnt0)
                    {
                        //1的个数足够
                        result += q - p;
                    }
                    else
                    {
                        //1的个数不够
                        result += Math.Max(q - p - (cnt0 * cnt0 - cnt1), 0);
                    }
                }

                if (s[i] == '0')
                {
                    left += 1;
                }
                else
                {
                    result += indexs[left] -i;
                    tot1 -= 1;
                }
            }

            return result;
        }
    }
}
