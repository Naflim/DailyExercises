using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 839. 相似字符串组
    /// </summary>
    internal class NumSimilarGroups
    {
        private HashSet<char>[] _unionFind;

        public HashSet<char> Hash { get; }

        public List<string> Origins { get; set; }

        public string Origin { get; set; }


        public NumSimilarGroups(string str)
        {
            Origin = str;
            Hash = new HashSet<char>(str);
            Origins = new List<string> { str };
            int len = str.Length;
            _unionFind = new HashSet<char>[len];
            for (int i = 0; i < len; i++)
            {
                _unionFind[i] = new HashSet<char> { str[i] };
            }
        }


        public static int Run(string[] strs)
        {
            var numSimilarGroups = strs.Select(s => new NumSimilarGroups(s));
            List<List<NumSimilarGroups>> groups = new();

            foreach (var group in numSimilarGroups)
            {
                if (groups.Find(g => g.Any(v => v.Hash.SetEquals(group.Hash))) is List<NumSimilarGroups> list)
                {
                    list.Add(group);
                }
                else
                {
                    groups.Add(new List<NumSimilarGroups> { group });
                }
            }

            return groups.Select(g => Union(g)).Sum(g => g.Count);
        }

        public static int Run2(string[] strs)
        {
            var numSimilarGroups = strs.Select(s => (s,new HashSet<char>(s)));
            List<List<(string, HashSet<char>)>> groups = new();

            foreach (var group in numSimilarGroups)
            {
                if (groups.Find(g => g.Any(v => v.Item2.SetEquals(group.Item2))) is List<(string, HashSet<char>)> list)
                {
                    list.Add(group);
                }
                else
                {
                    groups.Add(new List<(string, HashSet<char>)> { group });
                }
            }

            return groups.Select(g => Union2(g)).Sum(g => g.Count);
        }

        public static bool IsSimilar((string, HashSet<char>) item1, (string, HashSet<char>) item2)
        {
            if (!item1.Item2.SetEquals(item2.Item2))
                return false;

            int count = 0;
            int len = item1.Item1.Length;
            for (int i = 0; i < len; i++)
            {
                if (item1.Item1[i] != item2.Item1[i])
                    count++;

                if(count > 2)
                    return false;
            }

            return true;
        }

        public static Queue<NumSimilarGroups> Union(IEnumerable<NumSimilarGroups> group)
        {
            Queue<NumSimilarGroups> queue = new Queue<NumSimilarGroups>(group);

            int count = 0;
            while (queue.Count != count)
            {
                var val = queue.Dequeue();

                bool isUnion = false;
                foreach (var item in queue)
                {
                    if (item.Union(val))
                    {
                        isUnion = true;
                        count = 0;
                        break;
                    }
                }

                if (!isUnion)
                {
                    queue.Enqueue(val);
                    count++;
                }
            }

            return queue;
        }

        public static List<Graph<NumSimilarGroupsNode>> Union2(IEnumerable<(string,HashSet<char>)> group)
        {
            Dictionary<string, HashSet<string>> adjacencyList = new Dictionary<string, HashSet<string>>();

            IList<(string, HashSet<char>)> groups;
            if (group is IList<(string, HashSet<char>)> list)
                groups = list;
            else
                groups = group.ToList();

            int len = groups.Count;
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (IsSimilar(groups[i], groups[j]))
                    {
                        var iVal = groups[i].Item1;
                        var jVal = groups[j].Item1;
                        if (adjacencyList.ContainsKey(iVal))
                            adjacencyList[iVal].Add(jVal);
                        else
                            adjacencyList[iVal] = new HashSet<string> { jVal };

                        if (adjacencyList.ContainsKey(jVal))
                            adjacencyList[jVal].Add(iVal);
                        else
                            adjacencyList[jVal] = new HashSet<string> { iVal };
                    }
                }
            }

            List<Graph<NumSimilarGroupsNode>> result = new List<Graph<NumSimilarGroupsNode>>();
            HashSet<NumSimilarGroupsNode> visited = new HashSet<NumSimilarGroupsNode>();
            foreach(var item in groups)
            {
                NumSimilarGroupsNode node = new NumSimilarGroupsNode(item.Item1, adjacencyList);
                if (visited.Contains(node))
                    continue;

                Graph<NumSimilarGroupsNode> graph = new Graph<NumSimilarGroupsNode>(node);
                graph.StartRetrieval();
                result.Add(graph);
                visited.UnionWith(graph);
            }

            return result;
        }

        public bool Union(NumSimilarGroups other)
        {
            if (!other.Hash.SetEquals(Hash) || other.Origins.Count > 1)
                return false;

            int len = _unionFind.Length;

            List<int> equal = new List<int>();
            for (int i = 0; i < len; i++)
            {
                if (!_unionFind[i].Overlaps(other._unionFind[i]))
                    equal.Add(i);
            }

            if (equal.Count > 2)
                return false;

            equal.ForEach(i => _unionFind[i].UnionWith(other._unionFind[i]));

            Origins.AddRange(other.Origins);

            return true;
        }
    }

    public class NumSimilarGroupsNode : IGraphNode<NumSimilarGroupsNode>
    {
        private Dictionary<string, HashSet<string>> _adjacencyList;

        public NumSimilarGroupsNode(string origin, Dictionary<string, HashSet<string>> adjacencyList)
        {
            _adjacencyList = adjacencyList;
            Origin = origin;
        }

        public string Origin { get; }

        public NumSimilarGroupsNode[] GetNextNodes()
        {
            if(!_adjacencyList.ContainsKey(Origin))
                return new NumSimilarGroupsNode[0];

            return _adjacencyList[Origin].Select(v => new NumSimilarGroupsNode(v, _adjacencyList)).ToArray();
        }

        public override bool Equals(object? obj)
        {
            if (obj is NumSimilarGroupsNode node)
            {
                return node.Origin == Origin;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Origin.GetHashCode();
        }
    }
}
