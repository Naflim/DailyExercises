using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 210. 课程表 II
    /// </summary>
    internal class FindOrder
    {
        public static int[] Run(int numCourses, int[][] prerequisites)
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

            return TopologicalSort(adjacencyList).ToArray();
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

            List<int> result = new List<int>();

            for (int i = 0; i < len; i++)
            {
                var index = CanFinish.FindNodeOfNoneInDegree(inverseAdjacencyList);
                if (index == -1)
                    return new List<int>();

                result.Add(index);
                CanFinish.Remove4AOV(inverseAdjacencyList, index);
            }

            return result;
        }
    }
}
