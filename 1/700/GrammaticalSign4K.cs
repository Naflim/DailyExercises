using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 779. 第K个语法符号
    /// </summary>
    public class GrammaticalSign4K
    {
        public static int KthGrammar(int n, int k)
        {
            List<int> test = new List<int>();

            int num = PointerRecord(test, (int)Math.Pow(2, n-1), k - 1);

            test.ForEach(n => num *= n);
            return num == 1 ? 0 : 1;
        }

        static int PointerRecord(List<int> record, int max, int index)
        {
            switch (index)
            {
                case 0:
                    return 1;
                case 1:
                    return -1;
                default:
                    max /= 2;
                    if (max < index)
                    {
                        record.Add(-1);
                        index -= max;
                        return PointerRecord(record, max, index);
                    }
                    else if (max > index) return PointerRecord(record, max, index);
                    else return -1;
            }
        }
    }
}
