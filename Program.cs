using DailyExercises;
using DailyExercises.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    public static void Main()
    {
        //var val = new int[][]
        //{
        //    new int[] { 5,4 },
        //    new int[] { 6,4 },
        //    new int[] { 6,7 },
        //    new int[] { 2,3 },
        //};
        // var val = new int[][]
        //{
        //     new int[] { 1,1 },
        //     new int[] { 1,1 },
        //     new int[] { 1,1 },
        //};

        string json = File.ReadAllText("C:\\Users\\Naflim\\Desktop\\data.txt");
        int[][] val = JsonConvert.DeserializeObject<int[][]>(json);

      //  var val = new int[][]
      //{
      //      new int[] { 4,5 },
      //      new int[] { 4,6 },
      //      new int[] { 6,7 },
      //      new int[] { 2,3 },
      //      new int[] { 1,1 },
      //};

        Console.WriteLine(MaxEnvelopes.Run2(val));
        Console.ReadLine();
    }
}
//[[5,4],[6,4],[6,7],[2,3]]

//[[4,5],[4,6],[6,7],[2,3],[1,1]]