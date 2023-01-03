using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2042. 检查句子中的数字是否递增
    /// </summary>
    internal class AreNumbersAscending
    {
        public static bool Run(string s)
        {
            var nums = ExtractNumbers(s);

            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[i]>=nums[i+1]) return false;
            }

            return true;
        }

        public static List<int> ExtractNumbers(string str)
        {
            string num = string.Empty;
            List<int> result = new List<int>();
            foreach(char c in str) 
            {
                if(c >= '0' && c <= '9')
                {
                    num += c;
                }
                else
                {
                    if (!string.IsNullOrEmpty(num))
                    {
                        result.Add(Convert.ToInt32(num));
                        num = string.Empty;
                    }
                }
            }
            if (!string.IsNullOrEmpty(num)) result.Add(Convert.ToInt32(num));

            return result;
        }
    }
}
