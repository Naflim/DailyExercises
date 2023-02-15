using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1250. 检查「好数组」
    /// </summary>
    public class IsGoodArray
    {
        public static bool Run(int[] nums)
        {
            return nums.GetGCD() == 1;
        }
    }
}
