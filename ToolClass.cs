using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DailyExercises
{
    public interface IVertex<T>
    {
        T GetValue();
        IVertex<T>[] NextVertex { get; }
    }


    public class AdjacencyList<T> where T : notnull
    {
        public class Vertex : IVertex<T>
        {
            public T Value { get; set; }

            private List<IVertex<T>> _nextVertex;


            public IVertex<T>[] NextVertex { get { return _nextVertex.ToArray(); } }

            public Vertex(T value)
            {
                Value = value;
                _nextVertex = new List<IVertex<T>>();
            }

            public T GetValue()
            {
                return Value;
            }

            public void AddAdjacent(Vertex vertex)
            {
                _nextVertex.Add(vertex);
            }
        }

        public Dictionary<T, Vertex> Vertices { get; set; }

        public AdjacencyList()
        {
            Vertices = new Dictionary<T, Vertex>();
        }

        public void AddVertex(T value)
        {
            Vertices[value] = new Vertex(value);
        }

        public void AddEdge(T source, T destination)
        {
            var s = Vertices[source];
            var d = Vertices[destination];
            s.AddAdjacent(d);
            d.AddAdjacent(s);
        }

        public Vertex GetVertex(T source)
        {
            return Vertices[source];
        }
    }

    class ToolUtils
    {
        public static List<T> BFS<T>(IVertex<T> root, T target) where T : notnull
        {
            HashSet<T> accessed = new();
            List<Stack<IVertex<T>>> paths = new();
            Stack<IVertex<T>> head = new Stack<IVertex<T>>();
            head.Push(root);
            paths.Add(head);
            while (paths.Count > 0)
            {
                var cache = paths.ToArray();
                paths.Clear();

                foreach (var item in cache)
                {
                    var path = item.Peek();
                    accessed.Add(path.GetValue());
                    if (path.GetValue().Equals(target)) return item.Select(v => v.GetValue()).ToList();

                    foreach(var next in path.NextVertex)
                    {
                        if (!accessed.Contains(next.GetValue()))
                        {
                            Stack<IVertex<T>> newPath = new Stack<IVertex<T>>(item);
                            newPath.Push(next);
                            paths.Add(newPath);
                        }
                    }
                }
            }

            return new List<T>();
        }
    }
}
