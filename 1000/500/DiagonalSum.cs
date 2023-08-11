using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1572. 矩阵对角线元素的和
    /// </summary>
    internal class DiagonalSum
    {
        public static int Run(int[][] mat)
        {
            int len = mat.Length;

            int result = 0;
            for (int i = 0; i < len; i++)
            {
                int secondaryIndex = len - i - 1;
                result += mat[i][i] + mat[i][secondaryIndex];
            }

            if(len % 2 == 1)
            {
                int index = len / 2;
                result -= mat[index][index];
            }
                
            return result;
        }
    }
}
