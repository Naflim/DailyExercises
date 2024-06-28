using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises.LCP
{
    /// <summary>
    /// LCP 40. 心算挑战
    /// </summary>
    internal class MaxmiumScore
    {
        public static int Run(int[] cards, int cnt)
        {
            int len = cards.Length;
            Array.Sort(cards);
            var sortCards = cards.Reverse().ToArray();

            var leftArr = sortCards.Take(cnt);
            var rightArr = sortCards.Skip(cnt);

            int sum = leftArr.Sum();

            if (IsOdd(sum))
                return sum;

            if (!rightArr.Any())
                return 0;

            bool hasOdd = rightArr.Any(IsOdd);
            bool hasEven = rightArr.Any(IsEven);

            if (hasOdd && hasEven)
            {
                int result1 = 0;
                if (leftArr.Any(IsEven))
                {
                    result1 = sum;
                    result1 -= leftArr.Last(IsEven);
                    result1 += rightArr.First(IsOdd);
                }

                int result2 = 0;
                if (leftArr.Any(IsOdd))
                {
                    result2 = sum;
                    result2 -= leftArr.Last(IsOdd);
                    result2 += rightArr.First(IsEven);
                }

                return Math.Max(result1, result2);
            }

            if (hasOdd)
            {
                if (!leftArr.Any(IsEven))
                    return 0;

                sum -= leftArr.Last(IsEven);
                sum += rightArr.First();

                return sum;
            }

            if (hasEven)
            {
                if (!leftArr.Any(IsOdd))
                    return 0;

                sum -= leftArr.Last(IsOdd);
                sum += rightArr.First();

                return sum;
            }

            return 0;
        }

        public static bool IsOdd(int num) { return num % 2 == 0; }
        public static bool IsEven(int num) { return num % 2 == 1; }
    }
}
