using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    class MaxEnvelopesComparator : IComparer<int[]>
    {
        public int Compare(int[]? x, int[]? y)
        {
            if (x[0] != y[0])
            {
                return x[0] - y[0];
            }
            else
            {
                return y[1] - x[1];
            }
        }
    }

    /// <summary>
    /// 354. 俄罗斯套娃信封问题
    /// </summary>
    internal class MaxEnvelopes
    {
        public static int Run(int[][] envelopes)
        {
            SortedDictionary<int, HashSet<int>> width = new();
            SortedDictionary<int, HashSet<int>> height = new();

            for (int i = 0; i < envelopes.Length; i++)
            {
                if (width.ContainsKey(envelopes[i][0]))
                    width[envelopes[i][0]].Add(i);
                else
                    width[envelopes[i][0]] = new HashSet<int> { i };

                if (height.ContainsKey(envelopes[i][1]))
                    height[envelopes[i][1]].Add(i);
                else
                    height[envelopes[i][1]] = new HashSet<int> { i };
            }

            int wLen = width.Count;
            int hLen = height.Count;
            int[,] dp = new int[hLen, wLen];

            HashSet<int>[] wList = width.Values.ToArray();
            HashSet<int>[] hList = height.Values.ToArray();

            if (wList[0].Any(w => hList[0].Contains(w)))
                dp[0, 0] = 1;

            for (int i = 1; i < wLen; i++)
            {
                if (dp[0, i-1] == 1)
                    dp[0, i] = 1;
                else
                    dp[0, i] = wList[i].Any(w => hList[0].Contains(w)) ? 1 : 0;
            }

            for (int i = 1; i < hLen; i++)
            {
                if (dp[i - 1, 0] == 1)
                    dp[i, 0] = 1;
                else
                    dp[i, 0] = wList[0].Any(w => hList[i].Contains(w)) ? 1 : 0;
            }

            for (int i = 1; i < hLen; i++)
            {
                for (int j = 1; j < wLen; j++)
                {
                    if (wList[j].Any(w => hList[i].Contains(w)))
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = new int[] { dp[i-1, j-1], dp[i-1, j], dp[i, j-1] }.Max();
                }
            }

            return dp[hLen - 1, wLen - 1];
        }

        public static int Run2(int[][] envelopes)
        {
            if (envelopes.Length == 0)
            {
                return 0;
            }

            int n = envelopes.Length;
            Array.Sort(envelopes, new MaxEnvelopesComparator());

            List<int> f = new();
            f.Add(envelopes[0][1]);
            for (int i = 1; i<n; ++i)
            {
                int num = envelopes[i][1];
                if (num > f[f.Count - 1])
                {
                    f.Add(num);
                }
                else
                {
                    int index = BinarySearch(f, num);
                    f[index] = num;
                }
            }
            return f.Count;
        }

        private static int BinarySearch(List<int> f, int target)
        {
            int low = 0, high = f.Count - 1;
            while (low < high)
            {
                int mid = (high - low) / 2 + low;
                if (f[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return low;
        }
    }
}
