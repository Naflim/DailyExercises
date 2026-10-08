using DailyExercises;
using DailyExercises.Utils;

class Program
{
    public static void Main()
    {
        int[] arr = new int[] { 10, 20, 20, 30, 30, 30, 30, 40 };
        //int[] arr = [466, 306, 76, 17, 60, 246, 341, 284];

        var result = RemoveOuterParentheses.Run("()()");

        //long val = (long) int.MaxValue * int.MaxValue;
        Console.WriteLine(result);
    }
}
