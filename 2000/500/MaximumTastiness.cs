using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2517. 礼盒的最大甜蜜度
    /// </summary>
    internal class MaximumTastiness
    {
        public static int Run(int[] price, int k)
        {
            List<int> sortPrice = price.ToList();
            sortPrice.Sort();
            int[] types = new int[k];
            int min = sortPrice[0], max = sortPrice[^1];
            types[0] = min;
            types[^1] = max;
            var diff = (max - min)/(k - 1);
            for (int i = 1; i < k - 1; i++)
            {
                types[i] = types[i - 1] + diff;
            }
            sortPrice.RemoveAt(0);
            sortPrice.RemoveAt(sortPrice.Count - 1);

            for (int i = 1; i < k - 1; i++)
            {
                types[i] = GetNearVal(sortPrice, types[i]);
                if (types[i] == -1)
                    throw new Exception("缺陷");
            }

            int result = int.MaxValue;
            for (int i = 1; i < types.Length; i++)
            {
                result = Math.Min(result, types[i] - types[i - 1]);
            }

            return result;
        }

        public static int GetNearVal(IList<int> price, int target)
        {
            int left = -1, right = price.Count;

            if (target < price[0] || target > price[^1])
                return -1;

            while (left + 1 != right)
            {
                int pointer = (right + left) / 2;
                if (price[pointer] >  target)
                {
                    right = pointer;
                }
                else if (price[pointer] < target)
                {
                    left = pointer;
                }
                else
                {
                    price.RemoveAt(pointer);
                    return target;
                }
            }

            int result;
            if (Math.Abs(price[left] - target) < Math.Abs(price[right] - target))
            {
                result = price[left];
                price.RemoveAt(left);
            }
            else
            {
                result = price[right];
                price.RemoveAt(right);
            }

            return result;
        }

        public static int Run2(int[] price, int k)
        {
            Array.Sort(price);

            int left = -1, right = price[^1];

            while (left + 1 != right)
            {
                int pointer = (right + left) / 2;

                if(IsLegitimate(pointer,price,k))
                    left = pointer;
                else
                    right = pointer;
            }

            return left;
        }

        public static bool IsLegitimate(int x, int[] price, int k)
        {
            int prev = price[0];
            int count = 1;
            for (int i = 1; i < price.Length; i++)
            {
                var now = price[i];
                if (Math.Abs(now - prev) >= x)
                {
                    prev = now;
                    count++;
                    if (count >= k)
                        return true;
                }
            }

            return false;
        }
    }
}
