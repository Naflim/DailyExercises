using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2180. 统计各位数字之和为偶数的整数个数
    /// </summary>
    internal class CountEven
    {
        public static int Run(int num)
        {
            if (num < 2) return 0;
            int count = 0;
            for (int i = 2; i<=num; i++)
            {
                string strNum = i.ToString();

                int sum = 0;
                foreach (char n in strNum)
                {
                    sum += n - 48;
                }

                if (sum % 2 == 0) count++;
            }

            return count;
        }
    }
}
