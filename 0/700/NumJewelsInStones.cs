using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 771. 宝石与石头
    /// </summary>
    internal class NumJewelsInStones
    {
        public static int Run(string jewels, string stones)
        {
            HashSet<char> jewelHash = new HashSet<char>(jewels);
            int result = 0;
            foreach (var stone in stones)
            {
                if(jewelHash.Contains(stone))
                    result++;
            }

            return result;
        }
    }
}
