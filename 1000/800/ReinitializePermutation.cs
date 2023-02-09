using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1806. 还原排列的最少操作步数
    /// </summary>
    internal class ReinitializePermutation
    {
        public static int Run(int n)
        {
            int[] perm = new int[n];
            for (int i = 0; i < n; i++) perm[i] = i;
            
            var arr = Change(perm);
            int count = 1;

            while(!Enumerable.SequenceEqual(perm, arr))
            {
                arr = Change(arr);
                count++;
            }

            return count;
        }

        public static int[] Change(int[] perm)
        {
            int len = perm.Length;
            int[] arr = new int[len];
            for (int i = 0; i < len; i++)
            {
                if (i % 2 == 0) arr[i] = perm[i / 2];
                else arr[i] = perm[len / 2 + (i - 1) / 2];
            }

            return arr;
        }
    }
}
