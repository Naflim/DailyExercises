using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        MKAverage obj = new MKAverage(3, 1);
        obj.AddElement(3);        // 当前元素为 [3]
        obj.AddElement(1);        // 当前元素为 [3,1]
        Console.WriteLine(obj.CalculateMKAverage()); // 返回 -1 ，因为 m = 3 ，但数据流中只有 2 个元素
        obj.AddElement(10);       // 当前元素为 [3,1,10]
        Console.WriteLine(obj.CalculateMKAverage()); // 最后 3 个元素为 [3,1,10]
                                                     // 删除最小以及最大的 1 个元素后，容器为 [3]
                                                     // [3] 的平均值等于 3/1 = 3 ，故返回 3
        obj.AddElement(5);        // 当前元素为 [3,1,10,5]
        obj.AddElement(5);        // 当前元素为 [3,1,10,5,5]
        obj.AddElement(5);        // 当前元素为 [3,1,10,5,5,5]
        Console.WriteLine(obj.CalculateMKAverage()); // 最后 3 个元素为 [5,5,5]
                                                     // 删除最小以及最大的 1 个元素后，容器为 [5]
                                                     // [5] 的平均值等于 5/1 = 5 ，故返回 5

    }
}
