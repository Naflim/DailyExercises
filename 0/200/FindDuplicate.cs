using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 287. 寻找重复数
    /// </summary>
    internal class FindDuplicate
    {
        public static int Run(int[] nums)
        {
            int len = nums.Length;
            int n = len - 1;

            int result = 0;
            for (int i = 0; i < 32; i++)
            {
                int defVal = 0;
                int mask = 1 << i;
                int numsVal = nums[0] & mask;

                for (int j = 1; j < len; j++)
                {
                    defVal += j & mask;
                    numsVal += nums[j] & mask;
                }

                if(numsVal > defVal)
                    result |= 1 << i;
            }

            return result;
        }
    }
}
