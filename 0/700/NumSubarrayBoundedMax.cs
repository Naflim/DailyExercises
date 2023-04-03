using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 795. 区间子数组个数
    /// </summary>
    public class NumSubarrayBoundedMax
    {
        public static int Run(int[] nums, int left, int right)
        {
            List<int> subList = new();
            int count = 0;
            for (int i = 0; i<nums.Length; i++)
            {
                if (nums[i] > right)
                {
                    if (subList.Count> 0)
                    {
                        count += GetCombinationsCount(subList, left);
                        subList.Clear();
                    }
                }
                else subList.Add(nums[i]);
            }
            if (subList.Count> 0)
            {
                count += GetCombinationsCount(subList, left);
                subList.Clear();
            }
            return count;
        }

        public static int GetCombinationsCount(List<int> subList, int min)
        {
            int count = GetCombinationsCount(subList);

            List<int> block = new();
            for (int i = 0; i< subList.Count; i++)
            {
                if (subList[i] < min) block.Add(subList[i]);
                else
                {
                    if (block.Count> 0)
                    {
                        count -= GetCombinationsCount(block);
                        block.Clear();
                    }

                }
            }

            if (block.Count> 0)
            {
                count -= GetCombinationsCount(block);
                block.Clear();
            }

            return count;
        }

        /// <summary>
        /// 获取组合数
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int GetCombinationsCount(IEnumerable<int> list)
        {
            int count = 0;
            for (int i = 1; i <= list.Count(); i++) count+=i;
            return count;
        }
    }
}
