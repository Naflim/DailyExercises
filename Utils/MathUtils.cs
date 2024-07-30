using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises.Utils
{
    public static class MathUtils
    {
        public static int GetGCD(int a, int b)
        {
            if (b > a) (a, b) = (b, a);

            int remainder = a % b;

            if (remainder == 0) return b;
            else return GetGCD(b, remainder);
        }

        public static int GetGCD(this IEnumerable<int> nums)
        {
            var numArr = nums.ToArray();
            if (numArr.Length == 0) return 0;

            int len = numArr.Length, gcd = numArr[0];
            for (int i = 1; i < len; i++)
            {
                gcd = GetGCD(numArr[i], gcd);
            }

            return gcd;
        }

        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static double FastExponentiationModulo(double x, double y, double modulo)
        {
            while (y % 2 == 0)
            {
                x = x * x % modulo;
                y /= 2;
            }

            if (y == 1)
                return x % modulo;

            return FastExponentiationModulo(x, y - 1, modulo) * x % modulo;
        }
    }
}
