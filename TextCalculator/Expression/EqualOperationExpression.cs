using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TextCalculator.Expression;

namespace TextCalculator
{
    public class EqualOperationExpression : SetExpression
    {

        public EqualOperationExpression(char variable, IExpression y, char op)
            : base(variable, new OperationExpression(new VariableExpression(variable), y, op))
        {
        }
    }


}
