using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    public class MergeStones
    {
        public static int Run(int[] stones, int k)
        {
            if(stones.Length == 1) return 0;

            if (!CanCompose(stones.Length, k)) return -1;
            List<int> stoneCache = stones.ToList();

            int result = 0;
            while (stoneCache.Count > 1)
            {
                result += GetMinCost(stoneCache, k);
            }

            return result;
        }

        public static bool CanCompose(int len, int k)
        {
            while (len > k)
            {
                len = len - k + 1;
            }

            return len == k;
        }

        public static int GetMinCost(List<int> stones, int k)
        {
            int minCost = stones.Take(k).Sum(), minIndex = k - 1;
            for (int i = k; i<stones.Count; i++)
            {
                var currentSum = stones.Skip(i- k + 1).Take(k).Sum();
                if (currentSum < minCost)
                {
                    minCost = currentSum;
                    minIndex = i;
                }
            }

            stones.Insert(minIndex + 1, minCost);
            stones.RemoveRange(minIndex - k + 1, k);
            return minCost;
        }
    }
}
