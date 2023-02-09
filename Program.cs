using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        //RemoveSubfolders
        //    .Run(new string[] { "/ah/al/am", "/ah/al" })
        //    .ToList()
        //    .ForEach(name => Console.WriteLine(name));

        double a = 3;
        double b = 4;
        double c = 5;

        double angleA = Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * (180 / Math.PI);
        double angleB = Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * (180 / Math.PI);
        double angleC = Math.Acos((a * a + b * b - c * c) / (2 * a * b)) * (180 / Math.PI);

        Console.WriteLine("Angle A is " + angleA + " degrees");
        Console.WriteLine("Angle B is " + angleB + " degrees");
        Console.WriteLine("Angle C is " + angleC + " degrees");


        Console.ReadLine();
    }
}