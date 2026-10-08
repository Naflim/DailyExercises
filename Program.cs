using DailyExercises;
using DailyExercises.Utils;

class Program
{
    public static void Main()
    {

        var result = RemoveOuterParentheses.Run("()()");

        Console.WriteLine(result);
    }
}
