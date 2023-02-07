using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1604. 警告一小时内使用相同员工卡大于等于三次的人
    /// </summary>
    internal class AlertNames
    {
        public static IList<string> Run(string[] keyName, string[] keyTime)
        {
            SortedDictionary<string, List<int>> checkAttendance = new();

            int len = keyName.Length;

            for (int i = 0; i < len; i++)
            {
                if (checkAttendance.ContainsKey(keyName[i])) checkAttendance[keyName[i]].Add(TimeToMinutes(keyTime[i]));
                else checkAttendance[keyName[i]] = new List<int> { TimeToMinutes(keyTime[i]) };
            }

            List<string> nameList = new();

            foreach (var attendance in checkAttendance)
            {
                if (!CheckWorkAttendance(attendance.Value)) nameList.Add(attendance.Key);
            }

            return nameList;
        }

        public static bool CheckWorkAttendance(IEnumerable<int> attendance)
        {
            var sortAttendance = attendance.ToList();
            if (sortAttendance.Count < 2) return true;

            sortAttendance.Sort();

            int count = 1;

            int compareTime = sortAttendance[0];
            for (int i = 1; i < sortAttendance.Count; i++)
            {
                if (sortAttendance[i] - compareTime <= 60) count++;
                else
                {
                    if (sortAttendance[i - 1] - sortAttendance[i] <= 60)
                    {
                        compareTime = sortAttendance[i - 1];
                        count = 2;
                    }
                    else
                    {
                        compareTime = sortAttendance[i];
                        count = 1;
                    }

                }

                if (count == 3) return false;
            }

            return true;
        }

        public static int TimeToMinutes(string time)
        {
            int[] timeVal = time.Split(':').Select(time => Convert.ToInt32(time)).ToArray();

            return timeVal[0] * 60 + timeVal[1];
        }
    }
}
