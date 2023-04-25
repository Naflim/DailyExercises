using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2418. 按身高排序
    /// </summary>
    internal class SortPeople
    {
        public static string[] Run(string[] names, int[] heights)
        {
            SortedDictionary<int,string> dic = new SortedDictionary<int,string>();

            for (int i = 0; i < heights.Length; i++)
                dic[heights[i]] = names[i];

            return dic.Values.Reverse().ToArray();
        }
    }
}
