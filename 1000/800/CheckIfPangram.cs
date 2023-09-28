using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1832. 判断句子是否为全字母句
    /// </summary>
    internal class CheckIfPangram
    {
        public static bool Run(string sentence)
        {
            string table = string.Empty;

            foreach(var c in sentence) 
            {
                if(!table.Contains(c)) table += c;
            }

            return table.Length == 26;
        }
    }
}
