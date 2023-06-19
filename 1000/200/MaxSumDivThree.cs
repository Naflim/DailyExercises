using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1262. 可被三整除的最大和
    /// </summary>
    internal class MaxSumDivThree
    {
        public static int Run(int[] nums)
        {
            List<int>[] dp = new List<int>[3];
            for (int i = 0; i < 3; i++)
                dp[i] = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int[] add = new int[3];
                int mod = nums[i] % 3;
                int need = 3 - mod;
                int prev;
                if (mod == 0)
                {
                    prev = dp[0].LastOrDefault();
                    add[0] = prev + nums[i];
                }
                else
                {
                    prev = dp[need].LastOrDefault();
                    if(prev != 0)
                    {
                        add[0] = prev + nums[i];
                    }
                }

                need = mod == 2 ? 2 : 1 - mod;
                if (mod == 1)
                {
                    prev = dp[0].LastOrDefault();
                    add[1] = prev + nums[i];
                }
                else
                {
                    prev = dp[need].LastOrDefault();
                    if (prev != 0)
                    {
                        add[1] = prev + nums[i];
                    }
                }

                need = 2 - mod;
                if (mod == 2)
                {
                    prev = dp[0].LastOrDefault();
                    add[2] = prev + nums[i];
                }
                else
                {
                    prev = dp[need].LastOrDefault();
                    if (prev != 0)
                    {
                        add[2] = prev + nums[i];
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    var addNum = add[j];
                    if (addNum > dp[j].LastOrDefault())
                        dp[j].Add(addNum);
                }
            }

            return dp[0].LastOrDefault();
        }
    }
}
