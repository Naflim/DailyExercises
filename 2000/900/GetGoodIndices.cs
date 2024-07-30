using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2961. 双模幂运算
    /// </summary>
    internal class GetGoodIndices
    {
        public static IList<int> Run(int[][] variables, int target)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < variables.Length; i++)
            {
                var item = variables[i];
                var ai = item[0];
                var bi = item[1];
                var ci = item[2];
                var mi = item[3];
                var val = Math.Pow(Math.Pow(ai, bi) % 10, ci) % mi;
                if (val == target)
                    result.Add(i);
            }

            return result;
        }

        public static IList<int> Run2(int[][] variables, int target)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < variables.Length; i++)
            {
                var item = variables[i];
                var ai = item[0];
                var bi = item[1];
                var ci = item[2];
                var mi = item[3];
                var val = MathUtils.FastExponentiationModulo(MathUtils.FastExponentiationModulo(ai, bi, 10), ci, mi);
                if (val == target)
                    result.Add(i);
            }

            return result;
        }
    }
}
