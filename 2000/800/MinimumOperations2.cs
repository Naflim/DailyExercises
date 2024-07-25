using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2844. 生成特殊数字的最少操作
    /// </summary>
    internal class MinimumOperations2
    {
        public static int Run(string num)
        {
            (string, int, bool)[] keys = new (string, int, bool)[4];
            keys[0] = ("25", 0, false);
            keys[1] = ("50", 0, false);
            keys[2] = ("75", 0, false);
            keys[3] = ("00", 0, false);

            int len = num.Length;

            for (int i = len - 1; i >= 0; i--)
            {
                switch (num[i])
                {
                    case '0':
                        if (!keys[1].Item3 && keys[1].Item2 == 0)
                            keys[1].Item2++;

                        if (!keys[3].Item3)
                        {
                            keys[3].Item2++;

                            if (keys[3].Item2 == 2)
                            {
                                int val = len - i - 2;
                                keys[3] = ("00", val, true);
                            }
                        }
                        break;
                    case '2':
                        if (!keys[0].Item3 && keys[0].Item2 == 1)
                        {
                            int val = len - i - 2;
                            keys[0] = ("25", val, true);
                        }
                        break;
                    case '5':
                        if (!keys[0].Item3 && keys[0].Item2 == 0)
                            keys[0].Item2++;

                        if (!keys[2].Item3 && keys[2].Item2 == 0)
                            keys[2].Item2++;

                        if (!keys[1].Item3 && keys[1].Item2 == 1)
                        {
                            int val = len - i - 2;
                            keys[1] = ("50", val, true);
                        }
                        break;
                    case '7':
                        if (!keys[2].Item3 && keys[2].Item2 == 1)
                        {
                            int val = len - i - 2;
                            keys[2] = ("75", val, true);
                        }
                        break;
                }
            }

            if (keys.Any(v => v.Item3))
            {
                return keys.Where(v => v.Item3).Min(v => v.Item2);
            }
            else
            {
                return len - keys[3].Item2;
            }
        }
    }
}
