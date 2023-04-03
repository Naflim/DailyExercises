using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 902. 最大为 N 的数字组合
    /// </summary>
    internal class MaxNArray
    {
        public static int AtMostNGivenDigitSet(string[] digits, int n)
        {
            int count = 0;
            int len = n.ToString().Length;
            if (digits.Length == 1)
            {
                string nStr = n.ToString();
                int nLen = nStr.Length;

                int inCount = 0;
                for(int i = 0; i < nLen; i++)
                {
                    string nowDigit = string.Empty;
                    for (int j = 0; j < i+1; j++) nowDigit += digits[0];
                    int nowDigitNum = Convert.ToInt32(nowDigit);
                    if (nowDigitNum>n) break;
                    inCount++;
                }
                return inCount;
            }
            else
            {
                for (int i = 1; i<len; i++) count += (int)Math.Pow(digits.Length, i);
                return GetMaxCount(digits, n, count);

            }
           
        }

        public static int GetMaxCount(string[] digits, int n, int maxCount)
        {
            string nStr = n.ToString();
            int len = nStr.Length;
            int[] counts = new int[len];

            AddSequence(digits,n, counts,0);

            return maxCount += GetCount(counts, digits.Length);
        }

        static void AddSequence(string[] digits,int n, int[] arr,int index)
        {
            string nStr = n.ToString();
            int len = nStr.Length;

            int[] digitNums = digits.Select(v=>Convert.ToInt32(v)).ToArray();
            int max = digitNums.Length;
            string valid;
            int validNum = 0;
            int nowN = n % (int)Math.Pow(10, len - index);
            int i;
            for (i = 0; i<digitNums.Length; i++)
            {
                valid = digits[i];
                for (int j = index+1; j<len; j++) valid += digits.Last();
                validNum = Convert.ToInt32(valid);
                if (nowN >= validNum) arr[index]++;
                else break;
            }

            if (nowN>validNum)
            {
                Fill(arr,index+1, 0);
                return;
            }

            valid = digits[i];
            for (int j = index+1; j<len; j++) valid += digits[0];
            int invalidNum = Convert.ToInt32(valid);

            if (nowN < invalidNum)
            {
                Fill(arr, index+1, 0);
                return;
            }

            AddSequence(digits,n,arr,index+1);
        }

        public static int[] Fill(int[] arr, int startIndex, int fillNum)
        {
            for (int i = startIndex; i<arr.Length; i++) arr[i] = fillNum;
            return arr;
        }

        public static int GetCount(int[] counts, int max)
        {
            int count = 0;
            for (int i = 0; i<counts.Length; i++)
            {
                count += counts[i] * (int)Math.Pow(max, counts.Length-i-1);
            }

            return count;
        }
    }
}