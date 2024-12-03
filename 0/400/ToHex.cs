using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 405. 数字转换为十六进制数
    /// </summary>
    class ToHex
    {
        private static readonly char[] hexDigits = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'];

        public static string Run(int num)
        {
            if(num < 0)
            {
                int val = Math.Abs(num + 1);
                var hex = SpliceHex(val,string.Empty);
                hex = hex.PadLeft(8, '0');
                string inverseCode = string.Empty;
                foreach(var c in hex)
                {
                    int index = Array.IndexOf(hexDigits, c);
                    inverseCode += hexDigits[15 - index];
                }

                return inverseCode.TrimStart('0');
            }
            else
            {
                return SpliceHex(num, string.Empty);
            }
        }

        public static string SpliceHex(int num, string hex)
        {
            int bin = num % 16;
            string newHex = hexDigits[bin] + hex;

            var newNum = num / 16;

            if (newNum > 0)
            {
                return SpliceHex(newNum, newHex);
            }
            else
            {
                return newHex;
            }
        }
    }
}
