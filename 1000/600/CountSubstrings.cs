using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1638. 统计只差一个字符的子串数目
    /// </summary>
    internal class CountSubstrings
    {
        public static int Run(string s, string t)
        {
            int len = Math.Min(s.Length, t.Length);
            int result = 0;

            //HashSet<string>[] sHash = GetSubStrings(s, len);
            //HashSet<string>[] tHash = GetSubStrings(t, len);

            //for (int i = 0; i < len; i++)
            //{
            //    foreach (string subS in sHash[i])
            //    {
            //        foreach (string subT in tHash[i])
            //        {
            //            if (GetDifferenceCount(subS, subT) == 1) result++;
            //        }
            //    }
            //}

            string[][] subS = GetSubStringArr(s);
            string[][] subT = GetSubStringArr(t);

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j<subS[i].Length; j++)
                {
                    for (int k = 0; k<subT[i].Length; k++)
                    {
                        if (GetDifferenceCount(subS[i][j], subT[i][k]) == 1) result++;
                    }
                }
            }

            return result;
        }

        public static HashSet<string>[] GetSubStrings(string s, int len)
        {
            HashSet<string>[] subStrings = new HashSet<string>[len];

            for (int i = 0; i <  len; i++)
            {
                subStrings[i] = new HashSet<string>();
                for (int j = 0; j < s.Length - i; j++)
                {
                    string sub = s.Substring(j, i + 1);
                    if (!subStrings[i].Contains(sub))
                        subStrings[i].Add(sub);
                }
            }

            return subStrings;
        }

        public static string[][] GetSubStringArr(string s)
        {
            string[][] subStrings = new string[s.Length][];

            for (int i = 0; i <  s.Length; i++)
            {
                subStrings[i] = new string[s.Length - i];
                for (int j = 0; j < subStrings[i].Length; j++)
                {
                    subStrings[i][j] = s.Substring(j, i + 1);
                }
            }

            return subStrings;
        }

        public static int GetDifferenceCount(string subA, string subB)
        {
            int al = subA.Length;
            int bl = subB.Length;

            if (al != bl) return -1;
            int result = 0;

            for (int i = 0; i < al; i++)
            {
                if (subA[i] != subB[i]) result++;
            }

            return result;
        }
    }
}
