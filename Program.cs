using DailyExercises;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        List<int> list = new List<int> { 1,2,3};
        ObservableCollection<int> ints= new ObservableCollection<int>(list);
        ints.RemoveAt(0);
        Console.WriteLine(list.Count);
        Console.WriteLine(ints.Count);
        Console.ReadLine();
    }
}
