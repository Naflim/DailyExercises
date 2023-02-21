using DailyExercises.Helper;

namespace DailyExercises.Utils
{
    internal static class ToolUtils
    {
        public static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> grups) where TKey : notnull
        {
            Dictionary<TKey, List<TValue>> dic = new Dictionary<TKey, List<TValue>>();
            foreach (var grup in grups) dic[grup.Key] = grup.ToList();
            return dic;
        }

        public static List<T> BFS<T>(this IVertex<T> root, T target, Func<T[], T, bool>? filter = null) where T : notnull
        {
            HashSet<T> accessed = new();
            List<LinkedList<IVertex<T>>> paths = new();
            LinkedList<IVertex<T>> head = new();
            head.AddLast(root);
            paths.Add(head);
            while (paths.Count > 0)
            {
                var cache = paths.ToArray();
                paths.Clear();

                foreach (var item in cache)
                {
                    if(item.Last?.Value is not IVertex<T> pointer)break;
                    accessed.Add(pointer.GetValue());
                    if (pointer.GetValue().Equals(target)) return item.Select(v => v.GetValue()).ToList();

                    foreach (var next in pointer.NextVertex)
                    {
                        if (!accessed.Contains(next.GetValue()) && (filter?.Invoke(item.Select(v => v.GetValue()).ToArray(), next.GetValue())??true))
                        {
                            LinkedList<IVertex<T>> newPath = new(item);
                            newPath.AddLast(next);
                            paths.Add(newPath);
                        }
                    }
                }
            }

            return new List<T>();
        }

        public static List<T> DFS<T>(this IVertex<T> root,HashSet<T> accessed) where T : notnull
        {
            List<T> path = new()
            {
                root.GetValue()
            };

            accessed.Add(path[0]);
            void DFS(IVertex<T> node)
            {
                foreach (var next in node.NextVertex)
                {
                    if(!accessed.Contains(next.GetValue())) 
                    {
                        var val = next.GetValue();

                        path.Add(val);
                        accessed.Add(val);
                        DFS(next);
                    }
                }
            }

            DFS(root);
            return path;
        }

        /// <summary>
        /// 快速排序并返回指定类型列表
        /// </summary>
        /// <typeparam name="T">排序类型</typeparam>
        /// <typeparam name="V">返回类型</typeparam>
        /// <param name="list">列表</param>
        /// <param name="comparator">排序基准</param>
        /// <param name="convert">类型转换方法</param>
        /// <returns>排序后列表</returns>
        /// <remarks>此方法不会改变数组原有顺序</remarks>
        public static List<V> QuickSort<T, V>(this IEnumerable<T> list, Func<T, double> comparator, Func<T, V> convert)
        {
            var sortList = list.ToList();
            QuickSort(sortList, comparator, 0, sortList.Count - 1);
            return sortList.Select(v => convert(v)).ToList();
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <typeparam name="T">排序类型</typeparam>
        /// <param name="list">列表</param>
        /// <param name="comparator">排序基准</param>
        /// <returns>排序后列表</returns>
        /// <remarks>此方法不会改变数组原有顺序</remarks>
        public static List<T> QuickSort<T>(this IEnumerable<T> list, Func<T, double> comparator)
        {
            var sortList = list.ToList();
            QuickSort(sortList, comparator, 0, sortList.Count - 1);
            return sortList;
        }

        /// <summary>
        /// 快速排序同时返回比较值
        /// </summary>
        /// <typeparam name="T">排序类型</typeparam>
        /// <param name="list">列表</param>
        /// <param name="comparator">排序基准</param>
        /// <returns><排序后列表/returns>
        /// <remarks>此方法不会改变数组原有顺序</remarks>
        public static List<Tuple<T, double>> QuickSortAlsoReComp<T>(this IEnumerable<T> list, Func<T, double> comparator)
        {
            List<Tuple<T, double>> sortList = list.Select(v => new Tuple<T, double>(v, comparator(v))).ToList();
            QuickSort(sortList, v => v.Item2, 0, sortList.Count - 1);
            return sortList;
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <typeparam name="T">排序类型</typeparam>
        /// <param name="list">列表</param>
        /// <param name="comparator">排序基准</param>
        /// <param name="begin">范围起点</param>
        /// <param name="end">范围终点</param>
        /// <remarks>此方法会改变数组原有顺序</remarks>
        public static void QuickSort<T>(IList<T> list, Func<T, double> comparator, int begin, int end)
        {
            if (begin > end) return;
            double pivot = comparator(list[begin]);//设定基准元素
            int i = begin, j = end;//保存起始和结尾索引下标

            while (i != j)
            {
                //找到一个小于pivot的值，循环结束j所在位置为小于pivot的元素所在的位置
                while (comparator(list[j]) >= pivot && j > i) j--;

                //找到一个大于pivot的值，循环结束i所在位置为大于pivot的元素所在的位置
                while (comparator(list[i]) <= pivot&&j>i) i++;

                //交换上面找到的两个值
                if (j > i)
                {
                    T tempA = list[i];
                    list[i] = list[j];
                    list[j] = tempA;
                }
            }//循环结束i=j;

            //交换起始的基准元素到i，j所在位置，交换后基准元素左侧都小于基准元素，右侧都大于基准元素
            T tempB = list[begin];
            list[begin] = list[i];
            list[i] = tempB;
            //递归排序中间元素左侧数组；
            QuickSort(list, comparator, begin, i-1);
            //递归排序中间元素右侧数组；
            QuickSort(list, comparator, i+1, end);
        }

    }
}
