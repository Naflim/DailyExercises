using DailyExercises.Utils;
using HWDataStructure.Algorithms;
using HWDataStructure.DataStructure.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DailyExercises
{
    /// <summary>
    /// 2581. 统计可能的树根数目
    /// </summary>
    internal class RootCount
    {
        public static int Run(int[][] edges, int[][] guesses, int k)
        {
            Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

            foreach (var edge in edges)
            {
                adjacencyList.AddGruopItem(edge[0], edge[1]);
                adjacencyList.AddGruopItem(edge[1], edge[0]);
            }

            int[] nodes = adjacencyList.Keys.ToArray();

            int result = 0;
            foreach (var node in nodes)
            {
                HashSet<int> visited = new HashSet<int>();
                Tree<int> tree = new Tree<int>(node, n =>
                {
                    var result = adjacencyList[n].Where(v => !visited.Contains(v));
                    visited.Add(n);
                    return result;
                });
                int count = GetCorrectCount(tree, guesses);
                if (count >= k)
                    result++;
            }

            return result;
        }

        private static int GetCorrectCount(Tree<int> tree, int[][] guesses)
        {
            int count = 0;
            foreach (var guess in guesses)
            {
                var node = tree.GetNode(guess[1]);
                if (node.ParentNode != null)
                {
                    var parent = tree.GetParentItem(guess[1]);
                    if (parent == guess[0])
                        count++;
                }
            }

            return count;
        }

        public static int Run2(int[][] edges, int[][] guesses, int k)
        {
            Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

            foreach (var edge in edges)
            {
                adjacencyList.AddGruopItem(edge[0], edge[1]);
                adjacencyList.AddGruopItem(edge[1], edge[0]);
            }

            int[] nodes = adjacencyList.Keys.ToArray();

            int start = nodes[0];
            HashSet<int> visited = new HashSet<int>();
            Tree<int> tree = new Tree<int>(start, n =>
            {
                var result = adjacencyList[n].Where(v => !visited.Contains(v));
                visited.Add(n);
                return result;
            });

            var root = tree.Root;

            var node = root;

            while (node.ChildNodes != null && node.ChildNodes.Any())
                node = node.ChildNodes.Last();

            var end = node.Value;

            Dictionary<int, List<int>> guessesMap = new Dictionary<int, List<int>>();
            foreach (var guess in guesses)
            {
                guessesMap.AddGruopItem(guess[1], guess[0]);    
            }


            Dictionary<int, int> correctCount = new Dictionary<int, int>();

            correctCount[root.Value] = GetCorrectCount(tree, guesses);
            int result = correctCount[root.Value] >= k ? 1 : 0;

            var nowNode = root;

            while(nowNode.Value != end)
            {
                //将next设为根节点
                var nextNode = nowNode.ChildNodes[0];

                nowNode.ChildNodes.Remove(nextNode);
                nextNode.ParentNode = null;
                nowNode.ParentNode = nextNode;
                nextNode.ChildNodes.Add(nowNode);

                if (!correctCount.ContainsKey(nextNode.Value))
                {
                    //判断此次变化是否产生
                    int count = correctCount[nowNode.Value];

                    if (guessesMap.ContainsKey(nowNode.Value) && guessesMap[nowNode.Value].Contains(nextNode.Value))
                        count++;

                    if (guessesMap.ContainsKey(nextNode.Value) &&  guessesMap[nextNode.Value].Contains(nowNode.Value))
                        count--;

                    correctCount[nextNode.Value] = count;

                    if (count >= k)
                        result++;
                }

                nowNode = nextNode;
            }

            return result;

        }
    }
}
