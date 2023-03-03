using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises.Utils
{
    internal class IOUtils
    {
        public static int[] GetDataByFile(string path)
        {
            string data = File.ReadAllText(path);

            data = data.Substring(1, data.Length - 2);

            string[] numList = data.Split(",");
            return numList.Select(x => Convert.ToInt32(x)).ToArray();
        }

        public static string[] GetStringDataByFile(string path,Func<string,string>? convert = null)
        {
            string data = File.ReadAllText(path);

            data = data.Substring(1, data.Length - 2);

            string[] datas = data.Split(",");

            if(convert != null) return datas.Select(convert).ToArray();
            else return datas;
        }
    }
}
