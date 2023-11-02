using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 207. 课程表
    /// </summary>
    internal class CanFinish
    {
        public static bool Run(int numCourses, int[][] prerequisites)
        {
            List<int>[] adjacencyList = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                adjacencyList[i] = new List<int>();
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                adjacencyList[prerequisites[i][1]].Add(prerequisites[i][0]);
            }

            return IsAOV(adjacencyList);
        }

        public static bool IsAOV(List<int>[] adjacencyList)
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
                if(index == -1)
                    return false;

                Remove4AOV(inverseAdjacencyList, index);
            }

            return true;
        }

        public static int FindNodeOfNoneInDegree(List<int>[] inverseAdjacencyList)
        {
            return Array.FindIndex(inverseAdjacencyList, v => v.Count == 0);
        }

        public static void Remove4AOV(List<int>[] inverseAdjacencyList, int node)
        {
            foreach(var val in inverseAdjacencyList)
            {
                val.Remove(node);
            }

            inverseAdjacencyList[node].Add(node);
        }
    }
}
