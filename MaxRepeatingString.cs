namespace DailyExercises
{
    /// <summary>
    /// 1668. 最大重复子字符串
    /// </summary>
    public class MaxRepeatingString
    {
        public static int MaxRepeating(string sequence, string word)
        {
            int k = 0;
            int wordLen = word.Length;
            int section = sequence.Length - wordLen + 1;
            int count = 0;
            for (int i = 0; i<section; i++)
            {
                string sub = new(sequence.Skip(i).Take(wordLen).ToArray());
                if (sub == word)
                {
                    count++;
                    i += wordLen - 1;
                }
                else if (count != 0)
                {
                    k = Math.Max(count, k);
                    count = 0;
                    i -= wordLen - 1;
                }
            }
            return Math.Max(count, k);
        }
    }
}
