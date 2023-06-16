using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    internal class MaximumTastiness
    {
        public static int Run(int[] price, int k)
        {
            List<int> sortPrice = price.ToList();
            sortPrice.Sort();
            int[] types = new int[k];
            int min = sortPrice[0],max = sortPrice[^1];
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
            }

            int result = int.MaxValue;
            for (int i = 1; i < types.Length; i++)
            {
                result = Math.Min(result, types[i] - types[i - 1]);
            }

            return result;
        }

        public static int GetNearVal(List<int> price,int target)
        {
            int left = -1, right = price.Count;

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
    }
}
