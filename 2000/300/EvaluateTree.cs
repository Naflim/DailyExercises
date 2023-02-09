using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2331. 计算布尔二叉树的值
    /// </summary>
    internal class EvaluateTree
    {
        public static bool Run(TreeNode root)
        {
            switch (root.val)
            {
                case 0:
                    return false;
                case 1:
                    return true;
                case 2:
                    return Run(root.left) || Run(root.right);
                case 3:
                    return Run(root.left) && Run(root.right);
                default: return false;
            }
        }
    }
}
