using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 3863. 将一个字符串排序的最小操作次数
    /// </summary>
    internal class MinOperations2
    {
        public static int Run(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Sort(arr);
            string sortedString = new(arr);
            if (s == sortedString)
                return 0;

            if (sortedString.Length == 2)
                return -1;

            char min = arr[0];
            char max = arr[^1];

            if (s.Last() == max)
                return 1;

            if (s.First() == min)
                return 1;

            int leftCount = 0;
            int rightCount = 0;

            List<char> list = s.ToList();
            List<char> subList = list.GetRange(0, list.Count - 1);
            subList.Sort();
            subList.Add(list[^1]);
            list = subList;

            if (new string(list.ToArray()) == sortedString)
            {
                leftCount = 1;
            }
            else
            {
                subList = list.GetRange(1, list.Count - 1);
                subList.Sort();
                subList.Insert(0, list[0]);
                list = subList;

                if (new string(list.ToArray()) == sortedString)
                    leftCount = 2;
                else
                    leftCount = 3;
            }

            list = s.ToList();
            subList = list.GetRange(1, list.Count - 1);
            subList.Sort();
            subList.Insert(0, list[0]);
            list = subList;

            if (new string(list.ToArray()) == sortedString)
            {
                rightCount = 1;
            }
            else
            {
                subList = list.GetRange(0, list.Count - 1);
                subList.Sort();
                subList.Add(list[^1]);
                list = subList;
                if (new string(list.ToArray()) == sortedString)
                    rightCount = 2;
                else
                    rightCount = 3;
            }

            return Math.Min(leftCount, rightCount);
        }

        public static int Run2(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Sort(arr);
            string sortedString = new(arr);
            if (s == sortedString)
                return 0;

            if (sortedString.Length == 2)
                return -1;

            char min = arr[0];
            char max = arr[^1];

            if (s.Last() == max)
                return 1;

            if (s.First() == min)
                return 1;

            for (int i = 1; i < s.Length - 1; i++)
            {
                if (s[i] == min || s[i] == max)
                    return 2;
            }

            return 3;
        }
    }
}
