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
    }
}
