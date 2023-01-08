using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TextCalculator.Expression;

namespace TextCalculator
{
    public class OrderExpression : OperationExpression, ISetExpression
    {
        public Order Order { get; private set; }

        private SetExpression _InnerSet;

        public char Variable => ((VariableExpression)Left).X;

        public OrderExpression(char variable, Order order, char operation)
            : base(new VariableExpression(variable), new NumberExpression(1), operation)
        {
            Order = order;
            _InnerSet = new SetExpression(variable, new OperationExpression(new VariableExpression(variable), new NumberExpression(1), operation));
        }

        public override int Evulate(Func<char, int> mapper)
        {
            return Left.Evulate(mapper);
        }

        public ISetExpression GetSetter()
        {
            return _InnerSet;
        }
    }

    public enum Order
    {
        Pre,
        Post
    }


}
