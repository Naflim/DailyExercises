using DailyExercises.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1233. 删除子文件夹
    /// </summary>
    internal class RemoveSubfolders
    {
        public static IList<string> Run(string[] folder)
        {
            Dictionary<string, DictionaryTree<string>> root = new();


            foreach (string path in folder) 
            {
                string[] nodes = path.Split('/',StringSplitOptions.RemoveEmptyEntries);

                var current = root;
                List<string> cache = new();
                foreach (string node in nodes) 
                {
                    if (current.ContainsKey(node))
                    {
                        current = current[node].Tree;
                    }
                    else
                    {
                        current[node] = new DictionaryTree<string>(node, cache);
                        current = current[node].Tree;
                    }
                    cache.Add(node);
                }
            }


            foreach (string path in folder)
            {
                string[] nodes = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

                var current = root;
                foreach (string node in nodes)
                {
                    if (current.ContainsKey(node)) current = current[node].Tree;
                    else break;
                }

                current.Clear();
            }

            List<string> result = new List<string>();

            void DFS(DictionaryTree<string> node)
            {
                if (node.Tree.Count == 0) result.Add(node.ParentNodes.Length == 0?$"/{node.Node}":$"/{string.Join('/', node.ParentNodes)}/{node.Node}");
                else foreach (var item in node.Tree.Values) DFS(item);
            }

            foreach(var item in root.Values)DFS(item);
            return result;
        }
    }
}
