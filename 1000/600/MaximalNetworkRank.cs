using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1615. 最大网络秩
    /// </summary>
    internal class MaximalNetworkRank
    {
        public static int Run(int n, int[][] roads)
        {
            (int, HashSet<int>)[] table = new (int, HashSet<int>)[n];
            for (int i = 0; i < n; i++)
            {
                table[i] = (i, new HashSet<int>());
            }

            for (int i = 0;i < roads.Length; i++)
            {
                var road = roads[i];
                var a = road[0];
                var b = road[1];
                table[a].Item2.Add(b);
                table[b].Item2.Add(a);
            }
             
            var sort = table.GroupBy(v => v.Item2.Count).OrderBy(v => v.Key).Reverse();
            int count = 0;
            (int, HashSet<int>)[][] cache = new (int, HashSet<int>)[2][];
            foreach (var item in sort)
            {
                if (count > 1)
                    break;

                cache[count] = item.ToArray();
                count++;
            }

            var refNode = cache[0][0].Item1;
            var refHash = cache[0][0].Item2;
            if (cache[0].Length > 1)
            {
                int len = cache[0].Length;
                for (int i = 0; i < len; i++)
                {
                    for (int j = i + 1; j < len; j++)
                    {
                        if (!cache[0][j].Item2.Contains(cache[0][i].Item1))
                            return refHash.Count * 2;
                    }
                }

                return refHash.Count * 2 - 1;
            }
            else
            {
                foreach (var item in cache[1])
                {
                    var hash = item.Item2;
                    if (!hash.Contains(refNode))
                        return refHash.Count + hash.Count;
                }

                return refHash.Count + cache[1][0].Item2.Count - 1;
            }
        }
    }
}
