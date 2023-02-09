using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1822. 数组元素积的符号
    /// </summary>
    internal class ArraySumSign
    {
        public  static int ArraySign(int[] nums)
        {
            int count = 1;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i]==0) return 0;
                if (nums[i]<0) count *= -1;
            }

            return count;
        }
    }
}
