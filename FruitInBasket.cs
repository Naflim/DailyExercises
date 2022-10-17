/*************************************************************************************
 *
 * 文 件 名:   FruitInBasket
 * 描    述:   水果成篮  
 * 
 * 版    本：  V1.0
 * 创 建 者：  柯懿
 * 创建时间：  2022/10/17 18:15:14
 * ======================================
 * 历史更新记录
 * 版本：V          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    internal class FruitInBasket
    {
        public static int TotalFruit(int[] fruits)
        {
            int max = 0;
            int basketA = 0, basketB = 0;

            int count = 0, last = 0, repeat = 1;
            for (int i = 0; i<fruits.Length; i++)
            {
                if (i == 0)
                {
                    basketA = fruits[i];
                    basketB = fruits[i];
                    last = basketA;
                    count++;
                }
                else
                {
                    if (basketA == fruits[i]||basketB == fruits[i]) count++;
                    else
                    {
                       
                        if(max == 0) 
                        {
                            max = Math.Max(max, count);
                            count++;
                        }
                        else
                        {
                            max = Math.Max(max, count);
                            count = repeat + 1;
                        }
                        if (last == basketA)basketB = fruits[i];
                        else basketA = fruits[i];
                    }

                    if (last == fruits[i]) repeat++;
                    else repeat = 1;
                    last =  fruits[i];
                }
            }
            return Math.Max(max, count); 
        }
    }
}
