namespace DailyExercises;

class Program
{
    public static void Main()
    {
        Console.WriteLine(MaximumUnitsNum.MaximumUnits(new int[][]
        {
            new int[]{1,3},
             new int[]{5,5},
              new int[]{ 2,5 },
              new int[]{ 4,2 },
               new int[]{ 4,1 },
                new int[]{3,1 }, new int[]{ 2,2 },
                new int[]{ 1,3 },
                new int[]{ 2,5},new int[]{ 3, 2 }
        }, 35));

        Console.ReadLine();
    }
}