using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 29. 两数相除
    /// </summary>
    internal class Divide
    {
        public static int Run(int dividend, int divisor)
        {
            return BitwiseOperationUtils.Divide(dividend, divisor);
        }
    }
}
