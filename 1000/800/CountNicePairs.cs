using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1814. 统计一个数组中好对子的数目
    /// </summary>
    internal class CountNicePairs
    {
        //public static int Run(int[] nums)
        //{
        //    int count = 0;
        //    int iLen = nums.Length - 1;
        //    int jLen = nums.Length;
        //    for (int i = 0; i < iLen; i++)
        //    {
        //        for (int j = i+1; j < jLen; j++)
        //        {
        //            if (NiceNumberPair(nums[i], nums[j]))count++;
        //        }
        //    }

        //    return count;
        //}

        //public static int Run(int[] nums)
        //{
        //    int count = 0;
        //    int iLen = nums.Length - 1;
        //    int len = nums.Length;

        //    (int, int)[] numPairArr = new (int, int)[len];

        //    for (int i = 0; i < len; i++)
        //    {
        //        numPairArr[i] = (nums[i], Reverse(nums[i]));
        //    }


        //    for (int i = 0; i < iLen; i++)
        //    {
        //        for (int j = i+1; j < len; j++)
        //        {
        //            if (NiceNumberPair(numPairArr[i], numPairArr[j])) count++;
        //        }
        //    }

        //    return count;
        //}
        const int MOD = 0x3b9aca07;
        public static int Run(int[] nums)
        {
            int len = nums.Length;
            int count = 0;

            int[] diffs = new int[len];

            for (int i = 0; i < len; i++)
            {
                diffs[i] = nums[i] - Reverse(nums[i]);
            }

            var gruop = diffs.GroupBy(v => v);

            foreach (var item in gruop)
            {
                int num = item.Count() - 1;

                for (int i = 1; i <= num; i++)
                {
                    count = (count + i) % MOD;
                }
               
            }

            return count;
        }

        //public static int Run(int[] nums)
        //{

        //    int res = 0;
        //    Dictionary<int, int> h = new Dictionary<int, int>();
        //    foreach (int i in nums)
        //    {
        //        int temp = i, j = 0;
        //        while (temp > 0)
        //        {
        //            j = j * 10 + temp % 10;
        //            temp /= 10;
        //        }
        //        h.TryAdd(i - j, 0);
        //        res = (res + h[i - j]) % MOD;
        //        h[i - j]++;
        //    }
        //    return res;
        //}


        private static bool NiceNumberPair(int numA,int numB) 
        {
            return numA + Reverse(numB) == numB + Reverse(numA);
        }

        private static bool NiceNumberPair((int,int) numA, (int, int) numB)
        {
            return numA.Item1 + numB.Item2 == numB.Item1 + numA.Item2;
        }

        private static int Reverse(int num)
        {
            return Convert.ToInt32(new string(num.ToString().Reverse().ToArray()));
        }
    }
}
