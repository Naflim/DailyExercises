using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1376. 通知所有员工所需的时间
    /// </summary>
    internal class NumOfMinutes
    {
        public static int Run(int n, int headID, int[] manager, int[] informTime)
        {
            Dictionary<int, List<int>> relation = new Dictionary<int, List<int>>();

            for (int i = 0;i < n; i++)
            {
                if (relation.ContainsKey(manager[i]))
                    relation[manager[i]].Add(i);
                else
                    relation[manager[i]] = new List<int>() { i };
            }

            return GetInformTimeByDFS(relation, headID, informTime, 0);
        }

        private static int GetInformTimeByDFS(Dictionary<int, List<int>> relation, int headID, int[] informTime,int elapsedTime)
        {
            if(!relation.ContainsKey(headID))
                return elapsedTime;

            elapsedTime += informTime[headID];

            int result = 0;

            foreach(int underling in relation[headID])
            {
                result = Math.Max(result, GetInformTimeByDFS(relation,underling,informTime,elapsedTime));
            }

            return result;
        }
    }

    
}
