using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1073. 负二进制数相加
    /// </summary>
    internal class AddNegabinary
    {
        public static int[] Run(int[] arr1, int[] arr2)
        {
            var sum = NegabinaryToInt(arr1) + NegabinaryToInt(arr2);
            if (sum == 0)
                return [0];
            return IntToNegabinary(sum);
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

        public static int[] Run3(int[] arr1, int[] arr2)
        {
            int len = Math.Min(arr1.Length, arr2.Length);

            int[] longArr;
            int[] shortArr;

            if(arr1.Length > arr2.Length)
            {
                longArr = arr1;
                shortArr = arr2;
            }
            else
            {
                longArr = arr2;
                shortArr = arr1;
            }

            for (int i = 0; i < len; i++)
            {
                longArr[^ (i + 1)] += shortArr[^(i + 1)];
            }

            if (longArr[0] == 0)
                return longArr;

            return IntToNegabinary(longArr);
        }

        //public static int NegabinaryToInt(int[] arr)
        //{
        //    int result = 0;

        //    var r = arr.Reverse().ToArray();

        //    for (int i = 0; i < r.Length; i++)
        //    {
        //        if (r[i] == 1)
        //        {
        //            result += (int)Math.Pow(-2, i);
        //        }
        //    }

        //    return result;
        //}

        public static int NegabinaryToInt(int[] arr)
        {
            int result = 0;

            int len = arr.Length;

            for (int i = 0; i < len; i++)
            {
                if (arr[i] == 0)
                    continue;

                if (i % 2 == 0)
                {
                    result += 1 << i;
                }
                else
                {
                    result -= 1 << i;
                }
            }

            return result;
        }

        //public static int[] IntToNegabinary(int n)
        //{
        //    if (n == 0) return new int[] { 0 };
        //    List<int> bin = new List<int>();
        //    while (true)
        //    {
        //        if (n != 1)
        //        {
        //            bin.Add(Math.Abs(n % -2));
        //            n = (int)Math.Ceiling((double)n / -2);
        //        }
        //        else
        //        {
        //            bin.Add(Math.Abs(n));
        //            break;
        //        }
        //    }
        //    bin.Reverse();
        //    return bin.ToArray();
        //}

        public static int[] IntToNegabinary(int n)
        {
            int left = int.LeadingZeroCount(n);

            List<int> list = new List<int>();
            for (int i = 0; i < 32; i++)
            {
                int mask = 1 << i;

                if ((n & mask) != 0)
                {
                    if (i % 2 == 0)
                    {
                        list.Add(1);
                    }
                    else
                    {
                        list.Add(1);
                        n += 1 << (i + 1);
                    }
                }
                else
                {
                    list.Add(0);
                }
            }

            list.Reverse();

            return list.ToArray();
        }

        public static int[] IntToNegabinary(int[] arr)
        {
            List<int> list = arr.ToList();
            List<int> result = new List<int>();

            list.Reverse();

            int i = 0;

            while (list.Last() != 0) 
            {
                var val = list[i];

                if (i == list.Count - 1)
                    list.Add(0);

                if (val > 1)
                {
                    result.Add(val % 2);
                    list[i + 1] -= val / 2;
                }
                else if (val < 0)
                {
                    result.Add(-(val % 2));
                    list[i + 1] -= val;
                }
                else
                {
                    result.Add(val);
                }

                i++;
            }

            result.Reverse();

            while (result.Count != 1 && result[0] == 0)
            {
                result.RemoveAt(0);
            }

            return result.ToArray();
        }
    }
}
