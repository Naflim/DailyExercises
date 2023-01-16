using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1813. 句子相似性 III
    /// </summary>
    internal class AreSentencesSimilar
    {
        //public static bool Run(string sentence1, string sentence2)
        //{
        //    List<string> words1 = new List<string>();
        //    List<string> words2 = new List<string>();
        //    string word = string.Empty;

        //    void AddWord(string sentence, List<string> words)
        //    {
        //        for (int i = 0; i < sentence.Length; i++)
        //        {
        //            char c = sentence[i];
        //            if (char.IsLetter(sentence[i])) word += c;
        //            else
        //            {
        //                if (!string.IsNullOrEmpty(word))
        //                {
        //                    words.Add(word);
        //                    word = string.Empty;
        //                }
        //            }
        //        }

        //        if (!string.IsNullOrEmpty(word))
        //        {
        //            words.Add(word);
        //            word = string.Empty;
        //        }
        //    }

        //    AddWord(sentence1, words1);
        //    AddWord(sentence2, words2);

        //    if (words1.Count > words2.Count)
        //    {
        //        if (JudgeSimilarity(words1, words2)) return true;
        //        else
        //        {
        //            words1.Reverse();
        //            words2.Reverse();
        //            return JudgeSimilarity(words1, words2);
        //        }
        //    }
        //    else if (words1.Count < words2.Count)
        //    {
        //        if (JudgeSimilarity(words2, words1)) return true;
        //        else
        //        {
        //            words1.Reverse();
        //            words2.Reverse();
        //            return JudgeSimilarity(words2, words1);
        //        }
        //    }
        //    else return words1.SequenceEqual(words2);

        //}

        public static bool Run(string sentence1, string sentence2)
        {

            string[] words1 = sentence1.Split(' ');
            string[] words2 = sentence2.Split(' ');

            if (words1.Length > words2.Length)
            {
                int left = GetSimilarQuantity(words1,words2);
                Array.Reverse(words1);
                Array.Reverse(words2);
                int right = GetSimilarQuantity(words1,words2);
                return left + right  >= words2.Length;

            }
            else if (words1.Length < words2.Length)
            {
                int left = GetSimilarQuantity(words2, words1);
                Array.Reverse(words1);
                Array.Reverse(words2);
                int right = GetSimilarQuantity(words2, words1);
                return left + right  >= words1.Length;
            }
            else return words1.SequenceEqual(words2);

        }

        public static bool JudgeSimilarity(IList<string> longWords, IList<string> shortWords)
        {
            int differencesCount = 0;
            int equalIndex = -1;
            int shortIndex = 0;

            for (int i = 0; i < longWords.Count; i++)
            {
                if (shortIndex >= shortWords.Count)
                {
                    differencesCount++;
                    break;
                }

                if (longWords[i] == shortWords[shortIndex])
                {
                    shortIndex++;
                    equalIndex = i;
                }
                else
                {
                    if (equalIndex == i - 1) differencesCount++;
                }
            }

            if(shortIndex < shortWords.Count)differencesCount++;

            if (equalIndex == -1) return false;
            return differencesCount < 2;
        }

        public static int GetSimilarQuantity(IList<string> longWords, IList<string> shortWords)
        {
            int quantity = 0;

            for (int i = 0; i < shortWords.Count; i++)
            {
                if (longWords[i] == shortWords[i]) quantity++;
                else break;
            }

            return quantity;
        }
    }
}
