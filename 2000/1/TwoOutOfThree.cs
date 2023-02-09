using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2032. 至少在两个数组中出现的值
    /// </summary>
    internal class TwoOutOfThree
    {
        public static IList<int> Run(int[] nums1, int[] nums2, int[] nums3)
        {
            List<int> nums = new List<int>();

            nums.AddRange(nums1.Distinct());
            nums.AddRange(nums2.Distinct());
            nums.AddRange(nums3.Distinct());

            Dictionary<int,int> dic = new Dictionary<int,int>();

            nums.ForEach(v =>
            {
                if (dic.ContainsKey(v)) dic[v]++;
                else dic[v] = 1;
            });
            
            List<int> result = new List<int>();

            foreach(var item in dic)
            {
                if(item.Value > 1)result.Add(item.Key);
            }

            return result;
        }

    }
}
