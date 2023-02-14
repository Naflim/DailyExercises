using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1124. 表现良好的最长时间段
    /// </summary>
    public class LongestWPI
    {
        //public static int Run(int[] hours)
        //{
        //    int n = hours.Length;
        //    int[] s = new int[n + 1];
        //    Stack<int> stk = new Stack<int>();
        //    stk.Push(0);
        //    for (int i = 1; i <= n; i++)
        //    {
        //        s[i] = s[i - 1] + (hours[i - 1] > 8 ? 1 : -1);
        //        if (s[stk.Peek()] > s[i])
        //        {
        //            stk.Push(i);
        //        }
        //    }

        //    int res = 0;
        //    for (int r = n; r >= 1; r--)
        //    {
        //        while (stk.Count > 0 && s[stk.Peek()] < s[r])
        //        {
        //            res = Math.Max(res, r - stk.Pop());
        //        }
        //    }
        //    return res;
        //}

        public static int Run(int[] hours)
        {
            int len = hours.Length;
            int[] corporateSlaveTime = new int[len];
            int[] prefix = new int[len];

            for (int i = 0; i < len; i++)
            {
                corporateSlaveTime[i] = hours[i] > 8 ? +1 : -1;
                if (i==0) prefix[i] = corporateSlaveTime[i];
                else prefix[i] = prefix[i-1] + corporateSlaveTime[i];
            }

            for (int i = len - 1; i>=0; i--)
            {
                if (prefix[i] > 0) return i + 1;
                for (int j = 0; j<len - i - 1; j++)
                {
                    if (prefix[i + j + 1] - prefix[j] > 0) return i + 1;
                }
            }

            return 0;
        }
    }
}
