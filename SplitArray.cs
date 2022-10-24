namespace DailyExercises
{
    /// <summary>
    /// 915. 分割数组
    /// </summary>
    internal class SplitArray
    {
        public static int PartitionDisjoint(int[] nums)
        {
            return GetLeftArrayEndIndex(nums, 0) + 1;
        }

        public static int GetLeftArrayEndIndex(int[] nums, int startIndex)
        {
            int leftMaxNum = nums[startIndex];

            int newStartIndex = startIndex;
            int endIndex = startIndex;
            for (int i = startIndex + 1; i < nums.Length; i++)
            {
                int nowNum = nums[i];
                if (leftMaxNum<=nowNum)
                {
                    if (nums[newStartIndex]<nowNum) newStartIndex = i;
                }
                else
                {
                    if (newStartIndex != startIndex) return GetLeftArrayEndIndex(nums, newStartIndex);
                    endIndex = i;
                }
            }

            return endIndex;
        }
    }
}
