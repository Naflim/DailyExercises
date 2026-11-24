using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 3411. 最长乘积等价子数组
    /// </summary>
    internal class MaxLength
    {
        public static int Run(int[] nums)
        {
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < nums.Length - i; j++)
                {
                    int[] sub = new int[i + 1];
                    Array.Copy(nums, j, sub, 0, i + 1);

                    if(Prod(sub) == GcdOfArray(sub) * LcmOfArray(sub))
                        return i + 1;
                }
            }

            return 0;
        }

        public static int Prod(int[] nums)
        {
            int result = 1;
            for (int i = 0; i < nums.Length; i++) 
                result *= nums[i];

            return result;
        }

        public static int Gcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
                (a, b) = (b, a % b);
            return a;
        }

        public static int GcdOfArray(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("数组不能为空");

            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = Gcd(result, numbers[i]);
                if (result == 1) break;  // 已为 1，提前退出（1 与任何数 GCD 都是 1）
            }
            return result;
        }

        public static long Gcd(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
                (a, b) = (b, a % b);
            return a;
        }

        public static long Lcm(long a, long b)
        {
            if (a == 0 || b == 0) return 0;
            // 先除后乘，防止 a * b 溢出
            return Math.Abs(a / Gcd(a, b) * b);
        }

        public static long LcmOfArray(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("数组不能为空");

            long result = 1;
            foreach (var n in numbers)
            {
                result = Lcm(result, n);
                if (result == 0) break;  // 出现 0，结果为 0
            }
            return result;
        }
    }
}
