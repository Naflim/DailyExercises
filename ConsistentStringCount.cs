namespace DailyExercises
{
    /// <summary>
    /// 1684. 统计一致字符串的数目
    /// </summary>
    internal class ConsistentStringCount
    {
        public static int CountConsistentStrings(string allowed, string[] words)
        {
            int count = 0;
            for(int i = 0; i < words.Length; i++)
            {
                string str = new(words[i].Distinct().ToArray());
                if (str.Count(c => allowed.Contains(c)) == str.Length) count++;
            }

            return count;
        }
    }
}
