using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 89. 格雷编码
    /// </summary>
    class GrayCode
    {
        public static IList<int> Run(int n)
        {
            List<int> trajectory = new List<int>();
            List<int> result = new List<int>();
            int val = 0;
            result.Add(val);
            for (int i = 0; i < n; i++)
            {
                List<int> newTrajectory = new List<int>();
                int mask = 1 << i;
                val ^= mask;
                result.Add(val);
                newTrajectory.Add(i);

                foreach(int index in trajectory)
                {
                    mask = 1 << index;
                    val ^= mask;
                    result.Add(val);
                    newTrajectory.Add(index);
                }

                trajectory.AddRange(newTrajectory);
            }

            return result;
        }
    }
}
