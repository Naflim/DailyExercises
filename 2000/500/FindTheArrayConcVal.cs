using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2562. 找出数组的串联值
    /// </summary>
    internal class FindTheArrayConcVal
    {
        public static long Run(int[] nums)
        {
            var numList = nums.ToList();
            long result = 0;
            while(numList.Count > 0) 
            {
                if(numList.Count > 1)
                {
                    var first = numList.First();
                    var last = numList.Last();
                    result += Convert.ToInt64($"{first}{last}");
                    numList.RemoveAt(numList.Count - 1);
                    numList.RemoveAt(0);
                }
                else
                {
                    result += numList[0];
                    numList.RemoveAt(0);
                }
            }

            return result;
        }
    }
}
