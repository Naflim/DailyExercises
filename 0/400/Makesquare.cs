using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 473. 火柴拼正方形
    /// </summary>
    internal class Makesquare
    {
        public static bool Run(int[] matchsticks)
        {
            var sum = matchsticks.Sum();

            if (sum % 4 != 0)
                return false;

            var side = sum / 4;

            if (matchsticks.Any(x => x > side))
                return false;

            int target = 0;
            for (int i = 0; i < matchsticks.Length; i++)
            {
                target += 1 << i;
            }

            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < matchsticks.Length; i++)
            {
                if (GetState(matchsticks, 0, set, 0, i, side, target))
                    return true;
            }

            return false;
        }

        private static bool GetState(int[] matchsticks, int bin, HashSet<int> set, int count, int index, int side, int target)
        {
            var num = matchsticks[index];
            if (count + num > side)
                return false;

            count += num;
            bin += 1 << index;
            set.Add(bin);

            if (count == side)
            {
                if (bin == target)
                    return true;

                count = 0;
            }

            int len = matchsticks.Length;

            for (int i = 0; i < len; i++)
            {
                int mask = 1 << i;
                if ((bin & mask) != 0)
                    continue;

                int next = bin + mask;

                if (set.Contains(next))
                    continue;

                if (GetState(matchsticks, bin, set, count, i, side, target))
                    return true;
            }

            return false;
        }
    }
}
