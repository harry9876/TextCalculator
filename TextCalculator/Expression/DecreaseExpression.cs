using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TextCalculator.Expression;

namespace TextCalculator
{
    public class DecreaseExpression : OrderExpression, ISetExpression
    {
        public DecreaseExpression(char variable, Order order)
            : base(variable, order, '-')
        {
        }


    }
}
