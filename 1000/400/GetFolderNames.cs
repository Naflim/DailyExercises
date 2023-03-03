using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1487. 保证文件名唯一
    /// </summary>
    internal class GetFolderNames
    {
        public static string[] Run(string[] names)
        {
            HashSet<string> result = new();
            Dictionary<string, int> resultDic = new();

            foreach (string name in names)
            {
                string newName = name;

                if (result.Contains(name))
                {
                    int count;
                    if (resultDic.ContainsKey(name)) count = resultDic[name];
                    else count = 1;

                    while (result.Contains($"{newName}({count})"))
                    {
                        count++;
                    }
                    result.Add($"{newName}({count})");
                    resultDic[name] = count;
                }
                else result.Add(newName);
            }

            return result.ToArray();
        }
    }
}
