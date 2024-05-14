using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2244. 完成所有任务需要的最少轮数
    /// </summary>
    internal class MinimumRounds
    {
        public static int Run(int[] tasks)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (var task in tasks)
            {
                if (map.ContainsKey(task))
                    map[task]++;
                else
                    map[task] = 1;
            }

            if (map.Values.Any(v => v == 1))
                return -1;

            int result = 0;
            foreach (var item in map)
            {
                var val = item.Value;
                while(val > 0)
                {
                    if (val <= 3)
                        val = 0;
                    else
                        val -= 3;

                    result++;
                }
            }

            return result;
        }
    }
}
