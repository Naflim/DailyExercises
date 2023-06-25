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
        //// 定义两个点的坐标
        //double x1 = 0;
        //double y1 = 0;
        //double x2 = 1;
        //double y2 = 1;

        //// 计算坐标差值
        //double dx = x2 - x1;
        //double dy = y2 - y1;

        //// 计算差值的平方和
        //double sumOfSquares = Math.Pow(dx, 2) + Math.Pow(dy, 2);

        //// 计算平方和的平方根，即距离
        //double distance = Math.Sqrt(sumOfSquares);

        //Console.WriteLine("两点之间的距离为: " + distance);


        Console.WriteLine(CheckOverlap.Run(2, 8, 6, 5, 1, 10, 4));
        Console.ReadLine();
    }


}

//2
//8
//6
//5
//1
//10
//4

//1
//0
//0
//1
//-1
//3 
//1

//1415
//807
//-784
//-733
//623
//-533
//1005