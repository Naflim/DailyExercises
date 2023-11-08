using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1203. 项目管理
    /// </summary>
    internal class SortItems
    {
        /* 思路：
         * 寻找无入度点为起点
         * 起点存在所属队，以此队为条件进行拓扑排序
         * 起点不存在所属队，以无所属任务为条件进行拓扑排序
         * 优先排序所属队
         */
        public static int[] Run(int n, int m, int[] group, IList<IList<int>> beforeItems)
        {
            List<int>[] inverseAdjacencyList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                inverseAdjacencyList[i] = new List<int>();
            }

            for (int i = 0; i < beforeItems.Count; i++)
            {
                inverseAdjacencyList[i].AddRange(beforeItems[i]);
            }

            List<int> result = new List<int>();
            List<int> startTasks = FindAllNodeOfNoneInDegree(inverseAdjacencyList);
            while (startTasks.Count > 0)
            {
                var pre = new HashSet<int>(result);
                pre.UnionWith(startTasks);
                var post = GetPostTeam(pre, group, beforeItems);
                int startNode = startTasks.FirstOrDefault(t => !post.Contains(group[t]), startTasks[0]);
                var sortTasks = TopologicalSort(inverseAdjacencyList, group[startNode], group);
                result.AddRange(sortTasks);
                startTasks = FindAllNodeOfNoneInDegree(inverseAdjacencyList);
            }

            return IsSuitableSolution(group, result) ? result.ToArray() : Array.Empty<int>();
        }

        public static bool IsSuitableSolution(int[] group, IList<int> solution)
        {
            if (group.Length != solution.Count)
                return false;

            var filter = solution.Where(v => group[v] != -1).ToArray();
            HashSet<int> teams = new HashSet<int> { group[filter[0]] };
            int prevTeam = group[filter[0]];
            for (int i = 1; i < filter.Length; i++)
            {
                var team = group[filter[i]];
                if (team != prevTeam)
                {
                    if (teams.Contains(team))
                        return false;
                    else
                        teams.Add(team);

                    prevTeam = team;
                }
            }

            return true;
        }

        public static HashSet<int> GetPostTeam(HashSet<int> preTask, int[] group, IList<IList<int>> beforeItems)
        {
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < beforeItems.Count; i++)
            {
                if (!preTask.Contains(i) && preTask.IsSupersetOf(beforeItems[i]) && group[i] != -1)
                    result.Add(group[i]);
            }

            return result;
        }

        public static List<int> TopologicalSort(List<int>[] inverseAdjacencyList, int team, int[] group)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < inverseAdjacencyList.Length; i++)
            {
                var indexs = FindAllNodeOfNoneInDegree(inverseAdjacencyList, team, group);
                if (!indexs.Any())
                    return result;

                result.AddRange(indexs);
                Remove4AOV(inverseAdjacencyList, indexs);
            }

            return result;
        }

        public static List<int> TopologicalSort(Dictionary<int, List<int>> AOV, List<int>[] inverseAdjacencyList, int team, int[] group)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < inverseAdjacencyList.Length; i++)
            {
                var indexs = FindAllNodeOfNoneInDegree(inverseAdjacencyList, team, group);
                if (!indexs.Any())
                {
                    if (team != -1)
                        Remove4AOV(AOV, new int[] { team });
                    return result;
                }


                result.AddRange(indexs);
                HashSet<int> set = new HashSet<int>(indexs);
                Remove4AOV(inverseAdjacencyList, set);

            }

            if (team != -1)
                Remove4AOV(AOV, new int[] { team });
            return result;
        }

        public static List<int> FindAllNodeOfNoneInDegree(List<int>[] inverseAdjacencyList, int team, int[] group)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < inverseAdjacencyList.Length; i++)
            {
                if (inverseAdjacencyList[i].Count == 0 && group[i] == team)
                    result.Add(i);
            }

            return result;
        }

        public static List<int> FindAllNodeOfNoneInDegree(List<int>[] inverseAdjacencyList)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < inverseAdjacencyList.Length; i++)
            {
                if (inverseAdjacencyList[i].Count == 0)
                    result.Add(i);
            }
            return result;
        }

        /*
         * 获取每组完成组任务需要的前置组
         * 获取组之前的AOV图
         * 进行拓扑排序获取小组执行顺序
         * 以小组执行顺序进行拓扑排序
         */
        public static int[] Run2(int n, int m, int[] group, IList<IList<int>> beforeItems)
        {
            List<int>[] inverseAdjacencyList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                inverseAdjacencyList[i] = new List<int>();
            }

            for (int i = 0; i < beforeItems.Count; i++)
            {
                inverseAdjacencyList[i].AddRange(beforeItems[i]);
            }



            Dictionary<int, List<int>> groupDic = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                if (groupDic.ContainsKey(group[i]))
                    groupDic[group[i]].Add(i);
                else
                    groupDic[group[i]] = new List<int> { i };
            }

            groupDic.Remove(-1);

            Dictionary<int, List<int>> GetGroupAOV()
            {
                Dictionary<int, List<int>> result = new();
                foreach (var item in groupDic)
                {
                    HashSet<int> preTasks = new HashSet<int>();
                    foreach (var val in item.Value)
                    {
                        preTasks.UnionWith(beforeItems[val]);
                    }

                    HashSet<int> preGroup = new HashSet<int>();
                    foreach (var task in preTasks)
                    {
                        if (group[task]!=-1 && group[task] != item.Key)
                            preGroup.Add(group[task]);
                    }

                    result[item.Key] = new List<int>(preGroup);
                }

                return result;
            }

            //var groupAOV = GetGroupAOV();
            var sortAOV = GetGroupAOV();
            var sortGruop = TopologicalSort(sortAOV);
            if (sortGruop.Count == 0)
                return  Array.Empty<int>();

            Queue<int> queueGruop = new Queue<int>(sortGruop);
            List<int> result = new List<int>();
            List<int> startTasks = FindAllNodeOfNoneInDegree(inverseAdjacencyList);

            void Clear()
            {
                while (true)
                {
                    DebrisCleaning(groupDic, inverseAdjacencyList, startTasks, group, result);
                    if (startTasks.Count > 0)
                        break;

                    startTasks = FindAllNodeOfNoneInDegree(inverseAdjacencyList);
                    if (startTasks.Count == 0)
                        break;
                }
            }

            Clear();
            while (startTasks.Count > 0)
            {
                startTasks = startTasks.OrderBy(v => group[v]).ToList();
                int startNode = startTasks.FirstOrDefault(t => group[t] == -1
                || (queueGruop.Count > 0 && group[t] == queueGruop.Peek()),
                startTasks[0]);

                if (queueGruop.Count > 0 && group[startNode] == queueGruop.Peek())
                    queueGruop.Dequeue();

                var sortTasks = TopologicalSort(inverseAdjacencyList, group[startNode], group);
                result.AddRange(sortTasks);
                startTasks = FindAllNodeOfNoneInDegree(inverseAdjacencyList);

                Clear();
            }

            return IsSuitableSolution(group, result) ? result.ToArray() : Array.Empty<int>();
        }

        public static List<int> TopologicalSort(Dictionary<int, List<int>> AOV)
        {
            int len = AOV.Count;

            List<int> result = new List<int>();

            for (int i = 0; i < len; i++)
            {
                var indexs = FindAllNodeOfNoneInDegree(AOV);
                if (!indexs.Any())
                    return result;

                result.AddRange(indexs);
                Remove4AOV(AOV, new HashSet<int>(indexs));
            }

            return result;
        }

        public static IEnumerable<int> FindAllNodeOfNoneInDegree(Dictionary<int, List<int>> AOV)
        {
            return AOV.Where(v => v.Value.Count == 0).Select(v => v.Key);
        }

        public static void Remove4AOV(Dictionary<int, List<int>> AOV, ICollection<int> nodes)
        {
            foreach (var val in AOV.Values)
            {
                val.RemoveAll(v => nodes.Contains(v));
            }

            foreach (var val in nodes)
            {
                AOV[val].Add(val);
            }
        }

        public static void Remove4AOV(List<int>[] inverseAdjacencyList, ICollection<int> nodes)
        {
            foreach (var val in inverseAdjacencyList)
            {
                val.RemoveAll(v => nodes.Contains(v));
            }

            foreach (var val in nodes)
            {
                inverseAdjacencyList[val].Add(val);
            }
        }

        public static void DebrisCleaning(Dictionary<int, List<int>> groupDic, List<int>[] inverseAdjacencyList, List<int> startTasks, int[] group, List<int> result)
        {
            List<int> debris = new List<int>();
            for (int i = 0; i < startTasks.Count; i++)
            {
                var task = startTasks[i];
                if (group[task] != -1 && groupDic[group[task]].Count == 1)
                    debris.Add(task);
            }

            foreach (var item in debris)
            {
                startTasks.Remove(item);
            }

            Remove4AOV(inverseAdjacencyList, debris);

            result.AddRange(debris);
        }

        /*
         * 获取每组完成组任务需要的前置组
         * 获取组之间的AOV图 
         * 进行拓扑排序获取小组执行顺序
         * 对每个小组按照任务AOV图进行映射
         * 小组内进行拓扑排序
         */
        public static int[] Run3(int n, int m, int[] group, IList<IList<int>> beforeItems)
        {
            List<int>[] taskAOV = beforeItems.Select(v => v.ToList()).ToArray();

            Dictionary<int, List<int>> groupDic = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                if (groupDic.ContainsKey(group[i]))
                    groupDic[group[i]].Add(i);
                else
                    groupDic[group[i]] = new List<int> { i };
            }

            groupDic.Remove(-1);

            Dictionary<int, List<int>> GetGroupAOV()
            {
                Dictionary<int, List<int>> result = new();
                foreach (var item in groupDic)
                {
                    HashSet<int> preTasks = new HashSet<int>();
                    foreach (var val in item.Value)
                    {
                        preTasks.UnionWith(beforeItems[val]);
                    }

                    HashSet<int> preGroup = new HashSet<int>();
                    foreach (var task in preTasks)
                    {
                        if (group[task]!=-1 && group[task] != item.Key)
                            preGroup.Add(group[task]);
                    }

                    result[item.Key] = new List<int>(preGroup);
                }

                return result;
            }

            var sortGroup = TopologicalSort(GetGroupAOV());
            if (sortGroup.Count == 0)
                return new int[0];

            List<int> result = new();
            HashSet<int> visited = new HashSet<int>();
            foreach (var g in sortGroup)
            {
                //获取小组映射的AOV图
                if (!GetMappingAOV(groupDic[g], taskAOV, visited, group, out Dictionary<int, List<int>> mappingAOV, out List<int> unclaimedTasks))
                    return Array.Empty<int>();

                result.AddRange(unclaimedTasks);
                visited.UnionWith(unclaimedTasks);
                var newSortTask = TopologicalSort(mappingAOV);

                if(newSortTask.Count != mappingAOV.Count)
                    return  Array.Empty<int>();

                result.AddRange(newSortTask);
                visited.UnionWith(newSortTask);
            }

            if(result.Count != n)
            {
                List<int> unclaimedTasks = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    if (visited.Contains(i))
                        continue;

                    if (group[i] != -1)
                        return Array.Empty<int>();

                    unclaimedTasks.Add(i);
                }

                result.AddRange(unclaimedTasks);
                visited.UnionWith(unclaimedTasks);
            }

            return result.ToArray();
        }

        public static bool GetMappingAOV(List<int> groupMembers, List<int>[] taskAOV, HashSet<int> visited, int[] group, out Dictionary<int, List<int>> mappingAOV, out List<int> result)
        {
            var team = group[groupMembers[0]];

            //小组映射的AOV图
            mappingAOV = new Dictionary<int, List<int>>();
            //需要处理的无人认领任务
            List<int> unclaimedTasks = new List<int>();
            foreach (var item in groupMembers)
            {
                var preTask = new HashSet<int>(taskAOV[item]);
                preTask.ExceptWith(visited);
                List<int> groupTasks = new List<int>();

                foreach (var task in preTask)
                {
                    if (group[task] == team)
                        groupTasks.Add(task);
                    else if (group[task] == -1)
                        unclaimedTasks.Add(task);
                    else
                        throw new Exception("未处理的前置项！");
                }

                mappingAOV[item] = groupTasks;
            }

            Dictionary<int, List<int>> unclaimedAOV = new();
            foreach (var task in unclaimedTasks)
            {
                var preTask = new HashSet<int>(taskAOV[task]);
                preTask.ExceptWith(visited);
                if (preTask.Any(t => group[t] != -1))
                {
                    result = new List<int>();
                    return false;
                }

                unclaimedAOV[task] = new List<int>(preTask);
            }

            result = TopologicalSort(unclaimedAOV);

            return result.Count == unclaimedAOV.Count;
        }
    }
}
