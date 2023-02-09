using System.Collections.Generic;

namespace DailyExercises
{
    /// <summary>
    /// 862. 和至少为 K 的最短子数组
    /// </summary>
    public class ShortestArray4K
    {
        public static int ShortestSubarray(int[] nums, int k)
        {
            int n = nums.Length;
            long[] sums = new long[n + 1];
            for (int i = 1; i <= n; i++)
            {
                sums[i] = sums[i - 1] + nums[i - 1];
            }
            LinkedList<int> list = new();
            list.AddFirst(0);
            int ans = -1;
            for (int i = 1; i <= n; i++)
            {
                long pre = sums[i];
                LinkedListNode<int> node = list.First;
                //当前序列以满足条件，让序列保持和低于K（去头取最简短序列）
                while (node != null && pre - sums[node.Value] >= k)
                {
                    if (ans == -1) ans = i - node.Value;
                    else ans = Math.Min(ans, i - node.Value);
                    list.RemoveFirst();
                    node = list.First;
                }
                node = list.Last;
                //始终保持尾部的前缀最小缩减区间范围
                while (node != null && pre <= sums[node.Value])
                {
                    list.RemoveLast();
                    node = list.Last;
                }
                list.AddLast(i);
            }
            return ans;
        }

        //public static int ShortestSubarray(int[] nums, int k)
        //{
        //    if (nums.Max() >= k) return 1;
        //    int shortCount = int.MaxValue;
        //    List<int> section = new List<int>();
        //    List<int> sectionMap = new List<int>();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        var num = nums[i];
        //        if (num > 0)
        //        {
        //            section.Add(num);
        //            sectionMap.Add(1);
        //        }
        //        else
        //        {
        //            if (section.Sum() + num <= 0)
        //            {
        //                section.Clear();
        //                sectionMap.Clear();
        //            }
        //            else Compress(section, sectionMap, num);
        //        }

        //        int sum = section.Sum();
        //        if (sum >= k)
        //        {
        //            int shortNum = sectionMap.Sum();
        //            if (sum > k)
        //            {
        //                while (true)
        //                {
        //                    if (section.Skip(1).Take(section.Count - 1).Sum() < k)
        //                    {
        //                        section.RemoveAt(0);
        //                        sectionMap.RemoveAt(0);
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        shortNum -= sectionMap[0];
        //                        section.RemoveAt(0);
        //                        sectionMap.RemoveAt(0);
        //                    }
        //                }
        //            }
        //            shortCount = Math.Min(shortCount, shortNum);
        //        }
        //    }

        //    if (shortCount != int.MaxValue) return shortCount;
        //    else return -1;
        //}

        //public static int ShortestSubarray(int[] nums, int k)
        //{
        //    var sortDescending = SortDescending(nums);
        //    var sortDic = SortDescending(sortDescending);

        //    int len = nums.Length;
        //    int max = nums.Max();

        //    int shortCount = int.MaxValue;
        //    if (max >= k) return 1;

        //    while (sortDic.Count > 0)
        //    {
        //        var val = sortDic.Last();
        //        int i, count = 0;
        //        for (i = val.Key; i < len && count < k; i++)
        //        {
        //            count += nums[i];
        //        }

        //        if (count < k)
        //        {
        //            for (i = val.Key; i < len; i++)
        //            {
        //                if (sortDic.ContainsKey(i)) sortDic.Remove(i);
        //                else break;
        //            }
        //        }
        //        else
        //        {
        //            shortCount = Math.Min(shortCount, i - val.Key);
        //            sortDic.Remove(val.Key);
        //        }
        //    }

        //    if (shortCount != int.MaxValue) return shortCount;
        //    else return -1;
        //}

        public static SortedDictionary<int, List<int>> SortDescending(int[] num)
        {
            SortedDictionary<int, List<int>> sortedDictionary = new();
            for (int i = 0; i < num.Length; i++)
            {
                if (sortedDictionary.ContainsKey(num[i])) sortedDictionary[num[i]].Add(i);
                else sortedDictionary.Add(num[i], new List<int> { i });
            }

            return sortedDictionary;
        }

        public static Dictionary<int, int> SortDescending(SortedDictionary<int, List<int>> sortDec)
        {
            Dictionary<int, int> sortedDictionary = new Dictionary<int, int>();
            foreach (var item in sortDec)
            {
                item.Value.ForEach(i => sortedDictionary.Add(i, item.Key));
            }

            return sortedDictionary;
        }

        public static void Compress(List<int> section, List<int> map, int data)
        {
            int last = section.Count - 1;
            int compressData = section[last] + data;

            if (compressData > 0)
            {
                section[last] = compressData;
                map[last]++;
            }
            else
            {
                int newLast = last - 1;
                section[newLast] +=  section[last];
                map[newLast] +=  map[last];
                section.RemoveAt(last);
                map.RemoveAt(last);
                Compress(section, map, data);
            }
        }
    }

    class PrefixSum
    {
        readonly int[] _sums;
        public PrefixSum(IEnumerable<int> list)
        {
            var arr = list.ToArray();
            _sums = new int[arr.Length];
            if (arr.Length == 0) return;
            _sums[0] = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                _sums[i] = _sums[i - 1] + arr[i];
            }
        }

        public int GetSectionSum(uint left, uint right)
        {
            if (left == 0) return _sums[right];
            else return _sums[right] - _sums[left - 1];
        }

        public int this[int index]
        {
            get
            {
                return _sums[index];
            }
        }
    }
}
