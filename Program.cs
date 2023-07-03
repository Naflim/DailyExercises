using DailyExercises;
using DailyExercises.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        //ListNode l1 = new ListNode(7, new ListNode(2, new ListNode(4, new ListNode(3))));
        //ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

        //ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        //ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

        ListNode l1 = new ListNode(9, new ListNode(9));
        ListNode l2 = new ListNode(1);

        var val = AddTwoNumbers.Run(l1, l2);
        while (val != null)
        {
            Console.WriteLine(val.val);
            val = val.next;
        }
        Console.ReadLine();
    }
}