using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
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
