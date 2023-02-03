using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DailyExercises.Helper
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

        public AdjacencyList(IEnumerable<T> vertices)
        {
            Vertices = new Dictionary<T, Vertex>();
            foreach (T vertex in vertices) 
            {
                Vertices[vertex] = new Vertex(vertex);
            }
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

        public void DirectedEdge(T source, T destination)
        {
            var s = Vertices[source];
            var d = Vertices[destination];
            s.AddAdjacent(d);
        }

        public Vertex GetVertex(T source)
        {
            return Vertices[source];
        }
    }
}
