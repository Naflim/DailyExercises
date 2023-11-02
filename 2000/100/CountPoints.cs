using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2103. 环和杆
    /// </summary>
    internal class CountPoints
    {
        public static int Run(string rings)
        {
            Dictionary<char, HashSet<char>> dic = new Dictionary<char, HashSet<char>>();
            char color = ' ';
            for (int i = 0; i < rings.Length; i++)
            {
                if (i % 2 == 0)
                {
                    color = rings[i];
                }
                else
                {
                    if (dic.ContainsKey(rings[i]))
                        dic[rings[i]].Add(color);
                    else
                        dic[rings[i]] = new HashSet<char> { color };
                }
            }

            return dic.Count(v => v.Value.Count == 3);
        }
    }
}
