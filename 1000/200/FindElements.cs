using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1261. 在受污染的二叉树中查找元素
    /// </summary>
    internal class FindElements
    {
        private TreeNode _root;
        private HashSet<int> _values;

        public FindElements(TreeNode root)
        {
            _root = root;
            _values = new HashSet<int>();

            root.val = 0;
            _values.Add(0);

            if(root.left != null) 
                Reduction(root,true);

            if (root.right != null)
                Reduction(root, false);
        }

        public void Reduction(TreeNode node, bool isLeft)
        {
            TreeNode now;
            if(isLeft) 
            {
                Debug.Assert(node.left != null);
                now = node.left;
                now.val = 2 * node.val + 1;
            }
            else
            {
                Debug.Assert(node.right != null);
                now = node.right;
                now.val = 2 * node.val + 2;
            }

            _values.Add(now.val);

            if(now.left != null)
                Reduction(now, true);

            if (now.right != null) 
                Reduction(now, false);
        }

        public bool Find(int target)
        {
            return _values.Contains(target);
        }
    }
}
