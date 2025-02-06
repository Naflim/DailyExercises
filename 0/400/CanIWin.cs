using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 464. 我能赢吗
    /// </summary>
    internal class CanIWin
    {
        public static bool Run(int maxChoosableInteger, int desiredTotal)
        {
            var sum = maxChoosableInteger * (maxChoosableInteger + 1) / 2;

            if (sum < desiredTotal)
                return false;

            Dictionary<int, bool> map = new Dictionary<int, bool>();

            for (int i = 1; i <= maxChoosableInteger; i++)
            {
                if (GetState(map, 0, i, maxChoosableInteger, desiredTotal, true))
                    return true;
            }

            return false;
        }

        private static bool GetState(Dictionary<int, bool> map, int bin, int num, int maxChoosableInteger, int desiredTotal, bool isMyTurn)
        {
            int sum = 0;

            for (int i = 0; i < maxChoosableInteger; i++)
            {
                int mask = 1 << i;

                if ((bin & mask) != 0)
                {
                    sum += i + 1;
                }
            }

            if (sum + num >= desiredTotal)
                return isMyTurn;

            bin += 1 << (num - 1);

            //预期想赢
            bool result = isMyTurn;
            //主动权在对手手中
            for (int i = 1; i <= maxChoosableInteger; i++)
            {
                int mask = 1 << (i - 1);

                if ((bin & mask) != 0)
                    continue;

                bool state;
                int nextBin = bin + mask;

                if (!map.TryGetValue(nextBin, out state))
                {
                    state = GetState(map, bin, i, maxChoosableInteger, desiredTotal, !isMyTurn);
                    map.Add(nextBin, state);
                }

                //对手一定想让你输
                if (isMyTurn != state) 
                {
                    result = state;
                    break;
                }
            }

            return result;
        }
    }
}
