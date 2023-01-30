using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1669. 合并两个链表
    /// </summary>
    internal class MergeInBetween
    {
        public static ListNode Run(ListNode list1, int a, int b, ListNode list2)
        {
            ListNode? start;

            if (a < 0) throw new IndexOutOfRangeException("参数a不能小于0");
            else if (a == 0) start = null;
            else start = list1;

            for (int i = 1; i < a; i++)
            {
                start = start.next;
            }

            if (b < a) throw new IndexOutOfRangeException("参数b不能小于a");

            ListNode end = start?.next.next??list1.next;

            for(int i = 0;i< b - a; i++)
            {
                end = end.next;
            }

            start.next = list2;
            GetLastNode(list2).next = end;

            return list1;
        }

        public static ListNode? GetListNode(IEnumerable<int> nums)
        {
            ListNode? head = null;
            ListNode? node = null;

            foreach (var num in nums)
            {
                if (node == null) head = node = new ListNode(num);
                else
                {
                    node.next = new ListNode(num);
                    node = node.next;
                }
            }

            return head;
        }

        public static ListNode GetLastNode(ListNode node)
        {
            while (node.next != null) node = node.next;

            return node;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}