using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises.Utils
{
    public class BitwiseOperationUtils
    {
        public static int Add(int a, int b)
        {
            if(b == 0)
                return a;

            int sum = a ^ b;
            int carry = (a & b) << 1;
            return Add(sum, carry);
        }

        public static int Multiply(int a, int b)
        {
            int absA = Math.Abs(a);
            int absB = Math.Abs(b);

            int val = a ^ b;
            bool isNegative = (val >> 31) == -1;

            string bin = Convert.ToString(absB, 2);

            int result = 0;

            int len = bin.Length;
            for (int i = 0; i < len; i++)
            {
                char bit = bin[len - 1 - i];
                if (bit == '1')
                {
                    result += absA << i;
                }
            }

            return isNegative ? ~result + 1 : result;
        }

        public static int Divide(int a, int b)
        {
            long absA = Math.Abs((long)a);
            long absB = Math.Abs((long)b);

            int val = a ^ b;
            bool isNegative = (val >> 31) == -1;

            long quotient = 0;

            for (int i = 31; i >= 0; i--) 
            {
                var multiple = absB << i;
                if (multiple >= absB && multiple <= absA)
                {
                    quotient += (long)1 << i;
                    absA -= multiple;
                }
            }

            if (isNegative)
            {
                return (int)-quotient;
            }
            else
            {
                return quotient > int.MaxValue ? int.MaxValue : (int)quotient;
            }
        }
    }
}
