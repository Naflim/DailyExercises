using DailyExercises.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 78. 子集
    /// </summary>
    internal class Subsets
    {
        public static IList<IList<int>> Run(int[] nums)
        {
            int gather = 0;

            int len = nums.Length;

            for (int i = 0; i < len; i++)
                gather |= 1 << i;

            IList<IList<int>> result = new List<IList<int>>();

            for (int sub = gather; sub > 0; sub = (sub - 1) & gather)
            {
                List<int> list = new List<int>();
                foreach (var i in sub.ToGather())
                {
                    list.Add(nums[i]);
                }

                result.Add(list);
            }

            result.Add([]);

            return result;
        }
    }
}
