using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 891. 子序列宽度之和
    /// </summary>
    internal class SumOfSubseqWidths
    {
        public static int SumSubseqWidths(int[] nums)
        {
            const int MOD = 0x3b9aca07;
            long[] powers = new long[nums.Length];
            powers[0] = 1;
            for (int i = 1; i<nums.Length; i++)
            {
                powers[i]  = powers[i-1] * 2 % MOD;
            }

            long count = 0;
            var sort = nums.ToList();
            sort.Sort();
            int len = nums.Length;
            for (int i = 0; i<len; i++)
            {
                count += (powers[i] - powers[len - i - 1])*sort[i];
            }

            return (int)((count % MOD+MOD)%MOD);
        }
    }
}
