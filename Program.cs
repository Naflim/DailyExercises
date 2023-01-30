using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {

        var val = MergeInBetween.Run(MergeInBetween.GetListNode(new int[] { 0, 1, 2, 3, 4, 5, 6 }), 2, 5, MergeInBetween.GetListNode(new int[] { 1000000, 1000001, 1000002, 1000003, 1000004 }));

        while (val != null) 
        {
            Console.WriteLine(val.val);
            val = val.next;
        }
    }
}
