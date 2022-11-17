using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 792. 匹配子序列的单词数
    /// </summary>
    internal class NumMatchingSubStr
    {
        public static int NumMatchingSubseq(string s, string[] words)
        {
            int count = 0;

            for (int i = 0; i<words.Length; i++)
            {
                if (ContainsSubseq(s, words[i])) count++;
            }
            return count;
        }

        public static bool ContainsSubseq(string s, string subseq)
        {
            int count = 0;
            for (int i = 0; i<s.Length; i++)
            {
                if (s[i] == subseq[count]) count++;
                if (count == subseq.Length) return true;
            }

            return false;
        }
    }
}
