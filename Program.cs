using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        //[9,7,6,7,6,9]
        //var val = NextLargerNodes.Run(new ListNode(2, new ListNode(7, new ListNode(4, new ListNode(3, new ListNode(5))))));
        //var val = NextLargerNodes.Run(new ListNode(9, new ListNode(7, new ListNode(6, new ListNode(7, new ListNode(6,new ListNode(9)))))));
        var val = NextLargerNodes.Run(new ListNode(2, new ListNode(1, new ListNode(5))));
        foreach (var item in val)
        {
            Console.WriteLine(item);
        }
    }
}

