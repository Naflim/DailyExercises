using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1021. 删除最外层的括号
    /// </summary>
    internal class RemoveOuterParentheses
    {
        public static string Run(string s)
        {
            List<char> result = new(s);
            List<int> indexs = [];

            int index = 0;
            for (int i = 0; i < result.Count; i++) 
            {                
                if(result[i] == '(')
                {
                    if (index == 0)
                    {
                        indexs.Add(i);
                    }
                    index++;
                }
                else
                {
                    index--;
                    if(index == 0)
                    {
                        indexs.Add(i);
                    }
                }
            }

            for (int i = indexs.Count - 1; i >= 0; i--)
            {
                result.RemoveAt(indexs[i]);
            }

            return new string(result.ToArray());
        }
    }
}
