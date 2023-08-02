using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 822. 翻转卡片游戏
    /// </summary>
    internal class Flipgame
    {
        public static int Run(int[] fronts, int[] backs)
        {
            List<(int front, int back)> cards = new List<(int front, int back)>();

            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < fronts.Length; i++)
            {
                if (fronts[i] == backs[i])
                    set.Add(fronts[i]);
                else
                    cards.Add((fronts[i], backs[i]));
            }

            for (int i = 0; i < cards.Count; i++)
            {
                if (set.Contains(cards[i].front))
                {
                    cards[i] = (int.MaxValue, cards[i].back);
                }

                if (set.Contains(cards[i].back))
                {
                    cards[i] = (cards[i].front, int.MaxValue);
                }

            }

            cards = cards
                .Where(c => c.front != c.back)
                .OrderBy(c => Math.Min(c.front, c.back)).ToList();

            int result = 0;
            if (cards.Count > 0)
                result = Math.Min(cards[0].front, cards[0].back);

            return result;
        }
    }
}
