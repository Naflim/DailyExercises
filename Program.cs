using DailyExercises;
using DailyExercises.Utils;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        string[] data = IOUtils.GetStringDataByFile("C:\\Users\\Naflim\\Desktop\\data.txt",v=>v.TrimStart('\"').TrimEnd('\"'));

        foreach (var item in GetFolderNames.Run(data))
        {
            Console.WriteLine(item);
        }

        //foreach (var item in GetFolderNames.Run(new string[]
        //{
        // "kaido","kaido(1)","kaido","kaido(1)","kaido(2)"
        //}))
        //{
        //    Console.WriteLine(item);
        //}
    }
}