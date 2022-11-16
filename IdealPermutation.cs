using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 775. 全局倒置与局部倒置
    /// </summary>
    internal class IdealPermutation
    {
        public static bool IsIdealPermutation(int[] nums)
        {
            int max = 0;
            for (int i = 0; i<nums.Length - 1; i++)
            {
                if (max>nums[i+1]) return false;
                max = Math.Max(max, nums[i]);
            }
            return true;
        }
    }
}
