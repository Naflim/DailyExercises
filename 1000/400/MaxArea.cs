using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1465. 切割后面积最大的蛋糕
    /// </summary>
    internal class MaxArea
    {
        public const int MOD = 0x3b9aca07;
        public static int Run(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            List<int> hor = new List<int>(horizontalCuts) { h };
            hor.Sort();
            List<int> ver = new List<int>(verticalCuts) {  w };
            ver.Sort();

            int[] horizontal = new int[hor.Count];
            int[] vertical = new int[ver.Count];

            horizontal[0] = hor[0];
            for (int i = 1; i < horizontal.Length; i++)
            {
                horizontal[i] = hor[i] - hor[i - 1];
            }

            vertical[0] = ver[0];
            for (int i = 1; i < vertical.Length; i++)
            {
                vertical[i] = ver[i] - ver[i - 1];
            }

            return (int)((long)horizontal.Max() * vertical.Max() % MOD);
        }
    }
}
