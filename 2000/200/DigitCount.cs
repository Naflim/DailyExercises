using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2283. 判断一个数的数字计数是否等于数位的值
    /// </summary>
    internal class DigitCount
    {
        public static bool Run(string num)
        {
            if(num.Length == 1)return false;

            Dictionary<int, int> count = new();
            int[] nums = new int[num.Length];

            int len = num.Length;
            for (int i = 0; i<len; i++)
            {
                int n = nums[i] = num[i] - 48;

                if (count.ContainsKey(n)) count[n]++;
                else count[n] = 1;
            }

            for (int i = 0; i<len; i++)
            {
                if(count.ContainsKey(i))
                {
                    if(count[i] != nums[i])return false;
                }
                else
                {
                    if (nums[i] != 0)return false;
                }
            }

            return true;
        }
    }
}
