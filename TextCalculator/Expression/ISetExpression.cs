using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator.Expression
{
    public interface ISetExpression : IExpression
    {
        char Variable { get; }

        IExpression Right{ get; }

        public ISetExpression GetSetter();
    }
}
