using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2251. 花期内花的数目
    /// </summary>
    internal class FullBloomFlowers
    {
        public static int[] Run(int[][] flowers, int[] people)
        {
            SortedDictionary<int, int> dic = new SortedDictionary<int, int>();
            foreach (var flower in flowers)
            {
                if (dic.ContainsKey(flower[0]))
                    dic[flower[0]] += 1;
                else
                    dic[flower[0]] = 1;

                if (dic.ContainsKey(flower[1] + 1))
                    dic[flower[1] + 1] -= 1;
                else
                    dic[flower[1] + 1] = -1;
            }

            var days = dic.Keys.ToArray();
            for (int i = 1; i < days.Length; i++)
            {
                var now = days[i];
                var prev = days[i - 1];
                dic[now] = dic[now] + dic[prev];
            }

            int len = people.Length;
            int[] result = new int[len];
            
            for (int i = 0; i < len; i++)
            {
                var day = people[i];
                int refDay = GetRefDay(days, day);
                result[i] = refDay == -1 ? 0 : dic[days[refDay]];
            }

            return result;
        }

        public static int GetRefDay(IList<int> days, int day)
        {
            int left = 0;
            int right = days.Count - 1;

            if (days[left] > day)
                return -1;

            if (days[right] <= day)
                return right;

            while (left +1 != right)
            {
                int pointer = (left + right) / 2;
                if (days[pointer] > day) right = pointer;
                else if (days[pointer] < day) left = pointer;
                else return pointer;
            }

            return left;
        }
    }
}
