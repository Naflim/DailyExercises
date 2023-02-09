using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1807. 替换字符串中的括号内容
    /// </summary>
    public class AlternateParenthesis
    {
        public static string Run(string s, IList<IList<string>> knowledge)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (var item in knowledge) dic[item[0]] = item[1];

            Dictionary<int, string> paragraphs = new Dictionary<int, string>();
            Dictionary<int, string> parenthesis = new Dictionary<int, string>();

            string paragraph = string.Empty;
            int len = 0;
            foreach (var c in s)
            {
                if (c == '(')
                {
                    if (!string.IsNullOrEmpty(paragraph)) paragraphs[len] = paragraph;
                    len++;
                    paragraph = string.Empty;
                }
                else if (c == ')')
                {
                    parenthesis[len] = paragraph;
                    len++;
                    paragraph = string.Empty;
                }
                else
                {
                    paragraph += c;
                }
            }

            if (!string.IsNullOrEmpty(paragraph)) paragraphs[len] = paragraph;
            len++;

            foreach (var item in parenthesis) 
            {
                parenthesis[item.Key] = dic.ContainsKey(item.Value) ? dic[item.Value] : "?";
            }

            string result = string.Empty;

            for (int i = 0; i < len; i++)
            {
                if (parenthesis.ContainsKey(i)) result += parenthesis[i];
                else if (paragraphs.ContainsKey(i)) result += paragraphs[i];
            }

            return result;
        }
    }
}
