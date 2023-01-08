using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator
{
    public class NumberExpression : SimpleExpression<int>
    {
        public NumberExpression(int x) : base(x) { }

        public override int Evulate(Func<char, int> mapper)
        {
            return X;
        }
    }
}
