using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1653. 使字符串平衡的最少删除次数
    /// </summary>
    internal class MinimumDeletions
    {
        public static int Run(string s)
        {
            int result = int.MaxValue;
            (int, int, bool)[] dp = new (int, int, bool)[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0)
                {
                    int count = s.Count(c => c=='a');
                    if (s[0] == 'a') dp[0] = (0, count - 1, false);
                    else dp[0] = (0, count, true);
                }
                else
                {
                    int left = dp[i - 1].Item3 ? 1 : 0;
                    int right = s[i] == 'a' ? 1 : 0;
                    dp[i] = (dp[i-1].Item1 + left, dp[i-1].Item2 - right, right == 0);
                }

                result = Math.Min(dp[i].Item1 + dp[i].Item2, result);
            }

            return result;
        }
    }
}
