using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 139. 单词拆分
    /// </summary>
    internal class WordBreak
    {
        public static bool FWordBreak(string s, IList<string> wordDict)
        {
            var wordDictSet = new HashSet<string>(wordDict);

            var dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 1; i <= s.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (dp[j] && wordDictSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }

        public static bool Run(string s, IList<string> wordDict)
        {
            HashSet<string> hash = new HashSet<string>(wordDict);
            List<(int left, int right)> list = new();

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if (hash.Contains(s[i..(j+1)]))
                    {
                        list.Add((i, j));
                    }
                }
            }

            return BFS(list, new HashSet<int> { 0 }, s.Length - 1);
        }

        public static bool DFS(List<(int left, int right)> nodes, int local, int end)
        {
            if (local - 1 == end) return true;
            List<(int left, int right)> next = nodes.Where(v => v.left == local).ToList();
            for (int i = 0; i < next.Count; i++)
            {
                if (DFS(nodes, next[i].right + 1, end)) return true;
            }
            return false;
        }

        public static bool BFS(List<(int left, int right)> nodes, HashSet<int> local, int end)
        {
            List<(int left, int right)> next = nodes.Where(v => local.Contains(v.left)).ToList();
            if(next.Count == 0) return false;

            HashSet<int> nextLocal = new HashSet<int>();
            for (int i = 0; i < next.Count; i++)
            {
                var n = next[i];
                if(n.right == end) return true;
                else nextLocal.Add(n.right + 1);
            }

            return BFS(nodes, nextLocal, end);
        }
    }
}
