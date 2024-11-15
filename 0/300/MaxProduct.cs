using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 318. 最大单词长度乘积
    /// </summary>
    internal class MaxProduct
    {
        public static int Run(string[] words)
        {
            int len = words.Length;
            HashSet<char>[] hashs = words.Select(v => new HashSet<char>(v)).ToArray();

            int result = 0;
            for (int i = 0; i < len; i++) 
            {
                for (int j = 0; j < len; j++) 
                {
                    if (i == j || hashs[i].Overlaps(hashs[j]))
                        continue;

                    result = Math.Max(result, words[i].Length * words[j].Length);
                }
            }

            return result;
        }

        public static int Run2(string[] words)
        {
            int len = words.Length;
            int[] bins = words.Select(ToBin).ToArray();

            int result = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i == j || (bins[i] & bins[j]) != 0)
                        continue;

                    result = Math.Max(result, words[i].Length * words[j].Length);
                }
            }

            return result;
        }

        private static int ToBin(string word)
        {
            int result = 0;
            foreach (char c in word)
            {
                int num = c - 'a';
                result |= 1 << num;
            }

            return result;
        }
    }
}
