using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1234. 替换子串得到平衡字符串
    /// </summary>
    internal class BalancedString
    {
        public int Run(string s)
        {
            int[] cnt = new int[26];
            foreach (char c in s)
            {
                cnt[Idx(c)]++;
            }

            int partial = s.Length / 4;
            int res = s.Length;

            if (Check(cnt, partial))
            {
                return 0;
            }
            for (int l = 0, r = 0; l < s.Length; l++)
            {
                while (r < s.Length && !Check(cnt, partial))
                {
                    cnt[Idx(s[r])]--;
                    r++;
                }
                if (!Check(cnt, partial))
                {
                    break;
                }
                res = Math.Min(res, r - l);
                cnt[Idx(s[l])]++;
            }
            return res;
        }

        public int Idx(char c)
        {
            return c - 'A';
        }

        public bool Check(int[] cnt, int partial)
        {
            if (cnt[Idx('Q')] > partial || cnt[Idx('W')] > partial || cnt[Idx('E')] > partial || cnt[Idx('R')] > partial)
            {
                return false;
            }
            return true;
        }

        //public static int Run(string s)
        //{
        //    Dictionary<char, int> charSet = GetStrDic(s);
        //    int len = s.Length / 4;
        //    if (charSet.Values.Count(v => v==0) == 3) return len * 3;

        //    Dictionary<char, int> exceed = new();
        //    foreach (var item in charSet)
        //    {
        //        if (len < item.Value) exceed[item.Key] = item.Value - len;
        //    }

        //    int count = exceed.Values.Sum(), strLen = s.Length;

        //    Dictionary<char, int>[] strArr = new Dictionary<char, int>[strLen - count + 1];
        //    int strDicLen = strArr.Length;
        //    for (int i = 0; i < strDicLen; i++) strArr[i] = GetStrDic(s[i..(i+count)]);

        //    while (count < strLen)
        //    {
        //        for (int i = 0; i < strLen + 1 - count; i++)
        //        {
        //            if (CheckCanBalanced(exceed, strArr[i])) 
        //            {
        //                return count;
        //            }
        //            else
        //            {
        //                int countIndex = i + count;
        //                if (countIndex  < strLen) strArr[i][s[countIndex]]++;
        //            }
        //        }

        //        count++;
        //    }

        //    return s.Length;
        //}

        //public static int Run(string s)
        //{
        //    Dictionary<char, int> charSet = new()
        //    {
        //        { 'Q',0},
        //        { 'W',0},
        //        { 'E',0},
        //        { 'R',0}
        //    };

        //    foreach (char c in s)
        //    {
        //        if (charSet.ContainsKey(c)) charSet[c]++;
        //    }

        //    int len = s.Length / 4;

        //    Dictionary<char, int> exceed = new();
        //    foreach (var item in charSet)
        //    {
        //        if (len < item.Value) exceed[item.Key] = item.Value - len;
        //    }

        //    int count = exceed.Values.Sum(), strLen = s.Length;

        //    while (count < strLen)
        //    {
        //        for (int i = 0; i < strLen + 1 - count; i++)
        //        {
        //            if (CheckCanBalanced(exceed, s[i..(i+count)]))
        //            {
        //                return count;
        //            }
        //        }

        //        count++;
        //    }

        //    return s.Length;
        //}

        public static Dictionary<char, int> GetStrDic(string str)
        {
            Dictionary<char, int> charSet = new()
            {
                { 'Q',0},
                { 'W',0},
                { 'E',0},
                { 'R',0}
            };

            foreach (char c in str)
            {
                if (charSet.ContainsKey(c)) charSet[c]++;
            }

            return charSet;
        }

        public static bool CheckCanBalanced(Dictionary<char, int> exceed, IEnumerable<char> str)
        {
            Dictionary<char, int> copy = new();
            foreach (var item in exceed)
            {
                copy[item.Key] = item.Value;
            }

            foreach (char c in str)
            {
                if (copy.ContainsKey(c)) copy[c]--;
            }

            return copy.Values.Count(v => v<=0) == exceed.Count;
        }

        public static bool CheckCanBalanced(Dictionary<char, int> exceed, Dictionary<char, int> str)
        {
            foreach (var item in exceed)
            {
                if (str.ContainsKey(item.Key))
                {
                    if (str[item.Key] < exceed[item.Key]) return false;
                }
                else return false;
            }

            return true;
        }
    }
}
