using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 187. 重复的DNA序列
    /// </summary>
    internal class FindRepeatedDnaSequences
    {
        public static IList<string> Run(string s)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            int len = s.Length;

            for (int i = 10; i <= len; i++)
            {
                string sub = s[(i - 10)..i];

                if (map.TryGetValue(sub, out int value))
                    map[sub] = ++value;
                else
                    map[sub] = 1;
            }

            return map.Where(v => v.Value > 1).Select(v => v.Key).ToList();
        }

        public static IList<string> Run2(string s)
        {
            if (s.Length < 10)
                return [];

            List<char> sub = new List<char>(s[..10]);
            Dictionary<string, int> map = new Dictionary<string, int>();
            map[new string(sub.ToArray())] = 1;

            for (int i = 10; i < s.Length; i++)
            {
                sub.RemoveAt(0);
                sub.Add(s[i]);

                string strSub = new string(sub.ToArray());

                if (map.TryGetValue(strSub, out int value))
                    map[strSub] = ++value;
                else
                    map[strSub] = 1;
            }

            return map.Where(v => v.Value > 1).Select(v => v.Key).ToList();
        }
    }
}
