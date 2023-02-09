using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1769. 移动所有球到每个盒子所需的最小操作数
    /// </summary>
    internal class ArrangeBall
    {
        public static int[] MinOperations(string boxes)
        {
            List<int> indexs = new List<int>();

            for(int i = 0; i<boxes.Length; i++)
            {
                if (boxes[i] == '1') indexs.Add(i);
            }

            int[] result = new int[boxes.Length];

            for (int i = 0; i<boxes.Length; i++)
            {
                int step = 0;
                indexs.ForEach(v => step += Math.Abs(i - v));
                result[i] = step;
            }

            return result;
        }
    }
}
