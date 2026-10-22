using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 3942. 排序排列的最少操作数
    /// </summary>
    internal class MinOperations3
    {
        public static int Run(int[] nums)
        {
            int zIndex = Array.IndexOf(nums, 0);
            if (zIndex == -1)
                return -1;

            if (nums.Length == 1)
                return 0;

            int leftCount = zIndex;
            int rightCount = nums.Length - zIndex - 1;
            int leftIndex = zIndex == 0 ? nums.Length - 1 : zIndex - 1;
            int rightIndex = zIndex == nums.Length - 1 ? 0 : zIndex + 1;

            if (nums[leftIndex] != 1 && nums[rightIndex] != 1)
                return -1;

            bool needReversal = nums[rightIndex] != 1;
            int diff = rightCount - leftCount;
            int index = 0;

            if (needReversal)
            {
                for (int i = zIndex; i >= 0; i--)
                {
                    if (nums[i] != index)
                    {
                        return -1;
                    }
                    index++;
                }

                for (int i = nums.Length - 1; i > zIndex; i--)
                {
                    if (nums[i] != index)
                    {
                        return -1;
                    }
                    index++;
                }
            }
            else
            {                
                for (int i = zIndex; i < nums.Length; i++)
                {
                    if(nums[i] != index)
                    {
                        return -1;
                    }
                    index++;
                }

                for (int i = 0; i < zIndex; i++)
                {
                    if (nums[i] != index)
                    {
                        return -1;
                    }
                    index++;
                }
            }

            if (diff > 0)
            {
                return needReversal ? leftCount + 2 : leftCount;
            }
            else
            {
                if (needReversal)
                {
                    return rightCount + 1;
                }
                else
                {
                    if (Math.Abs(diff) > 2)
                    {
                        return rightCount + 3;
                    }
                    else
                    {
                        return leftCount;
                    }
                }
            }
        }
    }
}
