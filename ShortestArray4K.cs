using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 862. 和至少为 K 的最短子数组
    /// </summary>
    public class ShortestArray4K
    {
        public static int ShortestSubarray(int[] nums, int k)
        {
            var sortDescending = SortDescending(nums);
            int max = nums.Max();
            if (max >= k) return 1;

            for (int i = k / max + 1; i <= nums.Length; i++)
            {
                for(int j = sortDescending.Count - 1; j >= 0; j--)
                {
                    var num = sortDescending.ElementAt(j).Key;
                    if (num * i < k) break;
                    var indexs = sortDescending.ElementAt(j).Value;
                    for(int k1 = 0; k1 < indexs.Count; k1++)
                    {
                        int head;
                        if (indexs[k1] >= i-1)
                        {
                            head = indexs[k1] - i + 1;
                            //if (nums.Skip(head).Take(i).Sum() >= k) return i;
                        }
                        else head = 0;

                        for(int l = head; l<=indexs[k1]; l++)
                        {
                            if (nums.Skip(l).Take(i).Sum() >= k) return i;
                        }

                        //if (indexs[k1] <= nums.Length - i)
                        //{
                        //    //if (nums.Skip(indexs[k1]).Take(i).Sum() >= k) return i;
                        //}
                    }
                }
            }

            return -1;
        }

        public static SortedDictionary<int,List<int>> SortDescending(int[] num)
        {
            SortedDictionary<int, List<int>> sortedDictionary = new();
            for (int i = 0; i < num.Length; i++)
            {
                if (sortedDictionary.ContainsKey(num[i])) sortedDictionary[num[i]].Add(i);
                else sortedDictionary.Add(num[i], new List<int> { i });
            }

            return sortedDictionary;
        }
    }
}
