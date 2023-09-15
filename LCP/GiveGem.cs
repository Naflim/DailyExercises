using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises.LCP
{
    /// <summary>
    /// LCP 50. 宝石补给
    /// </summary>
    internal class GiveGem
    {
        public static int Run(int[] gem, int[][] operations)
        {
            for (int i = 0; i < operations.Length; i++) 
            {
                var operation = operations[i];
                var gift = gem[operation[0]] / 2;
                gem[operation[0]] -= gift;
                gem[operation[1]] += gift;
            }

            Array.Sort(gem);

            return gem[^1] - gem[0];
        }
    }
}
