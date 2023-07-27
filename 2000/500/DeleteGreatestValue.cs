using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2500. 删除每行中的最大值
    /// </summary>
    internal class DeleteGreatestValue
    {
        public static int Run(int[][] grid)
        {
            List<int>[] table = grid.Select(v => v.ToList()).ToArray();
            int len = table[0].Count;
            int result = 0;
            int[] values = new int[table.Length];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < table.Length; j++)
                {
                    values[j] = table[j].Max();
                    table[j].Remove(values[j]);
                }
                result += values.Max();
            }

            return result;
        }
    }
}
