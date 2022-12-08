using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1812. 判断国际象棋棋盘中一个格子的颜色
    /// </summary>
    public class SquareIsWhite
    {
        public static bool Run(string coordinates)
        {
            int[] localtion = new int[2];

            localtion[0] = coordinates[0] - 96;
            localtion[1] = coordinates[1] - 48;

            if ((localtion[0] % 2 + localtion[1] % 2) % 2 == 0) return false;
            else return true;
        }
    }
}
