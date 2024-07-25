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
            (string, int)[] keys = new (string, int)[4];
            keys[0] = ("25", 0);
            keys[1] = ("50", 0);
            keys[2] = ("75", 0);
            keys[3] = ("00", 0);

            int len = num.Length;

            for (int i = len - 1; i >= 0; i--)
            {
                switch (num[i])
                {
                    case '0':
                        if (keys[1].Item2 == 0)
                            keys[1].Item2++;

                        keys[3].Item2++;

                        if (keys[3].Item2 == 2)
                        {
                            int val = len - i - 2;
                            return val;
                        }
                        break;
                    case '2':
                        if (keys[0].Item2 == 1)
                        {
                            int val = len - i - 2;
                            return val;
                        }
                        break;
                    case '5':
                        if (keys[0].Item2 == 0)
                            keys[0].Item2++;

                        if (keys[2].Item2 == 0)
                            keys[2].Item2++;

                        if (keys[1].Item2 == 1)
                        {
                            int val = len - i - 2;
                            return val;
                        }
                        break;
                    case '7':
                        if (keys[2].Item2 == 1)
                        {
                            int val = len - i - 2;
                            return val;
                        }
                        break;
                }
            }

            return len - keys[3].Item2;
        }
    }
}
