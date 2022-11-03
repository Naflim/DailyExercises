using NaflimHelperLibrary;
using System.Collections.Generic;

namespace DailyExercises
{
    /// <summary>
    /// 907. 子数组的最小值之和
    /// </summary>
    internal class MinSubarraysSum
    {
        //public static int SumSubarrayMins(int[] arr)
        //{
        //    int MOD = (int)1e9+7;
        //    long count = 0;
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        var head = arr[i];
        //        LinkedList<int> stack = new();
        //        stack.AddLast(head);
        //        count += head;
        //        for (int j = i + 1; j < arr.Length; j++)
        //        {
        //            var val = arr[j];
        //            var last = stack.Last;
        //            while (last != null && last.Value > val)
        //            {
        //                stack.RemoveLast();
        //                last = stack.Last;
        //            }

        //            stack.AddLast(val);
        //            count += stack.First?.Value??0;
        //        }
        //    }

        //    return (int)(count % MOD);
        //}

        //public static int SumSubarrayMins(int[] arr)
        //{
        //    const double MOD = 1e9+7;
        //    long count = 0;

        //    int len = arr.Length - 1;

        //    List<int> mins = arr.ToList();

        //    count += mins.Sum();
        //    for (int i = 0; i<len; i++)
        //    {
        //        List<int> tmp = new List<int>();
        //        int minLen = mins.Count - 1;
        //        for (int j = 0; j<minLen; j++)
        //        {
        //            tmp.Add(Math.Min(mins[j], mins[j + 1]));
        //        }

        //        count += tmp.Sum();
        //        mins = tmp;
        //    }

        //    return (int)(count % MOD);
        //}

        public static long SumSubarrayMins(int[] arr)
        {
            long count = 0;
            const int MOD = 1000000007;
            int len = arr.Length;

            for (int i = 0; i<len; i++)
            {
                var val = arr[i];

                int letf = 0;
                if (i == 0) letf = 1;
                else
                {
                    for (int j = i - 1; j >= 0 && val < arr[j]; j--)
                    {
                        letf++;
                    }
                    letf++;
                }

                int right = 0;
                if (i == len - 1) right = 1;
                else
                {
                    for (int j = i + 1; j < len && val <= arr[j]; j++)
                    {
                        right++;
                    }
                    right++;
                }

                count = (count + (long)letf * right * val) % MOD;
            }

            return (int)count;
        }
    }
}
