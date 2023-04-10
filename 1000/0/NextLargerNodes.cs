using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1019. 链表中的下一个更大节点
    /// </summary>
    public class NextLargerNodes
    {
        public static int[] Run(ListNode head)
        {
            List<int> list = new();

            var current = head;
            while (current != null)
            {
                list.Add(current.val);
                current = current.next;
            }

            int[] result = new int[list.Count];

            Stack<(int, int)> stack = new();
            stack.Push((0, list[0]));

            for (int i = 1; i<list.Count; i++)
            {
                if (list[i] < stack.Peek().Item2)
                {
                    stack.Push((i, list[i]));
                }
                else
                {
                    while (stack.Count != 0 && stack.Peek().Item2 < list[i])
                        result[stack.Pop().Item1] = list[i];

                    stack.Push((i, list[i]));
                }
            }

            return result;
        }
    }
}
