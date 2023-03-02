using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 面试题 05.02. 二进制数转字符串
    /// </summary>
    internal class PrintBin
    {
        public static string Run(double num)
        {
            double remainder = num % 1;
            string integerBin = Convert.ToString((int)num, 2);
            if (remainder == 0) return integerBin;

            string decimalBin = string.Empty;
            int decimalLen = 32 - integerBin.Length;

            for (int i = 0; i < decimalLen; i++)
            {
                remainder *= 2;

                if (remainder > 1)
                {
                    remainder %= 1;
                    decimalBin += "1";
                }
                else if (remainder < 1)
                {
                    decimalBin += "0";
                }
                else
                {
                    remainder = 0;
                    decimalBin += "1";
                    break;
                }
            }

            if (remainder == 0) return $"{integerBin}.{decimalBin}";
            else return "ERROR";
        }
    }
}
