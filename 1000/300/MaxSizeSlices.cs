using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1388. 3n 块披萨
    /// </summary>
    internal class MaxSizeSlices
    {
        public static int Run(int[] slices)
        {
            int len = slices.Length;
            int[,] dp = new int[len, len];

            int result = 0;
            for (int i = 0; i < len; i++)
            {
                dp[0, i] = slices[i];
                result = Math.Max(result, dp[0, i]);
            }

            if (slices.Length == 1)
                return result;

            for (int i = 0; i < len; i++)
            {
                List<int> nums = new List<int> { slices[i] };
                int index = i - 1;
                if (index < 0)
                    index += len;

                nums.Add(slices[index]);
                dp[1, i] = nums.Max();
                result = Math.Max(result, dp[1, i]);
            }

            if (slices.Length == 2)
                return result;

            for (int i = 0; i < len; i++)
            {
                List<int> nums = new List<int> { slices[i] };
                for (int j = 1; j < 2; j++)
                {
                    int index = i - j;
                    if (index < 0)
                        index += len;

                    nums.Add(slices[index]);
                }

                dp[2, i] = nums.Max();
                result = Math.Max(result, dp[2, i]);
            }

            for (int i = 3; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    var indexA = j - 1;
                    if (indexA < 0)
                        indexA += len;

                    var indexB = j - 2;
                    if (indexB < 0)
                        indexB += len;

                    var indexC = j - 3;
                    if (indexC < 0)
                        indexC += len;

                    var indexD = j - i;
                    if (indexD < 0)
                        indexD += len;

                    if (i % 3 == 0)
                    {
                        int[] possibility = new int[4];
                        possibility[0] = dp[i-3, indexB] + slices[j];
                        possibility[1] = dp[i-3, indexC] + slices[indexA];
                        possibility[2] = dp[i-3, indexA] + slices[indexD];
                        possibility[3] = dp[i-1, indexA];

                        dp[i, j] = possibility.Max();
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i-1, indexA], slices[j] + dp[i-3, indexB]);
                    }

                    result = Math.Max(result, dp[i, j]);
                }
            }

            for (int i = 0; i < len; i++)
            {
                int[] arr = new int[len];
                for (int j = 0; j < len; j++)
                {
                    arr[j] = dp[i, j];
                    //Console.Write($"{dp[i, j]},");
                }
                Console.WriteLine(arr.Max());
            }

            return result;
        }

        public static int Run2(int[] slices)
        {
            int[] v1 = new int[slices.Length - 1];
            int[] v2 = new int[slices.Length - 1];
            Array.Copy(slices, 1, v1, 0, slices.Length - 1);
            Array.Copy(slices, 0, v2, 0, slices.Length - 1);
            int ans1 = Calculate(v1);
            int ans2 = Calculate(v2);
            return Math.Max(ans1, ans2);
        }

        private static int Calculate(int[] slices)
        {
            int N = slices.Length, n = (N + 1) / 3;
            int[][] dp = new int[N][];
            for (int i = 0; i < N; i++)
            {
                dp[i] = new int[n + 1];
                Array.Fill(dp[i], int.MinValue);
            }
            dp[0][0] = 0;
            dp[0][1] = slices[0];
            dp[1][0] = 0;
            dp[1][1] = Math.Max(slices[0], slices[1]);
            for (int i = 2; i < N; i++)
            {
                dp[i][0] = 0;
                for (int j = 1; j <= n; j++)
                {
                    dp[i][j] = Math.Max(dp[i - 1][j], dp[i - 2][j - 1] + slices[i]);
                }
            }
            return dp[N - 1][n];
        }
    }
}
