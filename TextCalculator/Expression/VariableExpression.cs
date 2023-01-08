using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator
{
    public class VariableExpression : SimpleExpression<char>
    {
        public VariableExpression(char x) : base(x) { }

        public override int Evaluate(Func<char, int> mapper)
        {
            return mapper(X);
        }
    }
}
