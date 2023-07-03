using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 445. 两数相加 II
    /// </summary>
    internal class AddTwoNumbers
    {
        public static ListNode Run(ListNode l1, ListNode l2)
        {
            List<int> num1 = new List<int>();
            List<int> num2 = new List<int>();
            List<int> resultList = new List<int>(); 
            ListNode current1 = l1;
            while (current1 != null)
            {
                num1.Add(current1.val);
                current1 = current1.next;
            }
            num1.Reverse();

            ListNode current2 = l2;
            while (current2 != null)
            {
                num2.Add(current2.val);
                current2 = current2.next;
            }
            num2.Reverse();

            int carryVal = 0;

            if(num1.Count < num2.Count) 
            {
                var buffer = num1;
                num1 = num2;
                num2 = buffer;
            }

            for (int i = 0; i < num1.Count; i++)
            {
                if (i < num2.Count)
                {
                    int sum = num1[i] + num2[i];
                    sum += carryVal;

                    carryVal = sum / 10;
                    sum %= 10;
                    resultList.Add(sum);
                }
                else
                {
                    int num = num1[i];
                    if(carryVal != 0)
                    {
                        num += carryVal;
                        carryVal = num / 10;
                        num %= 10;
                    }
                    resultList.Add(num);
                }
            }

            if(carryVal != 0)
            {
                string val = carryVal.ToString();
                foreach(var c in val)
                {
                    resultList.Add(c - 48);
                }
            }

            resultList.Reverse();

            ListNode result = new ListNode(resultList[0]);
            var current = result;

            for (int i = 1; i < resultList.Count; i++)
            {
                current.next = new ListNode(resultList[i]);
                current = current.next;
            }

            return result;
        }
    }
}
