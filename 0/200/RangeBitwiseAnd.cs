namespace DailyExercises
{
    /// <summary>
    /// 201. 数字范围按位与
    /// </summary>
    internal class RangeBitwiseAnd
    {
        public static int Run(int left, int right)
        {
            if (int.LeadingZeroCount(left) == int.LeadingZeroCount(right)) 
            {
                int diff = right - left;
                int diffLen = 32 - int.LeadingZeroCount(diff);
                int newLeft = left >> diffLen;
                int newRight = right >> diffLen;
                int result = (newLeft & newRight) << diffLen;
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}
