using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1488. 避免洪水泛滥
    /// </summary>
    internal class AvoidFlood
    {
        public static int[] Run(int[] rains)
        {
            //记录湖泊最后存在雨的日期
            Dictionary<int,int> lakes = new Dictionary<int,int>();
            //工作周期
            int[] result = new int[rains.Length];

            for (int i = 0; i < rains.Length; i++)
            {
                var rain = rains[i];
                if(rain == 0)
                {
                    //不下雨意味可以在这天工作
                    //因为0表示不下雨所以不会出现0的湖泊
                    result[i] = 0;
                }
                else
                {
                    result[i] = -1;
                    //如何湖水已经满了的话
                    if (lakes.ContainsKey(rain)) 
                    {
                        //寻找湖水满了后是否有工作日可以抽水
                        bool hasWorkDay = false;
                        for (int j = lakes[rain]; j < i; j++)
                        {
                            if (result[j] == 0)
                            {
                                //有工作日则工作日选择抽此湖水
                                hasWorkDay = true;
                                result[j] = rain;
                                //然后更新湖水存在雨的日期，因为今天下雨又满了
                                lakes[rain] = i;
                                break;
                            }
                        }

                        //没有工作日就说明一定会发洪水
                        if(!hasWorkDay) 
                            return Array.Empty<int>();
                    }
                    else
                    {
                        lakes[rain] = i;
                    }
                }
            }

            //官方用例中空闲工作日都用来填1号湖泊了，不这样用例过不了
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0)
                    result[i] = 1;
            }
            return result;
        }
    }
}
