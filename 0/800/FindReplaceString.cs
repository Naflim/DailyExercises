using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 833. 字符串中的查找与替换
    /// </summary>
    internal class FindReplaceString
    {
        public static string Run(string s, int[] indices, string[] sources, string[] targets)
        {
            Sort(indices, sources, targets);
            List<string> strs = new List<string>();   
            int pointer = 0;

            for (int i = 0; i < indices.Length; i++)
            {
                var indice = indices[i];
                var source = sources[i];
                if (indice + source.Length > s.Length)
                    continue;

                if (s[indice..(indice + source.Length)] == source)
                {
                    strs.Add(s[pointer..indice]);
                    strs.Add(targets[i]);
                    pointer = indice + source.Length;
                }
            }

            strs.Add(s[pointer..]);
            string result = string.Empty;
            strs.ForEach(str => result += str);

            return result;
        }

        public static void Sort(int[] indices, string[] sources, string[] targets)
        {
            int len = indices.Length;
            (int, string, string)[] sortList = new (int, string, string)[len];
            for (int i = 0; i < len; i++)
            {
                sortList[i] = (indices[i], sources[i], targets[i]);
            }

            sortList = sortList.OrderBy(v => v.Item1).ToArray();

            for (int i = 0; i < len; i++)
            {
                var item = sortList[i];
                indices[i] = item.Item1;
                sources[i] = item.Item2;
                targets[i] = item.Item3;
            }
        }
    }
}
