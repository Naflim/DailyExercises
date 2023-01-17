using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises.Utils
{
    internal static class ToolUtils
    {
        public static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> grups)where TKey : notnull
        {
            Dictionary<TKey, List<TValue>> dic = new Dictionary<TKey, List<TValue>>();
            foreach (var grup in grups) dic[grup.Key] = grup.ToList();
            return dic;
        }
    }
}
