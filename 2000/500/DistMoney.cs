using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2591. 将钱分给最多的儿童
    /// </summary>
    internal class DistMoney
    {
        public static int Run(int money, int children)
        {
            int[] childrenMoney = new int[children];
            money -= children;

            if (money < 0)
                return -1;

            for (int i = 0; i < children; i++)
            {
                if(money >= 7)
                {
                    childrenMoney[i] = 8;
                    money -= 7;
                }
                else
                {
                    childrenMoney[i] = 1 + money;
                    money = 0;
                    break;
                }
            }

            if (money > 0)
                return children - 1;

            int result = childrenMoney.Count(m => m == 8);

            if (!childrenMoney.Any(m => m == 4))
                return result;

            if (children - result > 1)
                return result;
            else
                return result - 1;
        }
    }
}
