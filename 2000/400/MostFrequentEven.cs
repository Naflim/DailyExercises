using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2404. 出现最频繁的偶数元素
    /// </summary>
    public class MostFrequentEven
    {
        public static int Run(int[] nums)
        {
            SortedDictionary<int, int> table = new();

            foreach (int num in nums)
            {
                if (num % 2 == 0)
                {
                    if (table.ContainsKey(num)) table[num]++;
                    else table[num] = 1;
                }
            }

            if (table.Count == 0) return -1;

            int count = table.Values.Max();

            foreach (var row in table)
            {
                if (row.Value == count) return row.Key;
            }

            return -1;
        }
    }
}
