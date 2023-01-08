using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator.Expression
{
    public class SetExpression : ISetExpression
    {
        public char Variable { get; private set; }
        public IExpression Right { get; private set; }

        public SetExpression(char x, IExpression y)
        {
            Variable = x;
            Right = y;
        }

        public int Evaluate(Func<char, int> mapper)
        {
            return Right.Evaluate(mapper);
        }

        public ISetExpression GetSetter()
        {
            return this;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
