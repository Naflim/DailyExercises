using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1780. 判断一个数字是否可以表示成三的幂的和
    /// </summary>
    internal class CheckPowersOfThree
    {
        public static bool Run(int n)
        {
            double[] powers = new double[15];

            for(int i = 0; i<powers.Length; i++)
            {
                powers[i] = Math.Pow(3,i);
            }

            double val = n;
            for (int i = powers.Length - 1; i >= 0; i--)
            {
                if(val >= powers[i]) val -= powers[i];
            }

            return val == 0;
        }
    }
}
