using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2810. 故障键盘
    /// </summary>
    internal class FinalString
    {
        public static string Run(string s)
        {
            List<char> chars = new List<char>();
            foreach (char c in s) 
            {
                if(c == 'i')
                {
                    chars.Reverse();
                }
                else
                {
                    chars.Add(c);
                }
            }

            return new string(chars.ToArray());
        }
    }
}
