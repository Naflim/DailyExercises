using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2600. K 件物品的最大和
    /// </summary>
    internal class KItemsWithMaximumSum
    {
        public static int Run(int numOnes, int numZeros, int numNegOnes, int k)
        {
            int result = 0;

            if (numOnes > k)
            {
                return k;
            }
            else
            {
                result += numOnes;
                k -= numOnes;
            }

            if(numZeros > k) 
            {
                return result;
            }
            else
            {
                k -= numZeros;
            }

            return result - k;
        }
    }
}
