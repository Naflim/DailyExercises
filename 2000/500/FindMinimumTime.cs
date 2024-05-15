using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2589. 完成所有任务的最少时间
    /// </summary>
    internal class FindMinimumTime
    {
        public static int Run(int[][] tasks)
        {
            SortedDictionary<int, List<int>> taskNumAxis = new SortedDictionary<int, List<int>>();

            for (int i = 0; i < tasks.Length; i++)
            {
                var task = tasks[i];
                for (int j = task[0]; j <= task[1]; j++)
                {
                    if (taskNumAxis.ContainsKey(j))
                        taskNumAxis[j].Add(i);
                    else
                        taskNumAxis[j] = new List<int>() { i };
                }
            }

            var sort = taskNumAxis.OrderBy(v => v.Value.Count);
            Stack<KeyValuePair<int, List<int>>> stack = new Stack<KeyValuePair<int, List<int>>>(sort);

            int result = 0;
            while (stack.Any())
            {
                var run = stack.Pop();
                Console.WriteLine($"行走：{run.Key}");
                var runTasks = run.Value;
                taskNumAxis[run.Key] = new List<int>();
                foreach (var runTask in runTasks)
                {
                    var task = tasks[runTask];
                    var durationi = task[2];
                    if (durationi == 1)
                    {
                        for (int i = task[0]; i <= task[1]; i++)
                        {
                            if (taskNumAxis.ContainsKey(i) && i != run.Key)
                            {
                                taskNumAxis[i].Remove(runTask);
                                if (taskNumAxis[i].Count == 0)
                                    taskNumAxis.Remove(i);
                            }
                        }

                        taskNumAxis.Remove(run.Key);

                        sort = taskNumAxis.OrderBy(v => v.Value.Count);
                        stack = new Stack<KeyValuePair<int, List<int>>>(sort);
                    }
                    else
                    {
                        tasks[runTask][2]--;
                    }
                }
                result++;
            }

            return result;
        }

        public static int Run2(int[][] tasks)
        {
            Dictionary<int, List<int>> taskNumAxis = new Dictionary<int, List<int>>();

            for (int i = 0; i < tasks.Length; i++)
            {
                var task = tasks[i];
                for (int j = task[0]; j <= task[1]; j++)
                {
                    if (taskNumAxis.ContainsKey(j))
                        taskNumAxis[j].Add(i);
                    else
                        taskNumAxis[j] = new List<int>() { i };
                }
            }

            List<int> sortKeys = taskNumAxis.Keys.ToList();
            sortKeys.Sort();
            var sortTask = tasks.OrderBy(v => v[1]);

            int result = 0;
            foreach (var task in sortTask)
            {
                var end = task[1];
                int len = task[2];
                for (int i = 0; i < len; i++)
                {
                    var time = end - i;
                    var index = sortKeys.BinarySearch(time);

                    if(index < 0)
                    {
                        index = ~index - 1;
                        time = sortKeys[index];
                    }

                    var timeTasks = taskNumAxis[time];

                    foreach (var timeTask in timeTasks)
                    {
                        tasks[timeTask][2]--;
                    }
                    //Console.WriteLine($"行走：{time}");
                    sortKeys.Remove(time);
                    result++;
                }
            }

            return result;
        }
    }
}
