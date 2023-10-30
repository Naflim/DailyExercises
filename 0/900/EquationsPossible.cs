using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 990. 等式方程的可满足性
    /// </summary>
    internal class EquationsPossible
    {
        private Dictionary<char, char> _unionFind;
        private string[] _equations;

        public EquationsPossible(string[] equations)
        {
            _unionFind = new Dictionary<char, char>();
            _equations = equations;
        }

        public bool IsEquationsPossible()
        {
            List<string> unequals = new();
            foreach (var equation in _equations)
            {
                if (GetEquationp(equation, out char arg1, out char arg2))
                    Union(arg1, arg2);
                else
                    unequals.Add(equation);
            }

            foreach (var unequal in unequals)
            {
                var c1 = Find(unequal[0]);
                var c2 = Find(unequal[3]);
                if (c1 == c2)
                    return false;
            }

            return true;
        }

        public static bool Run(string[] equations)
        {
            EquationsPossible equationsPossible = new EquationsPossible(equations);
            return equationsPossible.IsEquationsPossible();
        }

        public static bool GetEquationp(string equation, out char arg1, out char arg2)
        {
            arg1 = equation[0];
            arg2 = equation[3];
            return equation[1..3] == "==";
        }

        private char Find(char arg)
        {
            if (_unionFind.ContainsKey(arg))
            {
                return _unionFind[arg] = Find(_unionFind[arg]);
            }

            return arg;
        }

        private void Union(char arg1, char arg2)
        {
            var c1 = Find(arg1);
            var c2 = Find(arg2);
            if (!c1.Equals(c2))
                _unionFind[c1] = c2;
        }
    }
}
