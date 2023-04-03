using System.Linq;

namespace DailyExercises
{
    /// <summary>
    /// 816. 模糊坐标
    /// </summary>
    public class FuzzyCoordinates
    {
        public static IList<string> AmbiguousCoordinates(string s)
        {
            List<string> result = new();
            string nums = new(s.Skip(1).Take(s.Length - 2).ToArray());

            for (int i = 0; i<nums.Length - 1; i++)
            {
                int interval = i+1;
                string left = new(nums.Skip(0).Take(interval).ToArray());
                var lefts = GetAllDouble(left);
                string right = new(nums.Skip(interval).Take(nums.Length - interval).ToArray());
                var rights = GetAllDouble(right);

                if (lefts.Count == 0 || rights.Count == 0) continue;
                lefts.ForEach(l =>
                {
                    rights.ForEach(r =>
                    {
                        result.Add($"({l}, {r})");
                    });
                });
            }
            return result;
        }

        public static List<string> GetAllDouble(string nums)
        {
            int len = nums.Length;
            List<string> result = new();

            if (nums[len - 1] != '0')
            {
                for (int i = 1; i<len; i++)
                {
                    string val = nums.Insert(i, ".");
                    if (!IsOriginalCoordinates(val)) break;
                    result.Add(val);
                }
            }

            if (nums.Length == 1 || nums[0] != '0')result.Add(nums);

            return result;
        }

        public static bool IsOriginalCoordinates(string num)
        {
            return !(num.Length > 1 && num[0] == '0' && num[1] != '.');
        }
    }
}
