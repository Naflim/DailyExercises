using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1541. 平衡括号字符串的最少插入次数
    /// </summary>
    internal class MinInsertions2
    {
        public static int Run(string s)
        {
            int result = 0;
            int leftWeight = 0;

            foreach (char c in s)
            {
                if (c == '(')
                {
                    if(leftWeight % 2 > 0)
                    {
                        result += 1;
                        leftWeight -= 1;
                    }

                    leftWeight += 2;
                }
                else
                {
                    if(leftWeight > 0)
                    {
                        leftWeight -= 1;
                    }
                    else
                    {
                        result += 1;
                        leftWeight += 1;
                    }
                }
            }

            result += leftWeight;
            return result;
        }
    }
}
