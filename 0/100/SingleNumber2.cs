using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 137. 只出现一次的数字 II
    /// </summary>
    internal class SingleNumber2
    {
        public static int Run(int[] nums)
        {
            string positive = string.Empty, negative = string.Empty;
            string posMult = string.Empty, negMult = string.Empty;

            int result = 0;

            foreach (int x in nums)
            {
                bool isNegative = x < 0;
                bool isExist = isNegative ? negative.ContainsBit(-x) : positive.ContainsBit(x);

                if (isExist)
                {
                    if (isNegative && !negMult.ContainsBit(-x))
                    {
                        string mark = BitwiseOperationUtils.GetMask(-x);
                        negMult = BitwiseOperationUtils.XOR(negMult, mark);
                    }
                    else if (!isNegative && !posMult.ContainsBit(x))
                    {
                        string mark = BitwiseOperationUtils.GetMask(x);
                        posMult = BitwiseOperationUtils.XOR(posMult, mark);
                    }
                }
                else
                {
                    if (isNegative)
                    {
                        string mark = BitwiseOperationUtils.GetMask(-x);
                        negative = BitwiseOperationUtils.XOR(negative, mark);
                    }
                    else
                    {
                        string mark = BitwiseOperationUtils.GetMask(x);
                        positive = BitwiseOperationUtils.XOR(positive, mark);
                    }

                    result ^= x;
                }
            }

            foreach (var val in posMult.ToGather())
            {
                result ^= val;
            }

            foreach (var val in negMult.ToGather())
            {
                result ^= -val;
            }

            return result;
        }

        public static int Run2(int[] nums)
        {
            string sum = string.Empty;

            foreach (var val in nums)
            {
                var bin = Convert.ToString(val, 2);
                string bigBin, smallBin;
                if (bin.Length > sum.Length)
                {
                    bigBin = bin;
                    smallBin = sum;
                }
                else
                {
                    bigBin = sum;
                    smallBin = bin;
                }

                string newSum = string.Empty;
                int len = bigBin.Length;

                for (int i = 0; i < len; i++)
                {
                    int index = i - len + smallBin.Length;

                    if (index < 0)
                    {
                        newSum += bigBin[i];
                    }
                    else
                    {
                        var v = bigBin[i] + smallBin[index] - 96;
                        newSum += v;
                    }
                }

                sum = newSum;
            }

            string resultBin = string.Empty;

            foreach (var bit in sum)
            {
                int val = (bit - 48) % 3;
                resultBin += val.ToString();
            }

            int result = Convert.ToInt32(resultBin, 2);

            return result;
        }

        public static int Run3(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < 32; i++)
            {
                int bit = 0;
                foreach (var num in nums)
                {
                    bit += num >> i & 1;
                }

                result |= (bit % 3)  << i;
            }
            return result;
        }
    }
}
