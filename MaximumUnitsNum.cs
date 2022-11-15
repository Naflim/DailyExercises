using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1710. 卡车上的最大单元数
    /// </summary>
    internal class MaximumUnitsNum
    {
        public static int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            var sortBoxTypes = boxTypes.ToList();
            sortBoxTypes.Sort((x, y) => -x[1].CompareTo(y[1]));
            int count = 0;

            while(truckSize > 0 && sortBoxTypes.Count > 0) 
            {
                if (sortBoxTypes[0][0] > truckSize)
                {
                    count += truckSize * sortBoxTypes[0][1];
                    truckSize = 0;
                }
                else
                {
                    count += sortBoxTypes[0][0] * sortBoxTypes[0][1];
                    truckSize -= sortBoxTypes[0][0];
                    sortBoxTypes.RemoveAt(0);
                }
            }

            return count;
        }
    }
}

