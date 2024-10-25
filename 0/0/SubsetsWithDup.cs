using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 90. 子集 II
    /// </summary>
    internal class SubsetsWithDup
    {
        public static IList<IList<int>> Run(int[] nums)
        {
            int gather = 0;

            int len = nums.Length;

            for (int i = 0; i < len; i++)
                gather |= 1 << i;

            Dictionary<string,IList<int>> map = new Dictionary<string,IList<int>>();

            for (int sub = gather; sub > 0; sub = (sub - 1) & gather)
            {
                List<int> list = new List<int>();
                foreach (var i in sub.ToGather())
                {
                    list.Add(nums[i]);
                }

                list.Sort();

                string key = string.Join(",", list);
                map[key] = list;
            }

            IList<IList<int>> result = map.Values.ToList();

            result.Add([]);

            return result;
        }
    }
}
