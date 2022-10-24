using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 6224. 最大公因数等于 K 的子数组数目
    /// </summary>
    internal class GreatestCommonFactorIsK
    {
        public static int SubarrayGCD(int[] nums, int k)
        {
            List<List<int>> commonFactors = new();
            int count = 0;

            count += nums.Count(n => n==k);

            //第一次过滤，取所有可被k整除的数
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] % k == 0)
                {
                    List<int> block = new() { nums[i] };
                    for (int j = i+1; j<nums.Length;j++)
                    {
                        i = j;
                        if (nums[j] % k == 0)block.Add(nums[j]);
                        else break;
                    }
                    commonFactors.Add(block);
                }
            }

            List<List<int>> highRatioFactors = new();
            
            //第二次过滤取所有倍数高于k的数
            commonFactors.ForEach(factor =>
            {
                count += GetCombinationsCount(factor);
                for (int i = 0; i < factor.Count; i++)
                {
                    if (factor[i] / k > 1)
                    {
                        List<int> block = new() { factor[i] };
                        for (int j = i+1; j<factor.Count; j++)
                        {
                            i = j;
                            if (factor[j] / k > 1) block.Add(factor[j]);
                            else break;
                        }
                        highRatioFactors.Add(block);
                    }
                }
            });

            List<List<int>> specialFactors = new();

            //第三次过滤，取所有公因数大于k的数
            highRatioFactors.ForEach(factor => GetSpecialFactors(specialFactors, factor, k));

            specialFactors.ForEach(factor => 
            {
                //所有可被k整除的数减去公因数大于k的数
                if (factor.Count > 1) count -= GetCombinationsCount(factor);
            });

            return count;
        }

        /// <summary>
        /// 获取公因数大于k（GCD）的组合数
        /// </summary>
        /// <param name="specialFactors"></param>
        /// <param name="source"></param>
        /// <param name="GCD"></param>
        public static void GetSpecialFactors(List<List<int>> specialFactors,List<int> source,int GCD)
        {
            if (source.Count<=1) return;
            for(int i= source.Count; i>1; i--)
            {
                for(int j=0;j<=source.Count-i; j++)
                {
                    var buffer = source.Skip(j).Take(i);
                    if (GetGreatestCommonDivisor(buffer) != GCD)
                    {
                        if (j>1) GetSpecialFactors(specialFactors, source.Take(j).ToList(), GCD);
                        int endLen = source.Count - i - j;
                        if (endLen>1) GetSpecialFactors(specialFactors, source.Skip(i+j).Take(endLen).ToList(), GCD);
                        specialFactors.Add(buffer.ToList());
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 获取组合数
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        static int GetCombinationsCount(IEnumerable<int> list)
        {
            int count = 0;
            for (int i = 1; i < list.Count(); i++) count+=i;
            return count;
        }


        /// <summary>
        /// 求公因数（暴力枚举）
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int GetGreatestCommonDivisor(IEnumerable<int> arr)
        {
            int gcd = 1;
            int min = arr.Min();
            if (min == 0) return 0;
            for (int i = 1; i <= min; i++)
            {
                if (arr.Count(num => num%i==0) == arr.Count()) gcd = i;
            }
            return gcd;
        }
    }
}