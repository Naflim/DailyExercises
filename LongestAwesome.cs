using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    internal class LongestAwesome
    {
        public static int Run(string s)
        {
            int result = 0; 
            int len = s.Length;

            for (int i = 0; i < len; i++)
            {
                Dictionary<char,int> dic = new Dictionary<char,int>();
                HashSet<char> odd = new HashSet<char>();
                for (int j = i; j < len; j++) 
                {
                    char c = s[j];
                    if (dic.ContainsKey(c))
                    {
                        dic[c]++;
                        if (dic[c] % 2 == 0)
                            odd.Remove(c);
                        else
                            odd.Add(c);
                    }
                    else
                    {
                        dic[c] = 1;
                        odd.Add(c);
                    }

                    if (odd.Count < 2)
                    {
                        result = Math.Max(result, j + 1 - i);
                    }
                }
            }

            return result;
        }
    }
}
