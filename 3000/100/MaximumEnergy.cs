using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 3147. 从魔法师身上吸取的最大能量
    /// </summary>
    internal class MaximumEnergy
    {
        public static int Run(int[] energy, int k)
        {
            int max = int.MinValue;

            for (int i = 0; i<k; i++)
            {
                int len = energy.Length / k;
                if (energy.Length % k > i)
                {
                    len++;
                }

                int start = energy.Length - 1 - i;
                int sum = 0;
                for (int j = 0; j < len; j++)
                {
                    int index = start - j * k;
                    sum += energy[index];
                    max = Math.Max(max, sum);
                }
            }

            return max;
        }
    }
}
