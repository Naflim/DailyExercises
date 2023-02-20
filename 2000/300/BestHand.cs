using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2347. 最好的扑克手牌
    /// </summary>
    internal class BestHand
    {
        public static string Run(int[] ranks, char[] suits)
        {
            Dictionary<int,int>rankDic = new Dictionary<int,int>();
            Dictionary<char,int> suitDic = new Dictionary<char,int>();

            foreach (int rank in ranks) 
            {
                if (rankDic.ContainsKey(rank)) rankDic[rank]++;
                else rankDic[rank] = 1;
            }

            foreach (char suit in suits) 
            {
                if (suitDic.ContainsKey(suit)) suitDic[suit]++;
                else suitDic[suit] = 1;
            }

            if (suitDic.Values.Count(v => v >= 5) > 0) return "Flush";
            else if (rankDic.Values.Count(v => v >= 3) > 0) return "Three of a Kind";
            else if (rankDic.Values.Count(v => v == 2) > 0) return "Pair";
            else return "High Card";
        }
    }
}
