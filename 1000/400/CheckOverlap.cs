using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1401. 圆和矩形是否有重叠
    /// </summary>
    internal class CheckOverlap
    {
        public static bool Run(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2)
        {
            int minX, minXDis, minY, minYDis;
            int xd1 = Math.Abs(xCenter - x1);
            int xd2 = Math.Abs(xCenter - x2);
            int yd1 = Math.Abs(yCenter - y1);
            int yd2 = Math.Abs(yCenter - y2);
            if (xd1 < xd2)
            {
                minX  = x1;
                minXDis = xd1;
            }
            else
            {
                minX = x2;
                minXDis = xd2;
            }

            if (yd1 < yd2)
            {
                minY = y1;
                minYDis = yd1;
            }
            else
            {
                minY = y2;
                minYDis = yd2;
            }

            //矩形包含圆形
            if (x1 < xCenter && x2 > xCenter && y1 < yCenter && y2 > yCenter)
            {
                return true;
            }
            //x轴包含圆形
            else if(x1 < xCenter && x2 > xCenter)
            {
                return minYDis <= radius;
            }
            //y轴包含圆形
            else if(y1 < yCenter && y2 > yCenter)
            {
                return minXDis <= radius;
            }
            else
            {
                return MathUtils.GetDistance(minX, minY, xCenter, yCenter) <= radius;
            }
        }
    }
}



