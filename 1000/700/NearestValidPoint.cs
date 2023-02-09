using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1779. 找到最近的有相同 X 或 Y 坐标的点
    /// </summary>
    internal class NearestValidPoint
    {
        public static int Run(int x, int y, int[][] points)
        {
            int index = -1, distance = int.MaxValue;
            for (int i = 0; i<points.Length; i++)
            {
                var point = points[i];
                if (point[0] == x)
                {
                    var nowDis = Math.Abs(y - point[1]);
                    if (nowDis < distance)
                    {
                        index = i;
                        distance = nowDis;
                    }

                }
                else if (point[1] == y)
                {
                    var nowDis = Math.Abs(x - point[0]);
                    if (nowDis < distance)
                    {
                        index = i;
                        distance = nowDis;
                    }
                }
            }

            return index;
        }
    }
}
