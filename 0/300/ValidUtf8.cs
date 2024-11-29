using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 393. UTF-8 编码验证
    /// </summary>
    internal class ValidUtf8
    {
        public static bool Run(int[] data)
        {
            int count = 0;

            foreach (int val in data) 
            {
                if(count == 0)
                {
                    for (int i = 7; i >= 0; i--) 
                    {
                        int mask = 1 << i;
                        if((val & mask) != 0)
                            count++;
                        else
                            break;
                    }

                    if(count > 0) 
                    {
                        if (count == 1 || count > 4)
                            return false;
                        else
                            count--;
                    }
                }
                else
                {
                    int mask1 = 1 << 7;
                    int mask2 = 1 << 6;
                    if((val & mask1) == 0 || (val & mask2) != 0)
                        return false;

                    count--;
                }
            }

            return count == 0;
        }
    }
}
