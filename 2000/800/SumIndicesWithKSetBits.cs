using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2859. 计算 K 置位下标对应元素的和
    /// </summary>
    internal class SumIndicesWithKSetBits
    {
        public static int Run(IList<int> nums, int k)
        {
            int result = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                string bin = Convert.ToString(i, 2);
                if (bin.Count(v => v == '1') == k)
                    result += nums[i];
            }

            return result;
        }
    }
}
