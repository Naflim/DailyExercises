using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 72. 编辑距离
    /// </summary>
    internal class MinDistance
    {
        public static int Run(string word1, string word2)
        {
            if(string.IsNullOrEmpty(word1))
                return word2.Length;

            if(string.IsNullOrEmpty(word2)) 
                return word1.Length;

            int lenA = word1.Length,lenB = word2.Length;

            int[,] dp = new int[lenA + 1, lenB + 1];

            for(int i = 1; i <= lenA; i++)
            {
                dp[i, 0] = i;
            }

            for (int i = 1; i <= lenB; i++)
            {
                dp[0, i] = i;
            }

            for (int i = 1; i <= lenA; i++)
            {
                for (int j = 1; j <= lenB; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = dp[i-1, j-1];
                    }
                    else
                    {
                        dp[i,j] = new int[] { dp[i-1, j], dp[i, j-1], dp[i-1,j-1] }.Min() + 1;
                    }
                }
            }

            return dp[lenA, lenB];   
        }
    }
}
