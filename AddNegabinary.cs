using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    internal class AddNegabinary
    {
        public static int[] Run(int[] arr1, int[] arr2)
        {
            return IntToNegabinary(NegabinaryToInt(arr1) + NegabinaryToInt(arr2));
        }

        public static int[] Run2(int[] arr1, int[] arr2)
        {
            int i = arr1.Length - 1, j = arr2.Length - 1;
            int carry = 0;
            IList<int> ans = new List<int>();
            while (i >= 0 || j >= 0 || carry != 0)
            {
                int x = carry;
                if (i >= 0)
                {
                    x += arr1[i];
                }
                if (j >= 0)
                {
                    x += arr2[j];
                }
                if (x >= 2)
                {
                    ans.Add(x - 2);
                    carry = -1;
                }
                else if (x >= 0)
                {
                    ans.Add(x);
                    carry = 0;
                }
                else
                {
                    ans.Add(1);
                    carry = 1;
                }
                --i;
                --j;
            }
            while (ans.Count > 1 && ans[ans.Count - 1] == 0)
            {
                ans.RemoveAt(ans.Count - 1);
            }
            int[] arr = new int[ans.Count];
            for (i = 0, j = ans.Count - 1; j >= 0; i++, j--)
            {
                arr[i] = ans[j];
            }
            return arr;
        }

        public static int NegabinaryToInt(int[] arr)
        {
            int result = 0;

            var r = arr.Reverse().ToArray();

            for (int i = 0; i < r.Length; i++)
            {
                if (r[i] == 1)
                {
                    result += (int)Math.Pow(-2, i);
                }
            }

            return result;
        }

        public static int[] IntToNegabinary(int n)
        {
            if (n == 0) return new int[] { 0 };
            List<int> bin = new List<int>();
            while (true)
            {
                if (n != 1)
                {
                    bin.Add(Math.Abs(n % -2));
                    n = (int)Math.Ceiling((double)n / -2);
                }
                else
                {
                    bin.Add(Math.Abs(n));
                    break;
                }
            }
            bin.Reverse();
            return bin.ToArray();
        }
    }
}
