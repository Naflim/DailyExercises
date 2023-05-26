using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1027. 最长等差数列
    /// </summary>
    internal class LongestArithSeqLength
    {
        public static int Run(int[] nums)
        {
            Dictionary<int, Dictionary<int, int>> dic = new();
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int val = nums[j] - nums[i];
                    if (dic.ContainsKey(val))
                    {
                        if (dic[val].ContainsKey(j))
                            dic[val][i] = dic[val][j] + 1;
                        else
                            dic[val][i] = 2;
                    }
                    else
                    {
                        dic[val] = new Dictionary<int, int>();
                        dic[val][i] = 2;
                    }
                }
            }

            return dic.Values.Select(v => v.Values.Max()).Max();
        }
    }
}
