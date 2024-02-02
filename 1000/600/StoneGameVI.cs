using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1686. 石子游戏 VI
    /// </summary>
    internal class StoneGameVI
    {
        public static int Run(int[] aliceValues, int[] bobValues)
        {
            int stoneCount = aliceValues.Length;

            bool[] takeArr = new bool[aliceValues.Length];

            int aliceScore = 0;
            int bobScore = 0;

            bool isAliceRound = true;

            while (takeArr.Any(v => !v))
            {
                int bestIndex = GetBestStone(aliceValues, bobValues, takeArr, stoneCount);
                if (isAliceRound)
                    aliceScore += aliceValues[bestIndex];
                else
                    bobScore += bobValues[bestIndex];

                isAliceRound = !isAliceRound;

                takeArr[bestIndex] = true;
            }

            if (aliceScore > bobScore)
                return 1;
            else if (aliceScore < bobScore)
                return -1;
            else 
                return 0;
        }

        public static int GetBestStone(int[] aliceValues, int[] bobValues, bool[] takeArr, int stoneCount)
        {
            int bestVal = 0;
            int bestIndex = 0;

            for (int i = 0; i < stoneCount; i++)
            {
                if (takeArr[i])
                    continue;

                int nowVal = aliceValues[i] + bobValues[i];

                if (nowVal > bestVal)
                {
                    bestVal = nowVal;
                    bestIndex = i;
                }
            }

            return bestIndex;
        }

        public static int Run2(int[] aliceValues, int[] bobValues)
        {
            int stoneCount = aliceValues.Length;

            (int,int)[] bestValues = new (int, int)[aliceValues.Length];

            int aliceScore = 0;
            int bobScore = 0;

            bool isAliceRound = true;


            for (int i = 0; i < stoneCount; i++)
            {
                bestValues[i] = (i, aliceValues[i] + bobValues[i]);
            }

            bestValues = bestValues.OrderBy(v => v.Item2).Reverse().ToArray();


            for (int i = 0; i < bestValues.Length; i++)
            {
                if (isAliceRound)
                    aliceScore += aliceValues[bestValues[i].Item1];
                else
                    bobScore += bobValues[bestValues[i].Item1];

                isAliceRound = !isAliceRound;
            }

            if (aliceScore > bobScore)
                return 1;
            else if (aliceScore < bobScore)
                return -1;
            else
                return 0;
        }
    }
}
