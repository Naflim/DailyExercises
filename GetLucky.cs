using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1945. 字符串转化后的各位数字之和
    /// </summary>
    internal class GetLucky
    {
        public static int Run(string s, int k)
        {
            string strNum = string.Empty;

            foreach (char c in s)
            {
                strNum += c - 96;
            }

            for(int i = 0; i<k; i++)
            {
                strNum = StringNumSum(strNum);
            }

            return Convert.ToInt32(strNum);
        }

        public static string StringNumSum(string s)
        {
            int count = 0;
            foreach (char c in s)
            {
                count += c - 48;
            }

            return count.ToString();
        }
    }
}
