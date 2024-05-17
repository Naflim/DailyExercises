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
            if (stones.Length == 1) return 0;

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

        public static int Run2(int[] stones, int k)
        {
            int n = stones.Length;

            if(n == 1)
                return 0;

            if ((k != 2 && n % (k - 1) != 1) || n < k)
                return -1;

            int m = k == 2 ? n - 1 : n / (k - 1);

            int[] sum = new int[n];
            sum[0] = stones[0];

            for (int i = 1; i < n; i++)
            {
                sum[i] = sum[i-1] + stones[i];
            }

            int[,] dp = new int[m, n];
            dp[0, k-1] = sum[k-1];

            for (int i = k; i < n; i++)
            {
                dp[0, i] = sum[i] - sum[i - k];
            }

            for (int i = 1; i < m; i++)
            {
                int multiplier = (i + 1) * (k - 1);
                for (int j = multiplier; j < n; j++)
                {
                    List<int> possibility = new List<int>();
                    for (int t = 0; t <= j - k; t++)
                    {
                        if (dp[i - 1,t] != 0)
                        {
                            int prev = dp[i - 1,t];
                            int now = sum[j] - sum[j - k];
                            possibility.Add(prev + now);
                        }
                    }

                    for (int t = 0; t < k; t++)
                    {
                        int prev = dp[i - 1, j - t];
                        int now = sum[j];

                        int index = j - multiplier - 1;
                        if (index >= 0)
                            now -= sum[index];

                        possibility.Add(prev + now);
                    }

                    dp[i,j] = possibility.Min();
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
