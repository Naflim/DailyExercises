using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2490. 回环句
    /// </summary>
    internal class IsCircularSentence
    {
        public static bool Run(string sentence)
        {
            string[] words = sentence.Split(' ');
            bool isCircularSentence = true;
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (words[i][^1] != words[i + 1][0])
                    isCircularSentence = false;
            }

            return isCircularSentence && sentence[0] == sentence[^1];
        }
    }
}
