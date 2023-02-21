using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1326. 灌溉花园的最少水龙头数目
    /// </summary>
    internal class MinTaps
    {
        public static int Run(int n, int[] ranges)
        {
            int len = n + 1;
            (int, int)[] scope = new (int, int)[len];
            List<int>[] dp = new List<int>[len];
            for (int i = 0; i < len; i++)
            {
                dp[i] = new List<int>();
            }

            for (int i = 0; i < len; i++)
            {
                int left = i - ranges[i];
                if(left < 0) left = 0;
                int right = i + ranges[i];
                if(right > n) right = n;

                scope[i] = (left, right);

                for (int j = left; j < right + 1; j++)
                {
                    dp[j].Add(i);
                }
            }

            int result = 0;
            int pointer = 0;
            while (true)
            {
                var sortList = dp[pointer].QuickSort(v => scope[v].Item2);
                int right = scope[sortList[^1]].Item2;
                if (pointer == right) return -1;
                pointer = right;
                result++;
                if (pointer == n) break;
            }

            return result;
        }
    }
}
