using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 646. 最长数对链
    /// </summary>
    internal class FindLongestChain
    {
        public static int Run(int[][] pairs)
        {
            List<int[]> dp = new List<int[]>();
            int[][] refer = new int[pairs.Length][];
            Array.Copy(pairs, refer, pairs.Length);
            refer = refer.QuickSort(v => v[1]).ToArray();
            while(refer.Length > 0) 
            {
                dp.Add(refer[0]);
                int criterion = dp[^1][1];
                refer = refer.Where(v => v[0] > criterion).ToArray();
            }

            return dp.Count;
        }
    }
}
