using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2341. 数组能形成多少数对
    /// </summary>
    internal class NumberOfPairs
    {
        public static int[] Run(int[] nums)
        {
            Dictionary<int, int> dic = new();
            int[] result = new int[2];

            foreach(int num in nums) 
            {
                if (dic.ContainsKey(num)) dic[num]++;
                else dic[num] = 1;
            }

            foreach(var val in dic.Values) 
            {
                result[0] += val / 2;
                if(val % 2 == 1) result[1]++;
            }

            return result;
        }
    }
}
