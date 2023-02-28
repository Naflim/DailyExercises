namespace DailyExercises
{
    /// <summary>
    /// 2363. 合并相似的物品
    /// </summary>
    public class MergeSimilarItems
    {
        public static IList<IList<int>> Run(int[][] items1, int[][] items2)
        {
            SortedDictionary<int, int> priceMenu = new();

            for (int i = 0; i < items1.Length; i++)
            {
                var val = items1[i];

                if (priceMenu.ContainsKey(val[0])) priceMenu[val[0]] += val[1];
                else priceMenu[val[0]] = val[1];
            }

            for (int i = 0; i < items2.Length; i++)
            {
                var val = items2[i];

                if (priceMenu.ContainsKey(val[0])) priceMenu[val[0]] += val[1];
                else priceMenu[val[0]] = val[1];
            }

            return priceMenu.Select(v => new int[] { v.Key, v.Value }).ToArray();
        }
    }
}
