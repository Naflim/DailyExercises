using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    public class FindMaximumNumber
    {
        public static long Run(long k, int x)
        {
            long left = long.MinValue;
            long right = long.MaxValue;

            long result = 0;
            while (left +1 != right)
            {
                long diff = right - left;
                diff /= 2;
                long pointer = left + diff;

                long price = GetAccumulatedPrice(pointer, x);
                if (price > k) right = pointer;
                else if (price < k) left = pointer;
                else 
                {
                    result = pointer;
                    break;
                }
            }

            if(result == 0) 
                result = left;

            while (GetAccumulatedPrice(result + 1, x) <= k)
                result++;

            return result;
        }

        public static long GetAccumulatedPrice(long num, int x) 
        {
            string binaryString = Convert.ToString(num, 2);

            long result = 0;
            for (int j = binaryString.Length - x; j >= 0; j -= x)
            {
                if (binaryString[j] == '1')
                    result++;
            }
            return 0;
        }

        //public static long GetAccumulatedPriceByDigit(int digit,int x)
        //{
        //    int ratio = digit / x;

        //    if(ratio == 0) 
        //        return 0;



        //    long result = 0;


        //}

        public static long GetAccumulatedPriceByViolence(long num, int x)
        {
            long result = 0;

            for (long i = 1; i <= num; i++)
            {
                string binaryString = Convert.ToString(i, 2);

                for (int j = binaryString.Length - x; j >= 0; j -= x)
                {
                    if (binaryString[j] == '1')
                        result++;
                }
            }

            return result;
        }

    }
}
