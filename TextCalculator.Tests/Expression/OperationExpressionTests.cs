using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator.Tests.Expression
{
    internal class OperationExpressionTests
    {
        [Test]
        public void Evaluate_PlusOperator_Correct()
        {
            var expression = new OperationExpression(new NumberExpression(1), new NumberExpression(2), '+');

            Assert.That(expression.Evaluate(null), Is.EqualTo(3));
        }

        [Test]
        public void Evaluate_MinusOperator_Correct()
        {
            var expression = new OperationExpression(new NumberExpression(3), new NumberExpression(2), '-');

            Assert.That(expression.Evaluate(null), Is.EqualTo(1));
        }


        [Test]
        public void Evaluate_MulOperator_Correct()
        {
            var expression = new OperationExpression(new NumberExpression(3), new NumberExpression(2), '*');

            Assert.That(expression.Evaluate(null), Is.EqualTo(6));
        }

        [Test]
        public void Evaluate_DivOperator_Correct()
        {
            var expression = new OperationExpression(new NumberExpression(6), new NumberExpression(2), '/');

            Assert.That(expression.Evaluate(null), Is.EqualTo(3));
        }

    }
}
