using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 最大为 N 的数字组合
    /// </summary>
    internal class MaxNArray
    {
        public static int AtMostNGivenDigitSet(string[] digits, int n)
        {
            //int nowNum;
            int count = 0;
            int len = n.ToString().Length;

            //int[] counts = new int[len];

            //while (true)
            //{
            //    nowNum = GetNum(digits, counts);
            //    if (nowNum > n) break;
            //    count++;
            //    try
            //    {
            //        ContainerIncrement(counts, digits.Length - 1, len - 1);
            //    }
            //    catch (IndexOutOfRangeException)
            //    {
            //        break;
            //    }
            //}

            for (int i = 1; i<len; i++) count += (int)Math.Pow(digits.Length, i);


            return GetMaxCount(digits,n,count);
        }

        static int GetNum(string[] digits, int[] counts)
        {
            string numStr = string.Empty;
            for (int i = 0; i < counts.Length; i++) numStr += digits[counts[i]];
            return Convert.ToInt32(numStr);
        }

        public static void ContainerIncrement(int[] arr,int max,int index)
        {
            if (arr[index] == max)
            {
                if(index == 0)throw new IndexOutOfRangeException("容器溢出");
                else
                {
                    ContainerIncrement(arr, max, index - 1);
                    arr[index] = 0;
                };
            }
            else arr[index]++;
        }

        public static int GetMaxCount(string[] digits, int n,int maxCount)
        {
            string nStr = n.ToString();
            int len = nStr.Length;
            

            int[] counts = new int[len];
            //for (int i = 0; i<counts.Length; i++) counts[i] = digits.Length;
            //for (int i = 0; i<digits.Length && i< nStr.Length; i++)
            //{
            //    int head = Convert.ToInt32(nStr[i].ToString());
            //    counts[i] = 0;
            //    for (int j = 0; j<digits.Length; j++)
            //    {
            //        if (Convert.ToInt32(digits[j])<=head)counts[i]++;
            //    }
            //    if (counts[i] > 1||(i==0 && Convert.ToInt32(digits[i]) < head)) break;
            //    else if (counts[i]<1) return maxCount;
            //}

            int count = 1;
            for (int i = 0; i<counts.Length; i++) count *= counts[i];
            return maxCount += count;
        }
    }
}