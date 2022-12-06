using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    internal class NumDifferentIntegers
    {
        public static int Run(string word)
        {
            List<string> nums = new();

            string buffer = string.Empty;
            foreach (var c in word)
            {
                if ('0'<=c&&c<='9')
                {
                    buffer += c;
                }
                else
                {
                    if (buffer != string.Empty)
                    {
                        int i;
                        for (i=0; i<buffer.Length; i++)
                        {
                            if (buffer[i] != '0') break;
                        }

                        nums.Add(new string(buffer.Skip(i).Take(buffer.Length - i).ToArray()));
                        buffer = string.Empty;
                    }
                }
            }

            if (buffer != string.Empty)
            {
                int i;
                for (i=0; i<buffer.Length; i++)
                {
                    if (buffer[i] != '0') break;
                }

                nums.Add(new string(buffer.Skip(i).Take(buffer.Length - i).ToArray()));
            }

            return nums.Distinct().Count();
        }
    }
}
