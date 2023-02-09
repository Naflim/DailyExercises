using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2293. 极大极小游戏
    /// </summary>
    internal class MinMaxGame
    {
        public static int Run(int[] nums)
        {
            if(nums.Length == 1)return nums[0];

            int[] ints= new int[nums.Length / 2];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = i % 2 == 0 ? Math.Min(nums[2 * i], nums[2 * i + 1]) : Math.Max(nums[2 * i], nums[2 * i + 1]);
            }

            return Run(ints);
        }
    }
}
