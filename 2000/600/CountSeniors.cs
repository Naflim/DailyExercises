using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2678. 老人的数目
    /// </summary>
    internal class CountSeniors
    {
        public static int Run(string[] details)
        {
            return details.Count(s => Convert.ToInt32(s[11..13]) > 60);
        }
    }
}
