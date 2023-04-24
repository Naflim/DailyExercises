using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    internal class LastSubstring
    {
        //public static string Run(string s)
        //{
        //    SortedDictionary<char, List<int>> dic = new();

        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (dic.ContainsKey(s[i]))
        //        {
        //            if (s[i] != s[i-1]) dic[s[i]].Add(i);
        //        }
        //        else dic[s[i]] = new List<int> { i };
        //    }

        //    var pointers = dic.Values.Last().ToList();

        //    int index = 0;
        //    while (pointers.Count > 1)
        //    {
        //        for (int i = 0; i<pointers.Count; i++)
        //        {
        //            var val = pointers.Where(p => p + index < s.Length).Select(p => (p, s[p+index])).ToList();
        //            var max = val.Select(v => v.Item2).Max();
        //            pointers = val.Where(v => v.Item2 == max).Select(v => v.p).ToList();
        //        }

        //        index++;
        //    }

        //    return s[pointers[0]..];
        //}

        public static string Run(string s)
        {
            char maxC = char.MinValue;
            string result = string.Empty;
            int newPointer = -1;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >  maxC) 
                {
                    maxC = s[i];
                    result = maxC.ToString();
                    newPointer = -1;
                }else if (s[i] == maxC)
                {
                    newPointer = 0;
                    result += s[i];
                }
                else
                {
                    if(newPointer == -1)
                    {
                        result += s[i];
                    }
                    else
                    {
                        if (result[newPointer + 1] > s[i])
                        {
                            result += s[i];
                            newPointer = -1;
                        }else if(result[newPointer + 1] == s[i])
                        {
                            result += s[i];
                            newPointer++;
                        }
                        else
                        {
                            result = result[..(newPointer+1)] + s[i];
                            newPointer = -1;
                        }
                    }
                }
            }

            return result;
        }
    }
}
