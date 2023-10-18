using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2530. 执行 K 次操作后的最大分数
    /// </summary>
    internal class MaxKelements
    {
        public static long Run(int[] nums, int k)
        {
            long result = 0;
            SortedDictionary<int, int> dic = new SortedDictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (dic.ContainsKey(num))
                    dic[num]++;
                else
                    dic[num] = 1;
            }

            for (int i = 0; i < k; i++)
            {
                var last = dic.Last();
                if(last.Value > 1)
                    dic[last.Key]--;
                else
                    dic.Remove(last.Key);

                var val = last.Key;
                result += val;

                val = (int)Math.Ceiling((double)val / 3);
                if(dic.ContainsKey(val))
                    dic[val]++;
                else
                    dic[val] = 1;
            }

            return result;
        }

        public static long Run2(int[] nums, int k)
        {
            long result = 0;
            Array.Sort(nums);
            SortedList<int, int> dic = new SortedList<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (dic.ContainsKey(num))
                    dic[num]++;
                else
                    dic[num] = 1;
            }

            for (int i = 0; i < k; i++)
            {
                var lastKey = dic.Keys[^1];
                var lastVal = dic.Values[^1];
                if (lastVal > 1)
                    dic[lastKey]--;
                else
                    dic.RemoveAt(dic.Count - 1);

                var val = lastKey;
                result += val;

                val = (int)Math.Ceiling((double)val / 3);
                if (dic.ContainsKey(val))
                    dic[val]++;
                else
                    dic[val] = 1;
            }

            return result;
        }

        public static long Run3(int[] nums, int k)
        {
            PriorityQueue<int, int> q = new PriorityQueue<int, int>();
            foreach (int num in nums)
            {
                q.Enqueue(num, -num);
            }
            long ans = 0;
            for (int i = 0; i < k; ++i)
            {
                int x = q.Dequeue();
                ans += x;
                q.Enqueue((x + 2) / 3, -(x + 2) / 3);
            }
            return ans;
        }
    }
}
