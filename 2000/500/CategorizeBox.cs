using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2525. 根据规则将箱子分类
    /// </summary>
    internal class CategorizeBox
    {
        public static string Run(int length, int width, int height, int mass)
        {
            bool isBulky = length >= 10e3 || width >= 10e3 || height >= 10e3 || (double)length * width * height >= 10e8;
            bool isHeavy = mass >= 100;

            if(isBulky && isHeavy)
                return "Both";

            if (isBulky)
                return "Bulky";

            if (isHeavy)
                return "Heavy";

            return "Neither";
        }
    }
}
