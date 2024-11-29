using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 401. 二进制手表
    /// </summary>
    internal class ReadBinaryWatch
    {
        private readonly static int[] hours = [8, 4, 2, 1];
        private readonly static int[] minutes = [32, 16, 8, 4, 2, 1];

        public static IList<string> Run(int turnedOn)
        {
            int len = 0b1111111111;
            List<string> result = new List<string>();
            for (int i = 0; i < len; i++)
            {
                int count = Convert.ToString(i, 2).Count(v => v == '1');
                if (count != turnedOn)
                    continue;

                var time = GetTime(i);
                if(!string.IsNullOrEmpty(time))
                    result.Add(time);
            }

            return result;
        }

        public static string GetTime(int bins)
        {
            int hour = 0;
            int index = 9;
            for (int i = 0; i < 4; i++)
            {
                int bin = index - i;
                int mark = 1 << bin;

                if((bins & mark) != 0)
                {
                    hour += hours[i];
                }
            }

            if(hour > 11)
                return string.Empty;

            int minute = 0;
            index = 5;
            for (int i = 0; i < 6; i++)
            {
                int bin = index - i;
                int mark = 1 << bin;

                if ((bins & mark) != 0)
                {
                    minute += minutes[i];
                }
            }

            if(minute > 59)
                return string.Empty;

            string strMin = minute.ToString().PadLeft(2,'0');
            return $"{hour}:{strMin}";
        }
    }
}
