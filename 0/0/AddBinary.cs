using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 67. 二进制求和
    /// </summary>
    class AddBinary
    {
        public static string Run(string a, string b)
        {
            if (b == "0")
                return a;

            string sum = BitwiseOperationUtils.XOR(a, b);
            string carry = BitwiseOperationUtils.AND(a, b);
            carry = BitwiseOperationUtils.LeftShift(carry, 1);

            sum = BitwiseOperationUtils.Simplify(sum);
            carry = BitwiseOperationUtils.Simplify(carry);

            return Run(sum, carry);
        }

        public static string Run2(string a, string b)
        {
            int longLen = Math.Max(a.Length, b.Length);
            a = a.PadLeft(longLen, '0');
            b = b.PadLeft(longLen, '0');

            int carry = 0;

            char[] bits = new char[longLen];

            for (int i = longLen - 1; i >= 0; i--)
            {
                int bitA = a[i] - 48;
                int bitB = b[i] - 48;
                int sum = bitA + bitB + carry;

                if(sum % 2 == 1)
                {
                    bits[i] = '1';
                    sum--;
                }
                else
                {
                    bits[i] = '0';
                }

                carry = sum >> 1;
            }

            string result = new string(bits);

            if(carry > 0)
            {
                string bin = Convert.ToString(carry,2);
                result = bin + result;
            }

            return result;
        }
    }
}
