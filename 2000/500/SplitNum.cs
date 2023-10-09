using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2578. 最小和分割
    /// </summary>
    internal class SplitNum
    {
        public static int Run(int num)
        {
            string strNum = num.ToString();
            var nums = strNum.OrderBy(v => v).ToArray();
            List<char> nums1 = new List<char>();
            List<char> nums2 = new List<char>();
            for (int i = 0; i < nums.Length; i++)
            {
                if(i % 2 == 0)
                    nums1.Add(nums[i]);
                else
                    nums2.Add(nums[i]);
            }

            int num1 = Convert.ToInt32(new string(nums1.ToArray()));
            int num2 = Convert.ToInt32(new string(nums2.ToArray()));

            return num1 + num2;
        }
    }
}
