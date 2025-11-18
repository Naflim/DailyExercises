using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 717. 1 比特与 2 比特字符
    /// </summary>
    internal class IsOneBitCharacter
    {
        public static bool Run(int[] bits)
        {
            bool result = false;
            for (int i = 0; i < bits.Length; i++) 
            {
                if (bits[i] == 0) 
                {
                    result = true;
                }
                else
                {
                    result = false;
                    i++;
                }
            }

            return result;
        }
    }
}
