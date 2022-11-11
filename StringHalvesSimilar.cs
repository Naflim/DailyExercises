using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1704. 判断字符串的两半是否相似
    /// </summary>
    internal class StringHalvesSimilar
    {
        public static bool HalvesAreAlike(string s)
        {
            char[] vowels = new char[] { 'a','e','i','o','u','A','E','I','O','U' };
            int half = s.Length / 2;
            string a = new(s.Take(half).ToArray());
            string b = new(s.Skip(half).Take(half).ToArray());
            return a.Count(c => vowels.Contains(c)) ==  b.Count(c => vowels.Contains(c));
        }
    }
}
