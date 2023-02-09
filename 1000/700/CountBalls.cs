using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1742. 盒子中小球的最大数量
    /// </summary>
    internal class CountBalls
    {
        public static int Run(int lowLimit, int highLimit)
        {
            Dictionary<int, int> boxs = new();

            for (int i = lowLimit; i<=highLimit; i++)
            {
                string s = i.ToString();
                int count = 0;
                foreach(char c in s) 
                {
                    count += c - 48;
                }

                if (boxs.ContainsKey(count)) boxs[count]++;
                else boxs[count] = 1;
            }

            return boxs.Values.Max();
        }
    }
}
