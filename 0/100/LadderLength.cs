using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 127. 单词接龙
    /// </summary>
    internal class LadderLength
    {
        public static int Run(string beginWord, string endWord, IList<string> wordList)
        {
            if(!wordList.Contains(endWord))
                return 0;

            if(!wordList.Contains(beginWord))
                wordList.Add(beginWord);

            var wordArr = wordList.ToArray();
            MinMutationNode start = new MinMutationNode(beginWord, wordArr);
            MinMutationNode end = new MinMutationNode(endWord, wordArr);
            Graph<MinMutationNode> graph = new Graph<MinMutationNode>(start);
            graph.StartRetrieval();
            if (!graph.Contains(end))
            {
                return 0;
            }

            return graph.GetShortestPathByBfs(start, end).Count;
        }
    }
}
