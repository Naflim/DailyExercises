using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1048. 最长字符串链
    /// </summary>
    internal class LongestStrChain
    {
        public static int Run(string[] words)
        {
            SortedDictionary<int, List<string>> sort = new SortedDictionary<int, List<string>>();
            foreach (string word in words)
            {
                if (sort.ContainsKey(word.Length)) sort[word.Length].Add(word);
                else sort[word.Length] = new List<string> { word };
            }

            string[][] table = sort.Values.Select(v => v.ToArray()).ToArray();

            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i<table[0].Length; i++)
            {
                dic[table[0][i]] = 1;
            }

            for (int i = 1; i < table.Length; i++)
            {
                for (int j = 0; j<table[i].Length; j++)
                {
                    for (int k = 0; k < table[i][j].Length; k++)
                    {
                        string current = table[i][j];
                        string sub = current.Substring(0, k) + current.Substring(k+1, current.Length - k - 1);
                        if (dic.ContainsKey(sub))
                        {
                            if (dic.ContainsKey(current))
                            {
                                dic[current] = Math.Max(dic[current], dic[sub] + 1);
                            }
                            else
                            {
                                dic[current] = dic[sub] + 1;
                            }
                        }
                        else
                        {
                            if (!dic.ContainsKey(current))
                                dic[current] = 1;
                        }
                    }
                }
            }

            return dic.Values.Max();
        }
    }
}
