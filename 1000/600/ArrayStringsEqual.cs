
namespace DailyExercises
{
    /// <summary>
    /// 1662. 检查两个字符串数组是否相等
    /// </summary>
    internal class ArrayStringsEqual
    {
        public static bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            return string.Join(string.Empty, word1) == string.Join(string.Empty, word2);
        }
    }
}
