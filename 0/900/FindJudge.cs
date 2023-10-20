using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 997. 找到小镇的法官
    /// </summary>
    internal class FindJudge
    {
        public static int Run(int n, int[][] trust)
        {
            bool[,] matrix = new bool[n, n];

            for (int i = 0; i < trust.Length; i++) 
            {
                matrix[trust[i][0] - 1, trust[i][1] - 1] = true;
            }

            for (int i = 0; i < n; i++)
            {
                if(IsJudge(n,matrix,i))
                    return i + 1;
            }

            return -1;
        }

        public static bool IsJudge(int n, bool[,] matrix,int man)
        {
            for (int i = 0; i < n; i++)
            {
                if(i == man)
                {
                    if (matrix[man, man])
                        return false;
                }
                else
                {
                    if (!matrix[i, man] || matrix[man,i])
                        return false;
                }
            }

            return true;
        }
    }
}
