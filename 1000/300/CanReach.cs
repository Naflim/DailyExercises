using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1306. 跳跃游戏 III
    /// </summary>
    internal class CanReach
    {
        public static bool Run(int[] arr, int start)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            HashSet<int> visited = new HashSet<int>();  
            while (q.Count > 0) 
            {
                var pointer = q.Dequeue();
                if (arr[pointer] == 0)
                    return true;

                visited.Add(pointer);

                int left = pointer - arr[pointer];
                if(left >= 0 && !visited.Contains(left)) 
                    q.Enqueue(left);

                int right = pointer + arr[pointer];
                if(right < arr.Length && !visited.Contains(right))
                    q.Enqueue(right);
            }

            return false;
        }
    }
}
