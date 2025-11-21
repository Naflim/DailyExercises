using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1930. 长度为 3 的不同回文子序列
    /// </summary>
    internal class CountPalindromicSubsequence
    {
        public static int Run(string s)
        {
            Dictionary<char, List<int>> dic = new Dictionary<char, List<int>>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i]))
                {
                    dic[s[i]] = new List<int>();
                }

                dic[s[i]].Add(i);
            }

            int result = 0;

            foreach (var item1 in dic)
            {
                if (item1.Value.Count < 2)
                {
                    continue;
                }

                //回文首
                int min = item1.Value[0];
                //回文尾
                int max = item1.Value[^1];

                foreach (var item2 in dic)
                {
                    //待选中间字符
                    var list = item2.Value;

                    int left = -1;
                    int right = list.Count;

                    while (left +1 != right)
                    {
                        int pointer = (left + right)/2;
                        if (list[pointer]>=max)
                        {
                            right = pointer;
                        }
                        else if (list[pointer]<=min)
                        {
                            left = pointer;
                        }
                        else
                        {
                            result++;
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
