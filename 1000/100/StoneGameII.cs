using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1140. 石子游戏 II
    /// </summary>
    internal class StoneGameII
    {
        public static int Run(int[] piles)
        {
            int len = piles.Length;

            int[,] qb = new int[len + 1, len];

            int sum = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                sum += piles[i];
                for (int m = 1; m <= len; m++)
                {
                    if (len - i <= m*2) qb[m, i] = sum;
                    else
                    {
                        for (int j = 1; j <= m*2; j++)
                        {
                            qb[m, i] = Math.Max(qb[m, i], sum - qb[Math.Max(m, j), i+j]);
                        }
                    }
                }
            }

            return qb[1, 0];
        }
    }
}
