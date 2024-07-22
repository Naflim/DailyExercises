using DailyExercises.Utils;
using Naflim.DevelopmentKit.DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace DailyExercises
{
    /// <summary>
    /// 2101. 引爆最多的炸弹
    /// </summary>
    internal class MaximumDetonation
    {
        public static int Run(int[][] bombs)
        {
            List<List<int[]>> groups = new List<List<int[]>>();

            foreach (var bomb in bombs)
            {
                List<List<int[]>> chainGroups = new List<List<int[]>>();

                foreach (var group in groups)
                {
                    if (HasChain(group, bomb))
                    {
                        chainGroups.Add(group);
                    }
                }

                if(chainGroups.Any())
                {
                    List<int[]> group = new List<int[]>();
                    foreach(var chainGroup in chainGroups)
                    {
                        groups.Remove(chainGroup);
                        group.AddRange(chainGroup);
                    }

                    group.Add(bomb);
                    groups.Add(group);
                }
                else
                {
                    groups.Add(new List<int[]> { bomb });
                }
            }

            return groups.Max(v => v.Count);
        }

        public static bool HasChain(IEnumerable<int[]> bombs, int[] bomb)
        {
            return bombs.Any(b =>
            {
                int max = Math.Max(b[2], bomb[2]);
                var dis = MathUtils.GetDistance(b[0], b[1], bomb[0], bomb[1]);
                return max >= dis;
            });
        }

        public static int Run2(int[][] bombs)
        {
            int len = bombs.Length;

            bool[,] matrix = new bool[len, len];

            for (int i = 0; i < len; i++)
            {
                var source = bombs[i];
                for (int j = 0; j < len; j++)
                {
                    var obj = bombs[j];
                    var dis = MathUtils.GetDistance(source[0], source[1], obj[0], obj[1]);
                    if (source[2] >= dis)
                        matrix[i, j] = true;
                }
            }

            int result = 0;

            for (int i = 0; i < len; i++)
            {
                Graph<int> g = new Graph<int>(i, v =>
                {
                    List<int> next = new List<int>();
                    for (int j = 0; j < len; j++) 
                    {
                        if (v == j)
                            continue;

                        if(matrix[v, j])
                            next.Add(j);
                    }

                    return next;
                });

                result = Math.Max(result, g.Count);
            }

            return result;
        }
    }
}
