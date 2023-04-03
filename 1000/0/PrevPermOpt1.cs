using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1053. 交换一次的先前排列
    /// </summary>
    public class PrevPermOpt1
    {
        public static int[] Run(int[] arr)
        {
            int len = arr.Length;

            int left = int.MinValue, right = -1, rightNum = int.MinValue;
            for (int i = len - 1; i > 0; i--)
            {
                for (int j = i-1; j >= 0; j--)
                {
                    if (arr[i] < arr[j])
                    {
                        if (j > left || (j==left && arr[i] > rightNum) || (j==left && arr[i] == rightNum && i < right))
                        {
                            left = j;
                            right = i;
                            rightNum = arr[i];
                        }
                        break;
                    }
                }
            }

            if (left != int.MinValue) (arr[left], arr[right]) = (arr[right], arr[left]);
            return arr;
        }
    }
}
