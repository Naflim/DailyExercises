using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2451. 差值数组不同的字符串
    /// </summary>
    internal class OddString
    {
        public static string Run(string[] words)
        {
            int[] a = GetInts(words[0]);
            int[] b = GetInts(words[1]);

            if(Enumerable.SequenceEqual(a, b))
            {
                for (int i = 2; i < words.Length; i++)
                {
                    if (!Enumerable.SequenceEqual(a, GetInts(words[i])))
                    {
                        return words[i];
                    }
                }

                return string.Empty;
            }
            else
            {
                return Enumerable.SequenceEqual(a, GetInts(words[2]))? words[1] : words[0];
            }
        }

        private static int[] GetInts(string str)
        {
            int[] ints = new int[str.Length - 1];
            for (int i = 0; i < ints.Length; i++) 
            {
                ints[i] = str[i + 1] - str[i];
            }

            return ints;
        } 
    }
}
