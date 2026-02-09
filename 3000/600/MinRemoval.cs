using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 3634. 使数组平衡的最少移除数目
    /// </summary>
    internal class MinRemoval
    {
        public static int Run(int[] nums, int k)
        {
            List<int> list = nums.ToList();
            list.Sort();
            return GetMinRemovalByBinarySearch(list, k);
        }

        private static void GetMinRemoval(List<int> list, int k, ref int count)
        {
            int min = list[0];
            int max = list[list.Count - 1];

            if (min * k >= max)
                return;

            if (list.Count == 2)
            {
                count++;
                return;
            }

            int minMagnification = list[list.Count - 2] / min;
            int maxMagnification = max / list[1];

            if (minMagnification > maxMagnification)
            {
                list.RemoveAt(0);
                count++;
                GetMinRemoval(list, k, ref count);
            }
            else if (minMagnification < maxMagnification)
            {
                list.RemoveAt(list.Count - 1);
                count++;
                GetMinRemoval(list, k, ref count);
            }
            else
            {
                int minDis = list[1] - min;
                int maxDis = max - list[list.Count - 2];

                if (minDis > maxDis)
                {
                    list.RemoveAt(0);
                    count++;
                    GetMinRemoval(list, k, ref count);
                }
                else
                {
                    list.RemoveAt(list.Count - 1);
                    count++;
                    GetMinRemoval(list, k, ref count);
                }
            }
        }

        private static int GetMinRemoval(List<int> list, int k)
        {
            int len = list.Count;
            List<int> maxList = new List<int>();
            int possibility = list.Count;

            for (int i = 0; i < len; i++)
            {
                int min = list[i];
                List<int> subList = new List<int> { min };
                long max = (long)min * k;
                if (len - i < possibility)
                    break;

                for (int j = i + 1; j < len; j++)
                {
                    if (max >= list[j])
                    {
                        subList.Add(list[j]);
                    }
                    else
                    {
                        break;
                    }
                }

                if (subList.Count > maxList.Count)
                {
                    maxList = subList;
                    possibility = len - maxList.Count;
                }
            }

            return len - maxList.Count;
        }

        private static int GetMinRemovalByBinarySearch(List<int> list, int k)
        {
            int len = list.Count;
            int maxLen = 0;

            for (int i = 0; i < len; i++)
            {
                int min = list[i];
                long max = (long)min * k;
                if (max >= list[^1])
                {
                    var val = len - i;
                    if (val > maxLen)
                        maxLen = val;
                    break;
                }
                else
                {
                    int target = (int)max;
                    var index = list.BinarySearch(target);
                    if (index < 0)
                    {
                        index = (~index) - 1;
                    }
                    while (len > index + 1 && list[index] == list[index + 1])
                    {
                        index++;
                    }

                    var val = index - i + 1;
                    if (val > maxLen)
                        maxLen = val;
                }
            }

            return len - maxLen;
        }
    }
}
