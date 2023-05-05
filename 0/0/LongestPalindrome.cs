using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /*
     *  "babad"dp: 
     *  Left/Right	1	2	3	4	5
     *  1	        y	N	Y	N	Y
     *  2		        Y	N	Y	
     *  3			        Y	N	
     *  4				        Y	
     *  5					        Y
     */
    /// <summary>
    /// 5. 最长回文子串
    /// </summary>
    internal class LongestPalindrome
    {
        public static string Run(string s)
        {
            Dictionary<int, string> singular = new Dictionary<int, string>(), even = new Dictionary<int, string>();
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i+1]) even.Add(i, $"{s[i]}{s[i+1]}");
                singular[i] = s[i].ToString();
            }
            singular[s.Length - 1] = s.Last().ToString();

            string singularLon = GetLongestPalindrome(s, singular);
            string evenLon = GetLongestPalindrome(s, even);

            return evenLon.Length > singularLon.Length ? evenLon : singularLon;
        }

        public static (char start, char end) GetPeripheral(string source, int startIndex, int length)
        {
            return (source[startIndex - 1], source[startIndex + length]);
        }

        public static string GetLongerPalindrome(string source, int start, string palindrome)
        {
            if (start == 0)
            {
                return string.Empty;
            }
            else if (start == source.Length - palindrome.Length)
            {
                return string.Empty;
            }
            else
            {
                var peripheral = GetPeripheral(source, start, palindrome.Length);
                if (peripheral.start == peripheral.end)
                {
                    return $"{peripheral.start}{palindrome}{peripheral.end}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public static string GetLongestPalindrome(string source, Dictionary<int, string> dic)
        {
            string? result = default;
            while (dic.Count != 0)
            {
                result = dic.Values.Max();
                Dictionary<int, string> newDic = new Dictionary<int, string>();
                foreach (var item in dic)
                {
                    string longer = GetLongerPalindrome(source, item.Key, item.Value);
                    if (!string.IsNullOrEmpty(longer))
                        newDic[item.Key - 1] = longer;
                }
                dic = newDic;
            }
            return result ?? string.Empty;
        }
    }
}
