using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 371. 两整数之和
    /// </summary>
    internal class GetSum
    {
        public static int Run(int a, int b)
        {
            return BitwiseOperationUtils.Add(a, b);
        }
    }
}
