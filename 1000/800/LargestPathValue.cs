using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1857. 有向图中最大颜色值
    /// </summary>
    internal class LargestPathValue
    {
        public static int Run(string colors, int[][] edges)
        {
            int n = colors.Length;
            List<int>[] adjacencyList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adjacencyList[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                adjacencyList[edge[0]].Add(edge[1]);
            }


            string[] colorArr = new string[n];
            int[] unionFind = new int[n];
            for (int i = 0; i < n; i++)
            {
                colorArr[i] = colors[i].ToString();
                unionFind[i] = i;
            }

            if (IsAOV(unionFind, colorArr, adjacencyList))
            {
                int result = 0;
                foreach (var color in colorArr)
                {
                    var max = color.GroupBy(v => v).Max(v => v.Count());
                    result = Math.Max(result, max);
                }

                return result;
            }
            else
            {
                return -1;
            }
        }

        public static bool IsAOV(int[] unionFind, string[] colors, List<int>[] adjacencyList)
        {
            int len = adjacencyList.Length;
            List<int>[] inverseAdjacencyList = new List<int>[len];
            for (int i = 0; i < len; i++)
            {
                inverseAdjacencyList[i] = new List<int>();
            }
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < adjacencyList[i].Count; j++)
                {
                    inverseAdjacencyList[adjacencyList[i][j]].Add(i);
                }
            }

            for (int i = 0; i < len; i++)
            {
                var index = FindNodeOfNoneInDegree(inverseAdjacencyList);
                if (index == -1)
                    return false;

                Remove4AOV(unionFind, inverseAdjacencyList, index, colors);
            }

            return true;
        }


        public static int FindNodeOfNoneInDegree(List<int>[] inverseAdjacencyList)
        {
            return Array.FindIndex(inverseAdjacencyList, v => v.Count == 0);
        }

        public static void Remove4AOV(int[] unionFind, List<int>[] inverseAdjacencyList, int node, string[] colors)
        {
            for (int i = 0; i < inverseAdjacencyList.Length; i++)
            {
                if (inverseAdjacencyList[i].Remove(node))
                {
                    if (unionFind[node] == unionFind[i])
                    {
                        colors[i] = colors[node] + colors[i].Last();
                    }
                    else
                    {
                        colors[i] = colors[node] + colors[i];
                        unionFind[i] = unionFind[node];
                    }
                }
            }

            inverseAdjacencyList[node].Add(node);
        }

        public static int Run2(string colors, int[][] edges)
        {
            int n = colors.Length;
            List<int>[] adjacencyList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adjacencyList[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                adjacencyList[edge[0]].Add(edge[1]);
            }

            Dictionary<char, int>[] dp = new Dictionary<char, int>[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new Dictionary<char, int>();
                dp[i][colors[i]] = 1;
            }

            if (IsAOV(dp, adjacencyList, colors))
            {
                int result = 0;
                foreach (var map in dp)
                {
                    result = Math.Max(result, map.Values.Max());
                }

                return result;
            }
            else
            {
                return -1;
            }
        }

        public static int Run3(string colors, int[][] edges)
        {
            int n = colors.Length;
            List<int>[] adjacencyList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adjacencyList[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                adjacencyList[edge[0]].Add(edge[1]);
            }

            Dictionary<char, int>[] dp = new Dictionary<char, int>[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new Dictionary<char, int>();
                dp[i][colors[i]] = 1;
            }

            if (IsAOV3(dp, adjacencyList, colors))
            {
                int result = 0;
                foreach (var map in dp)
                {
                    result = Math.Max(result, map.Values.Max());
                }

                return result;
            }
            else
            {
                return -1;
            }
        }

        public static bool IsAOV(Dictionary<char, int>[] dp, List<int>[] adjacencyList, string colors)
        {
            int len = adjacencyList.Length;
            HashSet<int>[] inverseAdjacencyList = new HashSet<int>[len];
            for (int i = 0; i < len; i++)
            {
                inverseAdjacencyList[i] = new HashSet<int>();
            }
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < adjacencyList[i].Count; j++)
                {
                    inverseAdjacencyList[adjacencyList[i][j]].Add(i);
                }
            }

            for (int i = 0; i < len;)
            {
                var indexs = FindAllNodeOfNoneInDegree(inverseAdjacencyList);
                if (indexs.Count == 0)
                    return false;

                foreach (var index in indexs)
                    Remove4AOV2(dp, inverseAdjacencyList, adjacencyList, index, colors);

                i += indexs.Count;
                Console.WriteLine(i);
            }

            return true;
        }

        public static bool IsAOV2(Dictionary<char, int>[] dp, List<int>[] adjacencyList, string colors)
        {
            int len = adjacencyList.Length;
            Dictionary<int, HashSet<int>> inverseAdjacencyList = new Dictionary<int, HashSet<int>>(len);
            for (int i = 0; i < len; i++)
            {
                inverseAdjacencyList[i] = new HashSet<int>();
            }
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < adjacencyList[i].Count; j++)
                {
                    inverseAdjacencyList[adjacencyList[i][j]].Add(i);
                }
            }

            for (int i = 0; i < len;)
            {
                var indexs = FindAllNodeOfNoneInDegree(inverseAdjacencyList);
                if (indexs.Count == 0)
                    return false;

                foreach (var index in indexs)
                    Remove4AOV2(dp, inverseAdjacencyList, adjacencyList, index, colors);

                i += indexs.Count;
                Console.WriteLine(i);
            }

            return true;
        }

        public static bool IsAOV3(Dictionary<char, int>[] dp, List<int>[] adjacencyList, string colors)
        {
            int len = adjacencyList.Length;
            Dictionary<int, HashSet<int>> inverseAdjacencyList = new Dictionary<int, HashSet<int>>(len);
            for (int i = 0; i < len; i++)
            {
                inverseAdjacencyList[i] = new HashSet<int>();
            }
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < adjacencyList[i].Count; j++)
                {
                    inverseAdjacencyList[adjacencyList[i][j]].Add(i);
                }
            }

            for (int i = 0; i < len; i++)
            {
                var index = FindNodeOfNoneInDegree(inverseAdjacencyList);
                if (index == -1)
                    return false;

                Remove4AOV2(dp, inverseAdjacencyList, adjacencyList, index, colors);
                //Console.WriteLine(i);
            }

            return true;
        }

        public static void Remove4AOV(Dictionary<char, int>[] dp, HashSet<int>[] inverseAdjacencyList, int node, string colors)
        {
            for (int i = 0; i < inverseAdjacencyList.Length; i++)
            {
                if (inverseAdjacencyList[i].Remove(node))
                {
                    Dictionary<char, int> map = new Dictionary<char, int>(dp[node]);
                    if (map.ContainsKey(colors[i]))
                        map[colors[i]]++;
                    else
                        map[colors[i]] = 1;

                    var nowMap = dp[i];
                    foreach (var item in map)
                    {
                        if (nowMap.ContainsKey(item.Key))
                        {
                            nowMap[item.Key] = Math.Max(item.Value, nowMap[item.Key]);
                        }
                        else
                        {
                            nowMap[item.Key] = item.Value;
                        }
                    }
                }
            }

            inverseAdjacencyList[node].Add(node);
        }

        public static void Remove4AOV(Dictionary<char, int>[] dp, HashSet<int>[] inverseAdjacencyList, List<int>[] adjacencyList, int node, string colors)
        {
            var indexs = adjacencyList[node];
            foreach (var i in indexs)
            {
                if (inverseAdjacencyList[i].Remove(node))
                {
                    Dictionary<char, int> map = new Dictionary<char, int>(dp[node]);
                    if (map.ContainsKey(colors[i]))
                        map[colors[i]]++;
                    else
                        map[colors[i]] = 1;

                    var nowMap = dp[i];
                    foreach (var item in map)
                    {
                        if (nowMap.ContainsKey(item.Key))
                        {
                            nowMap[item.Key] = Math.Max(item.Value, nowMap[item.Key]);
                        }
                        else
                        {
                            nowMap[item.Key] = item.Value;
                        }
                    }
                }
            }

            inverseAdjacencyList[node].Add(node);
        }

        public static void Remove4AOV2(Dictionary<char, int>[] dp, HashSet<int>[] inverseAdjacencyList, List<int>[] adjacencyList, int node, string colors)
        {
            var indexs = adjacencyList[node];
            Dictionary<char, int> map = new Dictionary<char, int>(dp[node]);
            foreach (var i in indexs)
            {
                if (inverseAdjacencyList[i].Remove(node))
                {

                    if (map.ContainsKey(colors[i]))
                        map[colors[i]]++;
                    else
                        map[colors[i]] = 1;

                    var nowMap = dp[i];
                    foreach (var item in map)
                    {
                        if (nowMap.ContainsKey(item.Key))
                        {
                            nowMap[item.Key] = Math.Max(item.Value, nowMap[item.Key]);
                        }
                        else
                        {
                            nowMap[item.Key] = item.Value;
                        }
                    }

                    map[colors[i]]--;
                }
            }

            inverseAdjacencyList[node].Add(node);
        }

        public static void Remove4AOV2(Dictionary<char, int>[] dp, Dictionary<int, HashSet<int>> inverseAdjacencyList, List<int>[] adjacencyList, int node, string colors)
        {
            var indexs = adjacencyList[node];
            Dictionary<char, int> map = new Dictionary<char, int>(dp[node]);
            foreach (var i in indexs)
            {
                if (inverseAdjacencyList[i].Remove(node))
                {

                    if (map.ContainsKey(colors[i]))
                        map[colors[i]]++;
                    else
                        map[colors[i]] = 1;

                    var nowMap = dp[i];
                    foreach (var item in map)
                    {
                        if (nowMap.ContainsKey(item.Key))
                        {
                            nowMap[item.Key] = Math.Max(item.Value, nowMap[item.Key]);
                        }
                        else
                        {
                            nowMap[item.Key] = item.Value;
                        }
                    }

                    map[colors[i]]--;
                }
            }

            inverseAdjacencyList.Remove(node);
        }

        public static List<int> FindAllNodeOfNoneInDegree(HashSet<int>[] inverseAdjacencyList)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < inverseAdjacencyList.Length; i++)
            {
                if (inverseAdjacencyList[i].Count == 0)
                    result.Add(i);
            }
            return result;
        }

        public static List<int> FindAllNodeOfNoneInDegree(Dictionary<int, HashSet<int>> inverseAdjacencyList)
        {
            return inverseAdjacencyList.Where(v => v.Value.Count == 0).Select(v => v.Key).ToList();
        }

        public static int FindNodeOfNoneInDegree(Dictionary<int, HashSet<int>> inverseAdjacencyList)
        {
            foreach (var item in inverseAdjacencyList)
            {
                if (item.Value.Count == 0)
                    return item.Key;
            }

            return -1;
        }

        public static int Run4(string colors, int[][] edges)
        {
            int n = colors.Length;
            List<int>[] adjacencyList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adjacencyList[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                adjacencyList[edge[0]].Add(edge[1]);
            }

            Dictionary<char, int>[] dp = new Dictionary<char, int>[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new Dictionary<char, int>();
                dp[i][colors[i]] = 1;
            }

            if (IsAOV4(dp, adjacencyList, colors))
            {
                int result = 0;
                foreach (var map in dp)
                {
                    result = Math.Max(result, map.Values.Max());
                }

                return result;
            }
            else
            {
                return -1;
            }
        }

        public static bool IsAOV4(Dictionary<char, int>[] dp, List<int>[] adjacencyList, string colors)
        {
            int len = adjacencyList.Length;
            List<int>[] inverseAdjacencyList = new List<int>[len];
            for (int i = 0; i < len; i++)
            {
                inverseAdjacencyList[i] = new List<int>();
            }
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < adjacencyList[i].Count; j++)
                {
                    inverseAdjacencyList[adjacencyList[i][j]].Add(i);
                }
            }

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < len; i++)
            {
                if (inverseAdjacencyList[i].Count == 0)
                    queue.Enqueue(i);
            }

            HashSet<int> visited = new HashSet<int>(len);
            List<int> result = new List<int>();
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                var nextNodes = adjacencyList[node];
                Dictionary<char, int> map = new Dictionary<char, int>(dp[node]);
                foreach (var next in nextNodes)
                {
                    if (visited.Contains(next))
                        return false;

                    var inDegrees = inverseAdjacencyList[next];
                    if (inDegrees.Remove(node))
                    {
                        if (map.ContainsKey(colors[next]))
                            map[colors[next]]++;
                        else
                            map[colors[next]] = 1;

                        var nowMap = dp[next];
                        foreach (var item in map)
                        {
                            if (nowMap.ContainsKey(item.Key))
                            {
                                nowMap[item.Key] = Math.Max(item.Value, nowMap[item.Key]);
                            }
                            else
                            {
                                nowMap[item.Key] = item.Value;
                            }
                        }

                        map[colors[next]]--;
                    }
                    if (inDegrees.Count == 0)
                        queue.Enqueue(next);
                }

                visited.Add(node);
                result.Add(node);
            }

            return result.Count == len;
        }


        public static List<int> TopologicalSort(List<int>[] adjacencyList)
        {
            int len = adjacencyList.Length;
            List<int>[] inverseAdjacencyList = new List<int>[len];
            for (int i = 0; i < len; i++)
            {
                inverseAdjacencyList[i] = new List<int>();
            }
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < adjacencyList[i].Count; j++)
                {
                    inverseAdjacencyList[adjacencyList[i][j]].Add(i);
                }
            }

            Queue<int> queue = new Queue<int>();
            
            for (int i = 0; i < len; i++)
            {
                if (inverseAdjacencyList[i].Count == 0)
                    queue.Enqueue(i);
            }

            HashSet<int> visited = new HashSet<int>(len);  
            List<int> result = new List<int>();
            while(queue.Count > 0)
            {
                int node = queue.Dequeue();
                var nextNodes = adjacencyList[node];
                foreach(var next in nextNodes) 
                {
                    if (visited.Contains(next))
                        return new List<int>();

                    var inDegrees = inverseAdjacencyList[next];
                    inDegrees.Remove(node);
                    if (inDegrees.Count == 0)
                        queue.Enqueue(next);
                }

                visited.Add(node);
                result.Add(node);
            }

            return result;
        }
    }
}
