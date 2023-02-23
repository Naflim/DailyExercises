using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1238. 循环码排列
    /// </summary>
    internal class CircularPermutation
    {
        public static IList<int> Run(int n, int start)
        {
            int len = (int)Math.Pow(2, n);
            int listStart = start / len * len;

            int[] grayCodes = new int[len];
            int[] result = new int[len];
            for (int i = 0; i < len; i++)
            {
                grayCodes[i] = GrayCode(i + listStart);
            }

            int pointer = Array.IndexOf(grayCodes, start);

            if (pointer == -1) return result;

            Array.Copy(grayCodes, pointer, result, 0, len - pointer);

            if (pointer > 0) Array.Copy(grayCodes, 0, result, len - pointer, pointer);

            return result;
        }

        public static int GrayCode(int n)
        {
            return n ^ (n >> 1);
        }

        public static int GrayCodeToDecimal(int grayCode)
        {
            int binary = grayCode;
            int mask = binary >> 1;

            while (mask != 0)
            {
                binary ^= mask;
                mask >>= 1;
            }

            return binary;
        }
    }
}
