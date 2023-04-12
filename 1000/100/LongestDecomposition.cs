using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1147. 段式回文
    /// </summary>
    public class LongestDecomposition
    {
        public static int Run(string text)
        {
            int len = text.Length / 2;

            int result = 0;
            string head = string.Empty;
            string end = string.Empty;

            for (int i = 0; i<len; i++)
            {
                head += text[i];
                end = text[text.Length - i - 1] + end;

                if (head == end)
                {
                    result++;
                    head = string.Empty;
                    end = string.Empty;
                }
            }

            result *= 2;
            if (!string.IsNullOrEmpty(head) || text.Length % 2 == 1) result++;
            return result;
        }
    }
}
