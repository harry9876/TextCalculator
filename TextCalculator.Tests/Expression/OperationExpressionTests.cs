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
        public void Evulate_PlusOperator_Correct()
        {
            var expression = new OperationExpression(new NumberExpression(1), new NumberExpression(2), '+');

            Assert.That(expression.Evulate(null), Is.EqualTo(3));
        }

        [Test]
        public void Evulate_MinusOperator_Correct()
        {
            var expression = new OperationExpression(new NumberExpression(3), new NumberExpression(2), '-');

            Assert.That(expression.Evulate(null), Is.EqualTo(1));
        }


        [Test]
        public void Evulate_MulOperator_Correct()
        {
            var expression = new OperationExpression(new NumberExpression(3), new NumberExpression(2), '*');

            Assert.That(expression.Evulate(null), Is.EqualTo(6));
        }

        [Test]
        public void Evulate_DivOperator_Correct()
        {
            var expression = new OperationExpression(new NumberExpression(6), new NumberExpression(2), '/');

            Assert.That(expression.Evulate(null), Is.EqualTo(3));
        }

    }
}
