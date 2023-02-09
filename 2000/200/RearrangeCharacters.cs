using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2287. 重排字符形成目标字符串
    /// </summary>
    public class RearrangeCharacters
    {
        public static int Run(string s, string target)
        {
            Dictionary<char, (int, int)> dic = new();

            foreach (var c in target)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c] = (dic[c].Item1+ 1, dic[c].Item2);
                }
                else
                {
                    dic[c] = (1, 0);
                }
            }

            foreach (var c in s) 
            {
                if (dic.ContainsKey(c))
                {
                    dic[c] = (dic[c].Item1, dic[c].Item2 + 1);
                }
            }

            int result = int.MaxValue;

            foreach (var val in dic.Values) 
            {
                result = Math.Min(result, val.Item2 / val.Item1);
            }

            return result;
        }
    }
}
