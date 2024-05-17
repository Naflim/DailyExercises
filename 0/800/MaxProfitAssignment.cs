using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 826. 安排工作以达到最大收益
    /// </summary>
    internal class MaxProfitAssignment
    {
        public static int Run(int[] difficulty, int[] profit, int[] worker)
        {
            SortedDictionary<int,int> taskBook = new SortedDictionary<int,int>();
            int len = difficulty.Length;
            for (int i = 0; i < len; i++)
            {
                var diff = difficulty[i];
                if(taskBook.ContainsKey(diff))
                    taskBook[diff] = Math.Max(taskBook[diff], profit[i]);
                else
                    taskBook[diff] = profit[i];
            }

            var keyList = taskBook.Keys.ToList();
            int max = int.MinValue;

            for (int i = 0; i < keyList.Count; i++)
            {
                var key = keyList[i];
                if (max > taskBook[key])
                    taskBook[key] = max;
                else
                    max = taskBook[key];
            }

            int result = 0;

            foreach(var work in worker)
            {
                int key = work;
                var index = keyList.BinarySearch(work);
                if(index < 0)
                {
                    index = (~index) - 1;
                    if (index == -1)
                        continue;

                    key = keyList[index];
                }

                result += taskBook[key];
            }

            return result;
        }
    }
}
