using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1035. 不相交的线
    /// </summary>
    internal class MaxUncrossedLines
    {
        public static int Run(int[] nums1, int[] nums2)
        {
            int len2 = nums2.Length;
            int len1 = nums1.Length;
            int[,] dp = new int[len2, len1];

            dp[0,0] = nums1[0] == nums2[0] ? 0 : 2;
            for (int i = 1; i < len1; i++)
            {
                if (nums1[i] == nums2[0])
                    dp[0, i] = i;
                else
                    dp[0,i] = dp[0,i - 1] + 1;
            }

            for (int i = 1; i < len2; i++)
            {
                if (nums1[0] == nums2[i])
                    dp[i, 0] = i;
                else
                    dp[i, 0] = dp[i - 1, 0] + 1;
            }

            for (int i = 1; i < len2; i++)
            {
                for (int j = 1; j < len1; j++)
                {
                    if (nums2[i] == nums1[j])
                    {
                        dp[i,j] = dp[i - 1,j - 1];
                    }
                    else
                    {
                        int min = Math.Min(dp[i - 1, j], dp[i,j - 1]);
                        dp[i,j] = min + 1;
                    }
                }
            }

            var last = dp[len2 - 1, len1 - 1];

            return (len1 + len2 - last) / 2;
        }
    }
}
