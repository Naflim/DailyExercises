namespace DailyExercises
{
    /// <summary>
    /// 764. 最大加号标志
    /// </summary>
    internal class LargestPlusSign
    {
        public static int OrderOfLargestPlusSign(int n, int[][] mines)
        {
            int sign = 0;

            bool[,] matrix = new bool[n, n];
            for (int i = 0; i<mines.Length; i++)
            {
                var coordinate = mines[i];
                matrix[coordinate[0], coordinate[1]] = true;
            }

            //PrintMatrix(matrix);

            int len = n % 2 == 0 ? n / 2 : n / 2 + 1;

            for (int i = 0; i<len; i++)
            {
                for(int j = i; j < n - i; j++)
                {
                    if (sign != i) break;
                    for(int k = i; k < n - i; k++)
                    {
                        if (CrossCheck(j, k, matrix, i))
                        {
                            sign++;
                            break;
                        }
                    }
                }
            }
            return sign;
        }

        public static bool CrossCheck(int y, int x, bool[,] matrix, int rank)
        {
            if (matrix[y, x]) return false;

            for (int i = 0; i<rank; i++)
            {
                if (matrix[y - i - 1, x] || matrix[y + i + 1, x] || matrix[y, x - i - 1] || matrix[y, x + i + 1]) return false;
            }

            return true;
        }

        public static void PrintMatrix(bool[,] matrix)
        {
            for (int i = 0; i<=matrix.GetUpperBound(0); i++)
            {
                for (var j = 0; j<=matrix.GetUpperBound(0); j++)
                {
                    Console.Write($"{(matrix[i, j] ? 0 : 1)} ");
                }
                Console.WriteLine();
            }
        }
    }
}
