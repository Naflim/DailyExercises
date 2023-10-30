using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 275. H 指数 II
    /// </summary>
    internal class HIndex
    {
        public static int Run(int[] citations)
        {
            if(citations.Length == 1)
                return citations[0] > 0 ? 1 : 0;

            for (int i = citations.Length; i > 0; i--)
            {
                if (IsHC(citations, i))
                    return i;
            }

            return 0;
        }

        public static int Run2(int[] citations)
        {
            int left = -1, right = citations.Length;

            while (left + 1 != right)
            {
                var pointer = (left + right) / 2;

                if (citations[pointer] < pointer)
                {
                    left = pointer;
                }
                else
                {
                    right = pointer;
                }
            }

            return right;
        }

        public static int Run3(int[] citations)
        {
            int n = citations.Length;
            int left = 0, right = n - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (citations[mid] >= n - mid)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return n - left;
        }

        public static bool IsHC(int[] citations,int citation) 
        {
            int left = -1,right = citations.Length;

            while(left + 1 != right)
            {
                var pointer = (left + right) / 2;
                if (citations[pointer] < citation)
                {
                    left = pointer;
                }
                else if (citations[pointer] > citation)
                {
                    right = pointer;
                }
                else
                {
                    for (int i = pointer; i > left; i--)
                    {
                        if (citations[i] == citation)
                            right = i;
                        else
                            break;
                    }
                    break;
                }
            }

            if (citations.Length - right >= citation)
                return true;
            else
                return false;
        }
    }
}
