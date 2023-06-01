using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1964. 找出到每个位置为止最长的有效障碍赛跑路线
    /// </summary>
    internal class LongestObstacleCourseAtEachPosition
    {
        public static int[] Run(int[] obstacles)
        {
            List<int> dp = new List<int>();
            dp.Add(obstacles[0]);
            int[] result = new int[obstacles.Length];
            result[0] = 1;
            for (int i = 1; i < obstacles.Length; i++)
            {
                result[i] = GetCount(dp, obstacles[i]);
            }
            return result;
        }

        public static int GetCount(List<int> list, int target)
        {
            int left = -1, right = list.Count;

            if(target < list[0])
            {
                list[0] = target;
                return 1;
            }

            if (target >= list[^1])
            {
                list.Add(target);
                return list.Count;
            }

            while (left + 1 != right)
            {
                int pointer = (right + left) / 2;
                if (list[pointer] >  target)
                {
                    right = pointer;
                }
                else if (list[pointer] < target)
                {
                    left = pointer;
                }
                else
                {
                    while (list[pointer] == target)
                        pointer++;

                    list[pointer] = target;
                    return pointer + 1;
                }
            }

            list[right] = target;
            return right + 1;
        }

        public static int[] Run2(int[] obstacles)
        {
            List<int[]> dp = new();
            int[] result = new int[obstacles.Length];

            for (int i = 0; i < obstacles.Length; i++)
            {
                var effective = dp.Where(v => v[0] <= obstacles[i]).ToArray();
                if (effective.Length > 0)
                {
                    dp.Add(new int[] { obstacles[i], effective.Max(v => v[1]) + 1 });
                }
                else
                {
                    dp.Add(new int[] { obstacles[i], 1 });
                }
                result[i] = dp[i][1];
            }

            return result;
        }

        public static int Run3(int[] obstacles)
        {
            int[] tails = new int[obstacles.Length];
            int res = 0;

            for (int n = 0; n < obstacles.Length; n++)
            {
                int num = obstacles[n];
                int i = 0, j = res;
                while (i < j)
                {
                    int m = (i + j) / 2;
                    if (tails[m] < num) i = m + 1;
                    else j = m;
                }
                tails[i] = num;
                if (res == j) res++;
            }
            return res;
        }
    }
}
