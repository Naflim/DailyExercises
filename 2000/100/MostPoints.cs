using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2140. 解决智力问题
    /// </summary>
    internal class MostPoints
    {
        public static long Run(int[][] questions)
        {
            questions = questions.Reverse().ToArray();
            long[] dp = new long[questions.Length];
            dp[0] = questions[0][0];
            for (int i = 1; i < dp.Length; i++)
            {
                var question = questions[i];
                int prevPointer = i - question[1] - 1;
                if(prevPointer < 0)
                {
                    dp[i] = Math.Max(dp[i-1], question[0]);
                }
                else
                {
                    dp[i] = Math.Max(dp[i-1], dp[prevPointer] + question[0]);
                }
            }

            return dp[questions.Length - 1];
        }
    }
}
