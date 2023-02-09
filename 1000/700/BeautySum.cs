using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1781. 所有子字符串美丽值之和
    /// </summary>
    internal class BeautySum
    {
        public static int Run(string s)
        {
            int count = 0,len = s.Length;
            List<Dictionary<char, int>> dp= new List<Dictionary<char, int>>();
            for(int i = 0;i<len - 2;i++) 
            {
                var beautySum = CreateBeautySum(s.Skip(i).Take(3));
                count += beautySum.Item2;
                dp.Add(beautySum.Item1);
            }

            if(len > 3) 
            {
                for(int i = 3; i<len; i++)
                {
                    for(int j = i; j<len; j++)
                    {
                        count += AddBeautySum(dp[j-i], s[j]);
                    }
                }
            }

            return count;
        }

        static (Dictionary<char, int>, int) CreateBeautySum(IEnumerable<char> s)
        {
            Dictionary<char, int> dic = new();
            foreach (char c in s)
            {
                if (dic.ContainsKey(c)) dic[c]++;
                else dic[c] = 1;
            }

            return (dic, dic.Values.Max() - dic.Values.Min());
        }

        static int AddBeautySum(Dictionary<char, int> dic,char c)
        {
            if (dic.ContainsKey(c)) dic[c]++;
            else dic[c] = 1;

            return dic.Values.Max() - dic.Values.Min();
        }
    }
}
