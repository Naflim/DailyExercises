using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises.Helper.Tree
{
    internal class DictionaryTree<T> where T : notnull
    {
        public T Node { get; }
        public T[] ParentNodes { get; }
        public Dictionary<T, DictionaryTree<T>> Tree { get; }

        public DictionaryTree(T node, IEnumerable<T> parentNodes)
        {
            Node = node;
            ParentNodes = parentNodes.ToArray();
            Tree = new Dictionary<T, DictionaryTree<T>>();
        }
    }
}
