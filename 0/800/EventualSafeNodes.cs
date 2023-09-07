using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DailyExercises
{
    /// <summary>
    /// 802. 找到最终的安全状态
    /// </summary>
    internal class EventualSafeNodes
    {
        public static IList<int> Run(int[][] graph)
        {
            HashSet<int> secureNode = new HashSet<int>();
            HashSet<int> circuitNode = new HashSet<int>();
            HashSet<int> path = new HashSet<int>();


            for (int i = 0; i < graph.Length; i++)
            {
                if(secureNode.Contains(i) || circuitNode.Contains(i))
                    continue;

                IsSecureNode(i,graph,path,secureNode,circuitNode);
            }

            var result = secureNode.ToList();
            result.Sort();
            return result;
        }

        public static bool IsSecureNode(int node, int[][] graph,HashSet<int> path, HashSet<int> secureNode, HashSet<int> circuitNode) 
        {
            if(path.Contains(node))
            {
                circuitNode.Add(node);
                return false;
            }

            var linkNodes = graph[node];
            if (linkNodes.Length == 0)
            {
                secureNode.Add(node);
                return true;
            }

            HashSet<int> newPath = new HashSet<int>(path) { node };
            foreach (int linkNode in linkNodes) 
            {
                if (secureNode.Contains(linkNode))
                    continue;

                if (circuitNode.Contains(linkNode) || !IsSecureNode(linkNode, graph, newPath, secureNode, circuitNode))
                {
                    circuitNode.Add(node);
                    return false;
                }
            }

            secureNode.Add(node);
            return true;
        }
    }
}
