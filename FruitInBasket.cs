namespace DailyExercises
{
    /// <summary>
    /// 水果成篮
    /// </summary>
    internal class FruitInBasket
    {
        public static int TotalFruit(int[] fruits)
        {
            int max = 0;
            int basketA = 0, basketB = 0;

            int count = 0, last = 0, repeat = 1;
            for (int i = 0; i<fruits.Length; i++)
            {
                if (i == 0)
                {
                    basketA = fruits[i];
                    basketB = fruits[i];
                    last = basketA;
                    count++;
                }
                else
                {
                    if (basketA == fruits[i]||basketB == fruits[i]) count++;
                    else
                    {
                       
                        if(max == 0) 
                        {
                            max = Math.Max(max, count);
                            count++;
                        }
                        else
                        {
                            max = Math.Max(max, count);
                            count = repeat + 1;
                        }
                        if (last == basketA)basketB = fruits[i];
                        else basketA = fruits[i];
                    }

                    if (last == fruits[i]) repeat++;
                    else repeat = 1;
                    last =  fruits[i];
                }
            }
            return Math.Max(max, count); 
        }
    }
}
