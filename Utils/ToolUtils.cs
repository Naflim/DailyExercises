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
        /// 快速排序同时返回比较值
        /// </summary>
        /// <typeparam name="T">排序类型</typeparam>
        /// <param name="list">列表</param>
        /// <param name="comparator">排序基准</param>
        /// <returns><排序后列表/returns>
        /// <remarks>此方法不会改变数组原有顺序</remarks>
        public static List<Tuple<TSource, TKey>> QuickSortAlsoReComp<TSource, TKey>(this IEnumerable<TSource> list, Func<TSource, TKey> keySelector)
             where TKey : IComparable<TKey>
        {
            List<Tuple<TSource, TKey>> sortList = list.Select(v => new Tuple<TSource, TKey>(v, keySelector(v))).ToList();
            QuickSort(sortList, v => v.Item2, 0, sortList.Count - 1);
            return sortList;
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <typeparam name="T">排序类型</typeparam>
        /// <param name="list">列表</param>
        /// <param name="comparator">排序基准</param>
        /// <returns>排序后列表</returns>
        /// <remarks>此方法不会改变数组原有顺序</remarks>
        public static List<TSource> QuickSort<TSource, TKey>(this IEnumerable<TSource> list, Func<TSource, TKey> keySelector)
             where TKey : IComparable<TKey>
        {
            var sortList = list.ToList();

            //先右后左，通过栈来避免深度递归时的栈溢出问题
            Stack<int> stack = new Stack<int>();
            stack.Push(sortList.Count - 1);
            stack.Push(0);

            while(stack.Count > 0)
            {
                int left = stack.Pop();
                int right = stack.Pop();

                int keyIndex = QuickSort(sortList,keySelector,left,right);

                //先右后左
                if(keyIndex + 1 < right)
                {
                    stack.Push(right);
                    stack.Push(keyIndex + 1);
                }

                if(keyIndex - 1 > left)
                {
                    stack.Push(keyIndex - 1);
                    stack.Push(left);
                }
            }

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
                while (comparator(list[i]) <= pivot && j > i) i++;

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

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <typeparam name="TSource">排序类型</typeparam>
        /// <typeparam name="TKey">类型中的键</typeparam>
        /// <param name="list">列表</param>
        /// <param name="keySelector">用于从元素中提取键的函数</param>
        /// <param name="begin">范围起点</param>
        /// <param name="end">范围终点</param>
        /// <returns>基准元素于排序后的索引</returns>
        /// <remarks>
        /// 此方法会改变数组原有顺序
        /// </remarks>
        private static int QuickSort<TSource, TKey>(IList<TSource> list, Func<TSource, TKey> keySelector, int begin, int end)
            where TKey : IComparable<TKey>
        {
            if (begin > end) return -1;

            var pivot = keySelector(list[begin]);//设定基准元素
            int i = begin, j = end;//保存起始和结尾索引下标

            while (i != j)
            {
                //找到一个小于pivot的值，循环结束j所在位置为小于pivot的元素所在的位置
                while (keySelector(list[j]).CompareTo(pivot) >= 0 && j > i) j--;

                //找到一个大于pivot的值，循环结束i所在位置为大于pivot的元素所在的位置
                while (keySelector(list[i]).CompareTo(pivot) <= 0 && j > i) i++;

                //交换上面找到的两个值
                if (j > i)
                {
                    TSource tempA = list[i];
                    list[i] = list[j];
                    list[j] = tempA;
                }
            }//循环结束i=j;

            //交换起始的基准元素到i，j所在位置，交换后基准元素左侧都小于基准元素，右侧都大于基准元素
            TSource tempB = list[begin];
            list[begin] = list[i];
            list[i] = tempB;

            return i;
        }
    }
}
