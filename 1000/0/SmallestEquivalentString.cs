using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1061. 按字典序排列最小的等效字符串
    /// </summary>
    public class SmallestEquivalentString
    {
        private Dictionary<char, char> _unionFind;
        private string _str1;
        private string _str2;

        public SmallestEquivalentString(string str1, string str2) 
        {
            _unionFind = new Dictionary<char, char>();
            _str1 = str1;
            _str2 = str2;
        }

        public void InitUnionFind()
        {
            int len = _str1.Length;
            for (int i = 0; i < len; i++) 
            {
                Union(_str1[i], _str2[i]);
            }
        }

        public void Union(char arg1, char arg2)
        {
            var c1 = Find(arg1);
            var c2 = Find(arg2);
            if (!c1.Equals(c2))
            {
                if(c1 > c2)
                {
                    _unionFind[c1] = c2;
                }
                else
                {
                    _unionFind[c2] = c1;
                }
            }
        }

        public char Find(char arg)
        {
            if (_unionFind.ContainsKey(arg))
            {
                return _unionFind[arg] = Find(_unionFind[arg]);
            }

            return arg;
        }

        public static string Run(string s1, string s2, string baseStr)
        {
            SmallestEquivalentString equivalentString = new SmallestEquivalentString(s1, s2);
            equivalentString.InitUnionFind();
            string result = string.Empty;
            foreach(var c in baseStr)
            {
                result += equivalentString.Find(c);
            }

            return result;
        }
    }
}
