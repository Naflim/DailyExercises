using DailyExercises;
using DailyExercises.Utils;

class Program
{
    public static void Main()
    {
        var arr = IOUtils.GetArrByFile(@"C:\Users\Naflim\Desktop\data.txt");
        //int[] arr = [3, 10, 5, 25, 2, 8];
        Console.WriteLine(FindMaximumXOR.Run2(arr));
    }
}
