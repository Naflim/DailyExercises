using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises.Utils
{
    public static class BitwiseOperationUtils
    {
        public static string XOR(string a, string b)
        {
            int longLen = Math.Max(a.Length, b.Length);
            a = a.PadLeft(longLen, '0');
            b = b.PadLeft(longLen, '0');
            char[] bits = new char[longLen];

            for (int i = 0; i < longLen; i++)
            {
                bits[i] = a[i] == b[i] ? '0' : '1';
            }

            return new string(bits);
        }

        public static string AND(string a, string b)
        {
            int longLen = Math.Max(a.Length, b.Length);
            a = a.PadLeft(longLen, '0');
            b = b.PadLeft(longLen, '0');
            char[] bits = new char[longLen];

            for (int i = 0; i < longLen; i++)
            {
                bits[i] = a[i] == b[i] && a[i] == '1' ? '1' : '0';
            }

            return new string(bits);
        }

        public static string LeftShift(string a, int bit)
        {
            for (int i = 0; i < bit; i++)
            {
                a += '0';
            }

            return a;
        }

        public static string Simplify(string a)
        {
            if (a[0] == '1')
                return a;

            int i = 1;

            for (; i < a.Length; i++)
            {
                if (a[i] == '1')
                    return a[i..];
            }

            return "0";
        }

        public static int Add(int a, int b)
        {
            if (b == 0)
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

        public static IEnumerable<int> ToGather(this long num)
        {
            for (long t = num; t > 0; t &= t - 1)
            {
                yield return (int)long.TrailingZeroCount(t);
            }
        }

        public static IEnumerable<int> ToGather(this ulong num)
        {
            for (ulong t = num; t > 0; t &= t - 1)
            {
                yield return (int)ulong.TrailingZeroCount(t);
            }
        }

        public static IEnumerable<int> ToGather(this int num)
        {
            for (int t = num; t > 0; t &= t - 1)
            {
                yield return int.TrailingZeroCount(t);
            }
        }

        //public static int GetMask(int bit)
        //{
        //    return 1 << bit;
        //}

        public static string GetMask(int bit)
        {
            return "1".PadRight(bit + 1, '0');
        }

        public static IEnumerable<int> ToGather(this string bit)
        {
            int len = bit.Length;

            for (int i = 0; i < len; i++)
            {
                if (bit[i] == '1')
                {
                    yield return len - 1 - i;
                }
            }
        }
    }
}
