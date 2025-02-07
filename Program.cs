using DailyExercises;
using DailyExercises.Utils;

class Program
{
    public static void Main()
    {
        int[] arr1 = [1];
        int[] arr2 = [1,1];

        //int[] arr1 = IOUtils.GetArrByFile(@"C:\Users\Naflim\Desktop\data.txt");
        //int[] arr2 = IOUtils.GetArrByFile(@"C:\Users\Naflim\Desktop\data2.txt");

        var result = AddNegabinary.Run3(arr1, arr2);

        string log = string.Join(",", result);
        Console.WriteLine(log);
    }
}
