using Naflim.DevelopmentKit.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 421. 数组中两个数的最大异或值
    /// </summary>
    internal class FindMaximumXOR
    {
        public static int Run(int[] nums)
        {
            int max = nums.Max();

            int len = 32 - int.LeadingZeroCount(max);

            List<int> zeros = new List<int>();
            List<int> ones = new List<int>();

            for (int i = len; i >= 0; i--)
            {
                int mask = 1 << i;

                List<int> zs = new List<int>();
                List<int> os = new List<int>();
                foreach (int num in nums)
                {
                    if ((num & mask) == 0)
                        zs.Add(num);
                    else
                        os.Add(num);
                }

                if (zs.Count != 0 && os.Count != 0)
                {
                    zeros = zs;
                    ones = os;
                    break;
                }
            }

            if (zeros.Count == 0)
                return 0;

            len--;

            List<int>[,] dic = new List<int>[len, 2];

            for (int i = 0; i < len; i++)
            {
                int mask = 1 << i;
                dic[i, 0] = new List<int>();
                dic[i, 1] = new List<int>();
                foreach (int zero in zeros)
                {
                    if ((zero & mask) == 0)
                        dic[i, 0].Add(zero);
                    else
                        dic[i, 1].Add(zero);
                }
            }

            int result = 0;

            int maxResult = (1 << len + 1) - 1;

            foreach (int one in ones)
            {
                int xor = GetMaxXOR(one, len - 1, dic, []);

                if (xor == maxResult)
                    return maxResult;

                result = Math.Max(result, xor);
            }

            return result;
        }

        private static int GetMaxXOR(int num, int bin, List<int>[,] dic, IEnumerable<int> alternative)
        {
            if (bin < 0)
            {
                return 1 << (32 - int.LeadingZeroCount(num) - 1);
            }

            HashSet<int> hash = new HashSet<int>(alternative);
            int bit = (num & (1 << bin)) == 0 ? 1 : 0;

            if (hash.Count == 0)
            {
                var next = dic[bin, bit];
                return next.Count switch
                {
                    1 => num ^ next[0],
                    _ => GetMaxXOR(num, bin - 1, dic, next),
                };
            }
            else
            {
                var next = dic[bin, bit];
                hash.IntersectWith(next);
                return hash.Count switch
                {
                    0 => GetMaxXOR(num, bin - 1, dic, alternative),
                    1 => num ^ hash.First(),
                    _ => GetMaxXOR(num, bin - 1, dic, hash),
                };
            }
        }

        public static int Run2(int[] nums)
        {
            int max = nums.Max();

            int len = 32 - int.LeadingZeroCount(max);

            nums = nums.Distinct().ToArray();

            List<int> zeros = new List<int>();
            List<int> ones = new List<int>();

            for (int i = len; i >= 0; i--)
            {
                int mask = 1 << i;

                List<int> zs = new List<int>();
                List<int> os = new List<int>();
                foreach (int num in nums)
                {
                    if ((num & mask) == 0)
                        zs.Add(num);
                    else
                        os.Add(num);
                }

                if (zs.Count != 0 && os.Count != 0)
                {
                    zeros = zs;
                    ones = os;
                    break;
                }
            }

            if (zeros.Count == 0)
                return 0;

            len--;

            Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();

            foreach (int zero in zeros)
            {
                string key = string.Empty;

                for (int i = len - 1; i >= 0; i--)
                {
                    int mask = 1 << i;
                    char bit = (zero & mask) == 0 ? '0' : '1';
                    key += bit;
                    dic.AddGruopItem(key, zero);
                }
            }

            int result = 0;
            int maxResult = (1 << len + 1) - 1;

            foreach (int one in ones)
            {
                int xor = GetMaxXOR(one, string.Empty, dic, len - 1);

                if (xor == maxResult)
                    return maxResult;

                result = Math.Max(result, xor);
            }

            return result;
        }

        private static int GetMaxXOR(int num, string key, Dictionary<string, List<int>> dic, int binLen)
        {
            if (string.IsNullOrEmpty(key))
            {
                int bit = (num & (1 << binLen)) == 0 ? 1 : 0;
                key += bit.ToString();
            }

            while (true)
            {
                if (dic.TryGetValue(key, out List<int>? value))
                {
                    var list = value;
                    if (list.Count == 1)
                    {
                        return num ^ list[0];
                    }
                    else
                    {
                        int bin = binLen - key.Length;
                        int bit = (num & (1 << bin)) == 0 ? 1 : 0;
                        key += bit.ToString();
                    }
                }
                else
                {
                    char modify = key.Last() == '0' ? '1' : '0';
                    key = key[..^1] + modify;

                    if (!dic.ContainsKey(key))
                        return 1 << (32 - int.LeadingZeroCount(num) - 1);
                }
            }
        }
    }
}
