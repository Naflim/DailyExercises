using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1419. 数青蛙
    /// </summary>
    internal class MinNumberOfFrogs
    {
        public static int Run(string croakOfFrogs)
        {
            List<char> frog = new();

            foreach (char croak in croakOfFrogs)
            {
                int frogIndex = frog.IndexOf(croak);
                if (frogIndex == -1)
                {
                    if (croak != 'c')
                    {
                        return -1;
                    }
                    else
                    {
                        int idleIndex = frog.IndexOf(default);
                        if (idleIndex != -1)
                        {
                            frog[idleIndex] = Next(croak);
                        }
                        else
                        {
                            frog.Add(Next(croak));
                        }
                    }
                }
                else
                {
                    frog[frogIndex] = Next(croak);
                }
            }

            if (frog.Any(c => c != default)) return -1;
            else return frog.Count;
        }

        private static char Next(char croak)
        {
            return croak switch
            {
                'c' => 'r',
                'r' => 'o',
                'o' => 'a',
                'a' => 'k',
                _ => default,
            };
        }
    }
}
