using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 809. 情感丰富的文字
    /// </summary>
    internal class ExpressiveWords
    {
        public static int Run(string s, string[] words)
        {
            var dis = StringIntegration(s);
            int count = 0;

            for(int i=0; i<words.Length; i++)
            {
                var word = StringIntegration(words[i]);

                if (dis.Count != word.Count) continue;
                bool isOK = true;
                for(int j=0;j<dis.Count;j++) 
                {
                    if (!(dis[j].Item1 == word[j].Item1 && ((dis[j].Item2 > word[j].Item2 && dis[j].Item2 != 2) || dis[j].Item2 == word[j].Item2)))isOK= false;
                }

                if (isOK) count++;
            }
            return count;
        }

        public static string StringDistinct(string s,int ceiling) 
        {
            char last = char.MinValue;
            int mv = 0;
            int count = 0;
            string newStr = string.Empty;

            for (int i = 0; i<s.Length; i++)
            {
                char c = s[i];
                if (last == c) count++;
                else
                {
                    if (count > ceiling)
                    {
                        newStr = newStr.Remove(i - count - mv,count - 1);
                        mv += count - 1;
                    }
                    count = 1;
                }
                last = c;
                newStr += c;
            }

            if (count > ceiling)
            {
                newStr = newStr.Remove(s.Length - count - mv, count - 1);
            }

            return newStr;
        }

        public static List<(char, int)> StringIntegration(string s)
        {
            List<(char, int)> list = new();
            char last = char.MinValue;
            for (int i = 0; i<s.Length; i++)
            {
                char c = s[i];
                if (last == c)
                {
                    var listLast = list.Last();
                    list[^1] = (listLast.Item1, listLast.Item2 + 1);
                }
                else list.Add((c, 1));
                last = c;
            }

            return list;
        }
    }
}
