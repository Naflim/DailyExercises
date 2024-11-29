using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 397. 整数替换
    /// </summary>
    internal class IntegerReplacement
    {
        public static int Run(int n)
        {
            HashSet<int> visited = new HashSet<int>();
            int start = 1;

            if (n == start)
                return 0;

            visited.Add(start);
            List<int> vals = [start];

            int count = 0;
            while (vals.Count > 0)
            {
                List<int> tmp = new List<int>();

                int CheckVal(int val)
                {
                    if (val == n)
                        return 1;

                    if (visited.Contains(val))
                        return -1;

                    visited.Add(val);
                    tmp.Add(val);

                    return 0;
                }
                foreach (int val in vals)
                {
                    if ((val & 1) == 1)
                    {
                        var v = val << 1;

                        if (CheckVal(v) == 1)
                            return count + 1;
                    }
                    else
                    {
                        var val1 = val + 1;
                        var val2 = val - 1;
                        var val3 = val << 1;

                        if (CheckVal(val1) == 1 || CheckVal(val2) == 1 || CheckVal(val3) == 1)
                            return count + 1;
                    }
                }

                vals = tmp;
                count++;
            }

            return -1;
        }

        public static int Run2(int n)
        {
            int count = 0;
            int start = 32 - int.LeadingZeroCount(n) - 1;

            for (int i = start; i >= 0; i--)
            {
                int mask = 1 << i;

                if ((n & mask) == 0)
                {
                    count++;
                }
                else
                {
                    bool isStart = i == start;
                    if (!isStart)
                        count += 2;

                    int tmp = 0;
                    while (i > 0)
                    {
                        i--;
                        mask = 1 << i;
                        if ((n & mask) == 0)
                            break;
                        tmp++;
                    }

                    if (tmp != 0)
                    {
                        if (tmp < 2)
                        {
                            count += tmp * 2;
                        }
                        else
                        {
                            count += tmp + 2;
                            if (!isStart)
                                count--;
                        }
                    }

                    if ((n & mask) == 0)
                        count++;
                }
            }

            return count;
        }

        public static int Run3(int n) 
        {
            int count = 0;
            long val = n;

            while (val != 1)
            {
                if (val == 3)
                {
                    return count + 2;
                }
                else
                {
                    if ((val & 1) == 0)
                    {
                        count++;
                        val >>= 1;
                    }
                    else
                    {
                        if ((val & 2) == 0)
                        {
                            count++;
                            val--;
                        }
                        else
                        {
                            count++;
                            val++;
                        }
                    }
                }
            }

            return count;
        }
    }
}
